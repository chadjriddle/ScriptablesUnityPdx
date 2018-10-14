using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scriptables.CodeGenerator.Editor
{
    public static class Generator {
        public static GeneratedClassData FromSimpleTemplate(
            string templateName,
            string outputPath,
            Replacements replacements)
        {
            var templatePath = FindTemplatePath(templateName);

            var generatedNamespace = DetermineNamespace(outputPath);
            replacements.Namespace(generatedNamespace);

            var template = File.ReadAllText(templatePath);

            var result = replacements.Apply(template);

            var className = ExtractClassName(result);
            var fullOutputPath = Path.Combine(outputPath, className) + ".cs";

            Directory.CreateDirectory(Path.GetDirectoryName(fullOutputPath));

            if (File.Exists(fullOutputPath))
            {
                File.Delete(fullOutputPath);
            }

            File.WriteAllText(fullOutputPath, result);

            AssetDatabase.Refresh();

            return new GeneratedClassData
            {
                Namespace = generatedNamespace,
                ClassName = className,
                Path = fullOutputPath
            };
        }

        private static string DetermineNamespace(string outputPath)
        {
            var result = outputPath.Replace(Application.dataPath, string.Empty).Replace('/', '.').Substring(1);
            return string.IsNullOrWhiteSpace(result) ? "Assets" : result;
        }

        private static readonly Regex ClassNameRegEx = new Regex(@"(?<=^[^']*\bclass\s)(?<class>\b\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        private static readonly Regex NamespaceRegEx = new Regex(@"(?<=^[^']*\bnamespace\s)(?<namespace>\b[.\w]+\.(\w+))", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static string ExtractClassName(string classText)
        {
            var result = ClassNameRegEx.Match(classText);
            if (result.Success)
            {
                return result.Value;
            }

            throw new Exception("Unable to find Class Name");
        }

        public static string ExtractNameSpace(string classText)
        {
            var result = NamespaceRegEx.Match(classText);
            if (result.Success)
            {
                return result.Value;
            }

            return string.Empty;
        }

        private static string FindTemplatePath(string templateName)
        {
            var guids = AssetDatabase.FindAssets(templateName);
            Assert.IsTrue(guids.Length > 0, $"Missing template: \"{templateName}\"");
            //Assert.IsTrue(guids.Length < 2, $"To many templates for name: \"{templateName}\"");

            return AssetDatabase.GUIDToAssetPath(guids.First());
        }

        public static string DetermineFullAssetFolder(UnityEngine.Object asset)
        {
            var assetPath = AssetDatabase.GetAssetPath(asset);
            var fullAssetPath = Application.dataPath + "/" + assetPath.Replace("Assets/", "");
            return Path.GetDirectoryName(fullAssetPath).Replace("\\", "/");
        }
    }

    public class GeneratedClassData
    {
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
    }

    public class Replacements
    {
        public string OpeningTag { get; set; } = "#";
        public string ClosingTag { get; set; } = "#";
        public string UsingTag { get; set; } = "USINGS";

        private readonly Dictionary<string, string> _replacements = new Dictionary<string, string>();
        private readonly HashSet<string> _usings = new HashSet<string>();

        public string Apply(string input)
        {
            var result = input;
            foreach (var replacement in _replacements)
            {
                result = result.Replace(FormatTag(replacement.Key), replacement.Value);
            }

            var usingReplacement = BuildUsingReplacement();
            result = result.Replace(FormatTag(UsingTag), usingReplacement);

            return result;
        }

        private string BuildUsingReplacement()
        {
            var result = new StringBuilder();
            foreach (var use in _usings)
            {
                result.AppendLine($"using " + use + ";");
            }

            return result.ToString();
        }

        private string FormatTag(string tag)
        {
            return OpeningTag + tag + ClosingTag;
        }

        public Replacements Add(string key, string value)
        {
            _replacements.Add(key, value);
            return this;
        }

        public Replacements Namespace(string value)
        {
            return Add("NAMESPACE", value);
        }

        public Replacements Type(string value)
        {
            Add("TYPE", value);
            return this;
        }

        public Replacements Type(Type type)
        {
            return 
                AddUsing(type.Namespace)
                .Type(type.Name);
        }

        public Replacements Type<T>()
        {
            return 
                AddUsingFor<T>()
                .Type(typeof(T).Name);
        }

        public Replacements AddUsing(string value)
        {
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                _usings.Add(value);
            }

            return this;
        }

        public Replacements AddUsingFor<T>()
        {
            return AddUsing(typeof(T).Namespace);
        }
    }
}
