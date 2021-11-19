using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    [SerializeField] LevelData saveMe = new LevelData();
    
    public void SaveToFile()
    {
        string levels = JsonUtility.ToJson(saveMe);
    }
}

[System.Serializable]
public class LevelData
{
    public int StagesCleared;
    public List<Level> Lemons = new List<Level>();
}

[System.Serializable]
public class Level
{
    public bool Lemon1, Lemon2, Lemon3;
}