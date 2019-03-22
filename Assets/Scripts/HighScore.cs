using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HighScore : MonoBehaviour
{

    Player player;
    
    public int defaultScore = 1000;
    public int[] highScores = new int[10];
    int new_score;
    //Manager must last through gameplay
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

  
    private void Start()
    {
        
        for (int i = 0; i < 10; ++i)
        {
            string pref = "HighScore" + i.ToString();
            if (PlayerPrefs.HasKey(pref))
                highScores[i] = PlayerPrefs.GetInt(pref);
            else
                highScores[i] = defaultScore;
        }

        for (int i = 0; i < 10; ++i)
        {
            print(highScores[i]);
        }
    }

    private void Update()
    {
        
        //Keep track of the high score during gameplay
        if (SceneManager.Equals(SceneManager.GetSceneByName("GameScene"), SceneManager.GetActiveScene()))
        {
            player = GetComponent<Player>();
            new_score = player.score;
        }
            
        
        //Change the highest score to be the new_score
        else if(SceneManager.Equals(SceneManager.GetSceneByName("GameOver"), SceneManager.GetActiveScene()))
            for(int i = 0; i < 10; ++i)
            {
                string pref = "HighScore" + i.ToString();
                if (new_score > highScores[i])
                {
                    highScores[i] = new_score;
                    PlayerPrefs.SetInt(pref, new_score);
                    print(highScores[i]);
                    print(PlayerPrefs.GetInt(pref));
                    break;
                }
                    
            }
    }

}
