﻿using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {  
    
    public float speed;        

    PlayerMovement playerMovement;
    GunController gunController;
    Animator animator;

    void Start()
    {        
        animator = GetComponent<Animator>();
        gunController = GetComponent<GunController>();
        playerMovement = new PlayerMovement(speed, 1.0F);
        playerMovement.lastPosition = new Vector3(0, -1);
    }

    void Update()
    {        
        if (Input.GetButtonDown("Shoot"))
            gunController.Shoot(playerMovement.lastPosition);

        playerMovement.Walk(transform);
        playerMovement.Animate(animator);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("remember to create the load scene");
			return;
        }			
    }

	void OnTriggerStay2D(Collider2D collider)
	{		
		if (collider.gameObject.tag == "Car" && Input.GetButtonDown("Action")) 
		{
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			transform.position = collider.transform.position;
			transform.parent = collider.transform;
			collider.gameObject.GetComponent<CarController> ().enabled = true;
			gameObject.GetComponent<PlayerController> ().enabled = false;
		}
	}

    public void ChangeSpeed(float movementSpeed, float animatorSpeed)
    {
        playerMovement.movementSpeed = movementSpeed;
        playerMovement.animatorSpeed = animatorSpeed;
    }

    public void StartCountdown(float time)
    {
        StartCoroutine(BackToDefault(time));
    }

    IEnumerator BackToDefault(float countdownTime)
    {
        yield return new WaitForSeconds(countdownTime);
        playerMovement = new PlayerMovement(speed, 1.0F);        
    } 
		
}
