using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    
    public void LifeLost()
    {
        //Destroy all falling objects
        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject obj in fallingObjects)
            Destroy(obj);

        if (GameObject.Find("Player").GetComponent<Player>().lives == 0)
            SceneManager.LoadScene("GameOver");
    }

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Time.timeScale = 1;
        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }

}
