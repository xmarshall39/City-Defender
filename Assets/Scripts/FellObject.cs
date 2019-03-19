using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellObject : MonoBehaviour
{

    //Needs a rigidbody
    //collider
    //Destroy upon container collision
    //Destroy when screen edge is reached
    //Reduce the life counter
    // Start is called before the first frame update


    public static float despawnThreshhold = -5.4f;
    public Player player;
    SceneManage scene;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        scene = GameObject.Find("EventSystem").GetComponent<SceneManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= despawnThreshhold)
        {
            player.lives--;
            scene.LifeLost();
            Destroy(this.gameObject);
        }
            
    }
}
