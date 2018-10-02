using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public Vector3 outPosition;

	bool canDrive;

	GameObject player;

	void OnEnable()
	{
		canDrive = false;
		player = transform.GetChild (0).gameObject;
	}

	void Update () {
		if(Input.GetButtonDown("Action") && canDrive){
			player.transform.position = transform.position + outPosition;
			player.GetComponent<BoxCollider2D> ().enabled = true;				
			player.GetComponent<PlayerController> ().enabled = true;
			this.enabled = false;
		}

		canDrive = true;
	}		
}
