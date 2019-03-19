using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Functions to be called by different menu buttons
public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ScoreScreen()
    {
        SceneManager.LoadScene("HighScoreMenu");

    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SoundOptions()
    {
        SceneManager.LoadScene("SoundOptions");
    }

    //Used to move from the high score name input to the next menu
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");

    }

    public void QutiGame()
    {
        Application.Quit();
    }
}
