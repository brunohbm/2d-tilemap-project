using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour {

    public GameObject[] bullets;

    GunController gunController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gunController = collision.gameObject.GetComponent<GunController>();
            gunController.AddMunition(GetRandomBullet());
            PowerUpSpawnController.Spawn();
            Destroy(gameObject);
        }
    }

    GameObject GetRandomBullet()
    {
        int randomNumber = Random.Range(0, bullets.Length);
        return bullets[randomNumber];
    }

}
