using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour {
    public Transform sightStart, sightEnd;
    public bool facingLeft = true;
    public bool spotted;
    public GameObject arrow; //arrow in tutorial for an alert the player has entered guard line of sight
    public Vector2 direction;
    public SphereCollider sphereSight;
    public Rigidbody2D bullet; // enemy attack
    public float speed = 40f;
    public Ray sight;
    public bool allowFire = true;
    private PlayerControl player; 


    // Use this for initialization
    void Start () {
        //InvokeRepeating("patrol",0f,Random.Range(0,4));
	}
	
	// Update is called once per frame
	void Update () {
        //rayCast();
        //behaviours();
        //enemySight();
	}

    //for the raycast
    bool rayCast()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        if (spotted = Physics2D.Linecast(sightStart.position, playerPosition,
        1 << LayerMask.NameToLayer("floor"))){// floor is a placeholder
            return false; 
        }
        else if (spotted = Physics2D.Linecast(sightStart.position, playerPosition,
            1 << LayerMask.NameToLayer("Player")))
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    private void FixedUpdate()
    {
        if (rayCast() == true && (allowFire))
        {
            if (player.transform.position.x < transform.position.x) 
            {// for left player

                //Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D; //My one
                Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>(); // william's suggested way
                bulletInstance.velocity = new Vector2(speed, 0);
                StartCoroutine(rateOfFireController());
            }
            else if(player.transform.position.x > transform.position.x){ //for right player

                Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
                StartCoroutine(rateOfFireController());
             }
        }
    }

    void patrol()
    {
        facingLeft = !facingLeft;
        if (facingLeft == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    IEnumerator rateOfFireController()
    {
        allowFire = false;
        yield return new WaitForSeconds(.4f);
        allowFire = true;
    }
}


