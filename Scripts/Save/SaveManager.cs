using UnityEngine;
using System;
using System.IO;

public static class SaveManager
{
    public static void Save<T>(T saveData, string fileName)
    {
        string jsonDataString = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + fileName, jsonDataString);
    }

    public static T Load<T>(string fileName)
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(Application.persistentDataPath + fileName));
    }

    public static void SaveDestroyManager(string fileName)
    {
        File.WriteAllText(Application.persistentDataPath + fileName, "");
    }

    public static bool IsSaveManager(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            string saveText = File.ReadAllText(Application.persistentDataPath + fileName);
            if (saveText != "")
            {
                return true;
            }
        }
        return false;
    }

    [Serializable]
    public class SaveDataGame
    {
        public float Terraform;
        public float Mechanism;
        public float Resource;
        public float Energy;
        public int People;
        public string CardName;
    }

    [Serializable]
    public class SaveDataSettings
    {
        public float Volume;
        public int Quality;
    }

    [Serializable]
    public class SaveDataHistory
    {
        public bool[] isHistories;
    }
}