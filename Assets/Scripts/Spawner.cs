using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    /* Properties:
     vector3 Position
     speed of movement
     movement direction
     Change randomly
     Scale with game time
     LIMIT BY SCREEN BOUNDS
     SPAWN SHIT!!!

    */

    [Range(0f, 10f)]
    public float speed = 5f;

    [Range(0f, 400f)]
    public float maxSpeed = 300f;

    [Range(1, 1.010f)]
    public float acceleration = 1.002f;     //Snap, Crackle, Pop

    [Range(0, 1f)]
    public float directionChangeChance = 0.003f;

    [Range(1, 1.010f)]
    [Tooltip("The rate at which spawner movement becomes more erratic")]
    public float chanceChanger = 1.002f;

    [Range(0, 1f)]
    [Tooltip("Time between prefab spawns")]
    public float dropBuffer = 0.3f;

    public float LR_Edge = 9f;   //Value of the edge of the screen. Check with this and neg this
    public Vector3 pos;     //Creates a shorthand for transform.position

    [Space]
    [Header("Items allowed to spawn")]
    public GameObject fellObject;


    void Spawn()
    {
        print("Should be spawning...");
        GameObject fallen = Instantiate(fellObject) as GameObject;
        fallen.transform.position = transform.position;
    }

    void ChangeDirection()  //ALT: ADJUST_VALUES
    {
        pos = transform.position;
        if (pos.x < -LR_Edge)
        {
            speed = Mathf.Abs(speed);  // Move right
            print($"Moving right: {pos.x}");
        }

        else if (pos.x > LR_Edge)
        {
            speed = -Mathf.Abs(speed); // Move left
            print($"Moving left: {pos.x}");
        }
        //Must be within bounds to change direction
       if (Random.value <= directionChangeChance && pos.x > -LR_Edge && pos.x < LR_Edge) 
            speed *= -1;
    }


    void AdjustValues()
    {
        speed *= acceleration;
        directionChangeChance *= chanceChanger;
    }
    



    void Start()
    {
        transform.position = pos; // CHANGE TO CENTER ON SCREEN
        InvokeRepeating("Spawn", 2f, dropBuffer);    //what's that float?
    }

    
    void Update()
    {
        //Here we make the spawner move, change its direction, and alter its constants
        //Then the spawning begins
        transform.position = pos;
        pos += (speed * Vector3.right * Time.deltaTime);


    }


    private void FixedUpdate()
    {

        ChangeDirection();
        if(Mathf.Abs(speed) < maxSpeed)
            AdjustValues();
    }
}
