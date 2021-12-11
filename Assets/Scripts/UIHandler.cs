using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] Text currentScoreText;
    [SerializeField] Text highScoreText;

    private void Start()
    {
        currentScoreText.text = "CurrentScore:  " + PlayerPrefs.GetInt("CurrentScore").ToString();
        if(PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("CurrentScore"));
        }
        highScoreText.text = "HighScore:  " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }
}
