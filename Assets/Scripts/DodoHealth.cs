using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodoHealth : MonoBehaviour {

    public float timeToLive= 100f;               
    public AudioClip[] ouchClips;               // Array of clips to play when the player is damaged.
    public float damageAmount = 10f;            // The amount of damage to take when enemies touch the player

    private float lastHitTime;                  // The time at which the player was last hit.
    private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Animator anim;						// Reference to the Animator on the player

    private Score score;

    //Modify script to account for time
    //Implement this method into the score component

    void Awake()
    {
        // Setting up references.
        playerControl = GetComponent<PlayerControl>();
        //anim = GetComponent<Animator>();

    }

    void Update()
    {
        timeToLive -= Time.deltaTime;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "BunkerBullet")
        {
            //TakeDamage(col.transform);
            hurt();
            }
         
            else //KEEP THIS ELSE STATEMENT
            {

        }
    }

    //legacy code?? delete
    void TakeDamage(Transform enemy)
    {
        // Make sure the player can't jump.
        playerControl.jump = false;
        // Create a vector that's from the enemy to the player with an upwards boost.
        //Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

        // Add a force to the player in the direction of the vector and multiply by the hurtForce.
        timeToLive -= 5;

        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }

    public void hurt()
    {
        playerControl.jump = false;

        timeToLive -= 5f;

        int i = Random.Range(0, ouchClips.Length);
        AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }

    public void UpdateTimeDisplay()
    {
        //Destroy();
    }
}
