using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string BestUserName;
    public int BestScore;
    public string LastUserName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //Load Best user Name and Best score in the application
        LoadScore();
    }
    private void Update()
    {
        // Check if the user is on a non-main scene and presses the Escape key
        if (SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the main scene (assuming the main scene is at build index 0)
            SceneManager.LoadScene(0);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string BestUserName;
        public int BestScore;

        //public string LastUserName;
    }

    public void SaveScore(string name, int score)
    {   
        SaveData data = new SaveData();
        data.BestUserName = name;
        data.BestScore = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestUserName = data.BestUserName;   
            BestScore = data.BestScore;
        }
    }
/*
    public void SaveLastUser(string name)
    {
        SaveData data = new SaveData();
        data.LastUserName = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadLastUser()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LastUserName = data.LastUserName;
        }
    }
*/
}
