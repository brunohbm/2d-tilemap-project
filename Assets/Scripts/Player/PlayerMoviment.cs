using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    public float speed;

	void Update () {
        Move();
	}

    void Move() {
        Vector3 moviment = GetAxis() * speed;
        transform.Translate(moviment * Time.deltaTime);
    }

    Vector3 GetAxis() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        return new Vector3(moveHorizontal, moveVertical, 0);
    }
}
