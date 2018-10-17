using Demos.WaveGameDemo.Models.Weapons;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Game Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public int Level = 1;
    public int GoldReward = 5;
    public float Speed = 1.0f;
    public float Health = 5.0f;
    public GameObject Prefab;
    public WeaponFunction WeaponFunction;

    public WeaponData Weapon => WeaponFunction?.GetDataForLevel(Level);
}