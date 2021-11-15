using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField InputName;
    public string PlayerName;
    public Text bestScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        BestGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePlayerName()
    {
        PlayerName = InputName.text;
        WholeManager.Instance.PlayerName = PlayerName;
    }
    public void BestGame()
    {
       
            score= WholeManager.Instance.BestScore;
        bestScore.text = "Best Score: " +WholeManager.Instance.BestPlayer + $" {score}";
    }
    public void NewColorSelected(Text name)
    {
       // WholeManager.Instance.PlayerName = name;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
      WholeManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif
    }
}
