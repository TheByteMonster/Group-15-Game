using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour {
    public Transform sightStart, sightEnd;
    public bool facingLeft = true;
    public bool spotted;
    public GameObject arrow; //arrow in tutorial for an alert the player has entered guard line of sight
    public Vector2 direction;


    // Use this for initialization
    void Start () {
        InvokeRepeating("patrol",0f,Random.Range(0,4));
	}
	
	// Update is called once per frame
	void Update () {
        rayCast();
        behaviours();
	}

    void rayCast() {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));// implement masking layer later
    }

    void behaviours() {
        //use sphere collider

        //if player enter sphere collider 
        //draw raycast
        //if raycast does hit object 
        //shoot

        if (spotted == true) {
            //arrow.SetActive(true);
            //if player enters the sphere collider 
            //OnCollisionEnter2D(); for the player
           
        }
        else {
            arrow.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D sight = Physics2D.Raycast(this.gameObject.transform.position, direction, 10.0f);

        //If something was hit.
        if (sight.collider != null)
        {
            Transform objectHit = sight.transform;
            //shoot

            //Display the name of the parent of the object hit.
            Debug.Log(objectHit.parent.name);
        } 
        
    }

    void patrol() {
        facingLeft = !facingLeft;
        if (facingLeft == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
