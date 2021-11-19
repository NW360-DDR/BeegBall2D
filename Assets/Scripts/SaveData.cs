using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    [SerializeField] LevelData saveMe = new LevelData();
    
    public void SaveToFile()
    {
        string levels = JsonUtility.ToJson(saveMe);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Save.json", levels);
    }

    public void LoadFromFile()
    {
        string saveData = System.IO.File.ReadAllText(Application.persistentDataPath + "/Save.json");
        saveMe = JsonUtility.FromJson<LevelData>(saveData);
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


    public void UpdateLevel(bool a, bool b, bool c)
    {
        this.Lemon1 = a;
        this.Lemon2 = b;
        this.Lemon3 = c;
    }
}