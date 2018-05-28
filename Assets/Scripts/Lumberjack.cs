using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour {
    public bool facingLeft = true;
    public bool spotted;
    public Vector2 direction;
    public Ray sight;
    public float healthPoints;

    private PlayerControl player;


    // Use this for initialization
    void Start () {
        //InvokeRepeating("patrol",0f,Random.Range(0,4));

        //rayCast();
	}
	
	// Update is called once per frame
	void Update () {
        //rayCast();
        //behaviours();
        //enemySight();
	}

    public void hurt(Transform col) {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "blast")
        {
            hurt();
        }

        else //KEEP THIS ELSE STATEMENT
        {

        }
    }

    void hurt() {
        healthPoints -= 50;
    }

    public string patrol()
    {
        facingLeft = !facingLeft;
        if (facingLeft == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
            return ("left");
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            return ("right");
        }
    }

}


