using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    /*
     * Monitor Mouse Position and move accordingly
     * collider with fellObject
     * Change Score and live count (if bomb)
     */

    public int score = 0;
    public int lives;
    public Vector3 startPos;
    public AudioSource warp;
    // Start is called before the first frame update


    void Start()
    {

        
        transform.position = startPos;
        lives = 3;
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "Meteor")
        {
            Destroy(hit.gameObject);
            score += 100;
            warp.Play();
        }
            
    }
}
