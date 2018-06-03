using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberjackGun : MonoBehaviour {

    public Rigidbody2D bullet;              // Prefab of the rocket.
    public float speed = 20f;				
    public float range;
    public float fireRate = 1f;
    public bool allowFire = true;
    public bool facingLeft = true;
    public bool spotted;
    

    private Animator anim;                  // Reference to the Animator component.
    private PlayerController target;
    private float dir;
    private GameObject gun;
    


    void Awake()
    {
        // Setting up the references.
        anim = transform.root.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        rayCast();
    }

    void Update()
    {
        //pointWeapon();
    }

    private void FixedUpdate()
    {
        rayCast();
        
  
    }

    //for the raycast
    void rayCast()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        Quaternion rotation = Quaternion.LookRotation(playerPosition - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
       
        Debug.DrawLine(transform.position, playerPosition, Color.green);

        if (spotted = Physics2D.Linecast(transform.position, playerPosition,
        1 << LayerMask.NameToLayer("ground")))
        {
            //nothing happens
        }
        else if (spotted = Physics2D.Linecast(transform.position, playerPosition,
            1 << LayerMask.NameToLayer("Player")))
        {
            fireWeapon();
        }
    }

    public void fireWeapon()
    {
      

        if ((allowFire))
        {

            // ... set the animator Shoot trigger parameter and play the audioclip.
            //anim.SetTrigger("Shoot");
            //GetComponent<AudioSource>().Play();

            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            bulletInstance.velocity = new Vector2(speed, 0);
            StartCoroutine(rateOfFireController());
        }

    }
    //legacy code, consider putting it in raycast()
    void pointWeapon() {

        //need to get gun sprite to point at player

        float xAxis;

        Transform playerLocation = target.getPlayerPosition();
        transform.LookAt(playerLocation);

  
        //Vector3 dir = playerLocation - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    IEnumerator rateOfFireController()
    {
        allowFire = false;
        yield return new WaitForSeconds(.4f);
        allowFire = true;
    }
}
