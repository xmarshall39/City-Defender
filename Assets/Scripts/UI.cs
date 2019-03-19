using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Needs to access the another script's score counter
    //the life counter
    //Game over status?
    //Change display based on scene
        //could make a start screen
        //How do I cross fade

    public Text score;
    public Text lives;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = player.score.ToString();
        lives.text = "Lives: " + player.lives.ToString();
    }
}
