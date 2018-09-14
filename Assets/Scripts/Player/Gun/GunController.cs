using UnityEngine;

public class GunController : MonoBehaviour {
    
    GameObject prefabBullet; 
    
    int shots;

    public void Shoot(Vector3 lastPosition)
    {        
        if (shots > 0)
        {            
            GameObject instantiatedBullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            Rigidbody2D rb2D = instantiatedBullet.GetComponent<Rigidbody2D>();
            Bullet bullet = instantiatedBullet.GetComponent<Bullet>();
            rb2D.AddForce(lastPosition * (bullet.speed * Time.deltaTime));            
            shots--;
        }        
    }

    public void AddMunition(GameObject newBullet)
    {
        prefabBullet = newBullet;
        shots = 3;
    }

}
