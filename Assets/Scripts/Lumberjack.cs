﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour
{
    public bool spotted;
    public Vector2 direction;
    public Ray sight;
    public float healthPoints;
    public bool dead = false;
    public AudioClip[] deathClips;
    public float deathSpinMin = -100f;
    public float deathSpinMax = 100f;
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    private DodoHealth playerHealth;
    private Collider2D[] cols;

    private void Awake()
    {
       
    }

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("patrol",0f,Random.Range(0,4));
  
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
        playerHealth = GetComponent<DodoHealth>();
        cols = GetComponents<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //kill enemy if health is zero
        if (healthPoints <= 0)
        {
            Death();
        }

        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 7);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 7, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .02f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .02f, enemyMask);

        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }

    public void Damaged()
    {
        healthPoints -= 50;
        Debug.Log(healthPoints);
    }

    public void Death()
    {
        dead = true;
        Debug.Log("Adding Time");
        playerHealth.GetComponent<DodoHealth>().EnemyDead();
      
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin, deathSpinMax));
        //int i = Random.Range(0, deathClips.Length);
        //AudioSource.PlayClipAtPoint(deathClips[i], transform.position);
    }
 
     

    



}


