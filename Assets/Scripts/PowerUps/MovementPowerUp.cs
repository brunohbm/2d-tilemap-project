using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPowerUp : MonoBehaviour {

    public float movementSpeed;
    public float animatorSpeed;
    public float time;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController.SetMovement(new Movement(movementSpeed, animatorSpeed));
            PlayerController.StartCountdown(time);
            Destroy(gameObject);
        }
    }
}
