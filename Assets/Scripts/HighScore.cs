using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HighScore : MonoBehaviour
{

    Player player;
    
    public int defaultScore = 1000;
    public int[] highScores = new int[10];
    
    //Manager must last through gameplay
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

  
    private void Start()
    {
        player = GetComponent<Player>();
        for (int i = 0; i < 10; ++i)
        {
            string pref = "HighScore" + i.ToString();
            if (PlayerPrefs.HasKey(pref))
                highScores[i] = PlayerPrefs.GetInt(pref);
            else
                highScores[i] = defaultScore;
        }
    }

    private void Update()
    {
        int new_score = 0;
        //Keep track of the high score during gameplay
        if (SceneManager.Equals("GameScene", SceneManager.GetActiveScene()))
            new_score = player.score;
        
        //Change the highest score to be the new_score
        else if(SceneManager.Equals("HighScoreScreen", SceneManager.GetActiveScene()))
            for(int i = 0; i < 10; ++i)
            {
                string pref = "HighScore" + i.ToString();
                if (new_score > highScores[i])
                {
                    highScores[i] = new_score;
                    PlayerPrefs.SetInt(pref, new_score);
                    break;
                }
                    
            }
    }

}
