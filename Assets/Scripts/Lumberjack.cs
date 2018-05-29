using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour {
    public bool spotted;
    public Vector2 direction;
    public Ray sight;
    public float healthPoints;
    public bool dead = false;
    public AudioClip[] deathClips;

    private PlayerControl player;


    // Use this for initialization
    void Start () {
        //InvokeRepeating("patrol",0f,Random.Range(0,4));
	}
	
	// Update is called once per frame
	void Update () {

    }

   void FixedUpdate()
    {
        //kill enemy if health is zero
        if (healthPoints <=0 ) {
            Death();
        }

    }

    public void hurt(Transform col) {

        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "blast")
        {
            damaged();
        }
    }

    void damaged () {
        healthPoints -= 50;
    }

    void Death(Collision2D col ) {

        dead = true;



        int i = Random.Range(0, deathClips.Length);
        AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

        // more to this
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

}


