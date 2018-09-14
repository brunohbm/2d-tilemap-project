using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPowerUp : MonoBehaviour {

    public float movementSpeed;
    public float animatorSpeed;
    public float time;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.ChangeSpeed(movementSpeed, animatorSpeed);
            playerController.StartCountdown(time);
            PowerUpSpawnController.Spawn();
            Destroy(gameObject);
        }
    }
}
