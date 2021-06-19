using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;         // # команды для редактора
#endif

public class MenuUI : MonoBehaviour
{
    public InputField InputName;
    public static MenuUI Instance;

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
}
