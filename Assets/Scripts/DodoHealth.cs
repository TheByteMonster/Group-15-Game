using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DodoHealth : MonoBehaviour {

    public float timeToLive= 100f;               
    public AudioClip[] ouchClips;               // Array of clips to play when the player is damaged.
    public float damageAmount = 10f;            // The amount of damage to take when enemies touch the player
    public Text timetoLiveTxt;
 
    private bool timeLeft = true;
    private float lastHitTime;                  // The time at which the player was last hit.
    private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Animator anim;						// Reference to the Animator on the player

    

    void Awake()
    {
        // Setting up references.
        playerControl = GetComponent<PlayerControl>();
        //anim = GetComponent<Animator>();

    }

    void Update()
    {
        timeToLive -= Time.deltaTime;
        UpdateTimeDisplay(timeToLive);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "BunkerBullet")
        {
            //TakeDamage(col.transform);
            hurt();
            }
    }

    //legacy code?? delete
    void TakeDamage(Transform enemy)
    {
        playerControl.jump = false;
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

        if (timeToLive <= 0) {

            Collider2D[] cols = GetComponents<Collider2D>();
            foreach (Collider2D c in cols)
            {
                c.isTrigger = true;
            }
        }
    }
    
    public void UpdateTimeDisplay(float time)
    {
        GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("f2");

        if (time <= 0f)
        {
            timeToLive = 0;
            timeLeft = false;
            GetComponent<GUIText>().text = "Drug Trip Time Left: " + time.ToString("0");
        }
    }
}
