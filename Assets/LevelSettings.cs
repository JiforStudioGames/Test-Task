using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewLevelSettings", menuName = "Level Settings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int minRandomNumber;
    [SerializeField] private int maxRandomNumber;
    
    public int MinRandomNumber => minRandomNumber;
    public int MaxRandomNumber => maxRandomNumber;
}
