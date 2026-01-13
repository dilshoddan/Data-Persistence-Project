using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public int bestScore;
    public string bestPlayerName;

    public int currentScore;

    public string currentPlayerName = "Player";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class UserData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveUserData()
    {
        UserData data = new UserData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/saveUserData.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/saveUserData.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);

            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
    
}
