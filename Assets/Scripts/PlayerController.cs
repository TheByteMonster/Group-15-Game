using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Gravity {

    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;

    private Transform playerPosition;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;
        Debug.Log("Jump");

        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded) {
            
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * .5f;
            }
            targetVelocity = move * maxSpeed;
        }
    }

    public Transform getPlayerPosition() {
        return playerPosition;
    }
}
