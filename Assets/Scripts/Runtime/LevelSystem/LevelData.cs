using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 3)]
public class LevelData : ScriptableObject
{
    public List<Level> Levels = new List<Level>();
}

[System.Serializable]
public class Level
{
    public string LoadLevelID;
}