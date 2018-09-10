using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour {

    public float lifeTime;

	void Start () {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Awake()
    {
        StartCoroutine("Destroy");
        StartCoroutine("SetCollider");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.gameObject.tag == "Player"))      
            Destroy(gameObject);          
    }

    IEnumerator SetCollider()
    {        
        yield return new WaitForSeconds(0.05F);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
