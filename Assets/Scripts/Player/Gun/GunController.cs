using UnityEngine;

public class GunController : MonoBehaviour {

    static GameObject prefabBullet;

    float speed = 50000;

    public GunController(GameObject defaultBullet)
    {
        SetBullet(defaultBullet);
    }

    public void Shoot(Transform player)
    {
        GameObject bullet = Instantiate(prefabBullet, player.position, player.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(PlayerMovement.GetLastPosition() * (speed * Time.deltaTime));
    }

    public static void SetBullet(GameObject newBullet)
    {
        prefabBullet = newBullet;
    }
}
