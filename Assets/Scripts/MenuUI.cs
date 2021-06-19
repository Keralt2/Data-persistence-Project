using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;         // # команды для редактора
#endif

public class MenuUI : MonoBehaviour
{
    public InputField InputName;
    public string UserName;
    public static MenuUI Instance;
    public int BestScore;
    public string BestScoreName;

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

    public void OnInputChange()
    {
        UserName = InputName.text;
    }

    public void SceneChanger()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        //MainManager.Instance.SaveValue();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestScoreName;
    }

    public void SaveValue() 
    {
        SaveData data = new SaveData(); 
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadValue()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;
        }
    }
}
