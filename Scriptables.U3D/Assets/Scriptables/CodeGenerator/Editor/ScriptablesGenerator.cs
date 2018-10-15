using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scriptables.CodeGenerator.Editor
{
    public class ScriptablesGenerator
    {

        [MenuItem("Assets/Generate/All Scriptables", false, 10000)]
        public static void Generate(MenuCommand menuCommand)
        {

            var monoscript = Selection.activeObject as MonoScript;

            if (monoscript == null)
            {
                return;
            }


            var scriptNamespace = Generator.ExtractNameSpace(monoscript.text);
            var scriptClassname = Generator.ExtractClassName(monoscript.text);
            var outputDirectory = Generator.DetermineFullAssetFolder(monoscript) + "/Generated";

            GenerateVariableReferenceEditor(scriptNamespace, scriptClassname, outputDirectory);
        }

        public static void GenerateVariableReferenceEditor(string targetNamespace, string targetClassname, string outputDirectory)
        {
            var generated = Generator.FromSimpleTemplate(
                "_Type_Variable",
                outputDirectory,
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace)
                    .Add("PARENT_MENU", "Generated"));
            Debug.Log("Generated - " + generated.ClassName);

            generated = Generator.FromSimpleTemplate(
                "_Type_Reference",
                outputDirectory,
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace));
            Debug.Log("Generated - " + generated.ClassName);

            generated = Generator.FromSimpleTemplate(
                "_Type_Reference_Editor",
                outputDirectory + "/Editor",
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace));
            Debug.Log("Generated - " + generated.ClassName);

            generated = Generator.FromSimpleTemplate(
                "_Type_Unity_Event",
                outputDirectory,
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace));
            Debug.Log("Generated - " + generated.ClassName);

            generated = Generator.FromSimpleTemplate(
                "_Type_Game_Event",
                outputDirectory,
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace)
                    .Add("PARENT_MENU", "Generated"));
            Debug.Log("Generated - " + generated.ClassName);

            generated = Generator.FromSimpleTemplate(
                "_Type_Game_Event_Listener",
                outputDirectory,
                new Replacements()
                    .Type(targetClassname)
                    .AddUsing(targetNamespace));
            Debug.Log("Generated - " + generated.ClassName);
        }
    }
}
