using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Namespace per TextMeshPr

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScore;
    // Riferimento all'InputField
    public TMP_InputField NameInputPrefab; // Usa TMP_InputField se stai usando TextMeshPro
    // Variabile per memorizzare il nome
    private string playerName;

    public void Start()
    {
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.LoadScore();
            BestScore.text = $"Best Score : {MenuManager.Instance.BestUserName} : {MenuManager.Instance.BestScore}";
        }
    }

    public void StartNew()
    {
        if (!string.IsNullOrEmpty(NameInputPrefab.text))
        {
            // Leggi il contenuto dell'InputField e memorizzalo nella variabile playerName
            playerName = NameInputPrefab.text;
            MenuManager.Instance.LastUserName =playerName;
            
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("Inserisci un nome valido!");
        }
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
