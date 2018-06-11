using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 90000;				// The speed the rocket will fire at.
    public float range;
    public float fireRate = 1f;
    public bool allowFire = true;
    public Vector3 bulletOffset;

    private CursorLockMode wantedMode;
    private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.


	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
        //rateOfFireController();

	}

  

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);


        // If the fire button is pressed...
        if (Input.GetButtonDown("Fire1") && (allowFire))
        {
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            shootDirection.z = 0.0f;
            shootDirection = shootDirection.normalized;

            //anim.SetTrigger("Shoot");
            //GetComponent<AudioSource>().Play();

            //...instantiating the rocket
            Vector3 bulletPos = transform.position;
            bulletPos += bulletOffset;
            Rigidbody2D bulletInstance = Instantiate(rocket, bulletPos, Quaternion.identity) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
            bulletInstance.GetComponent<Rocket>().timeAlive = range;
            StartCoroutine(rateOfFireController());
        }
    }

    IEnumerator rateOfFireController() {

        allowFire = false; 
        yield return new WaitForSeconds(fireRate);
        allowFire = true; 
    }
}
