using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {  
    
    public float speed;

    public GameObject defaultBullet;

    static PlayerMovement playerMovement;

    GunController gunController;
    Animator animator;

    static float countdownTime = 0;

    static bool backToDefault;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = new PlayerMovement(speed, 1.0F);
        gunController = new GunController(defaultBullet);
    }

    void Update()
    {        
        if (backToDefault)
            StartCoroutine("BackToDefault");

        if (Input.GetButtonDown("Shoot"))
            gunController.Shoot(gameObject.transform);

        playerMovement.Walk(transform);
        playerMovement.Animate(animator);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("remember to create the load scene");
        }
    }

    IEnumerator BackToDefault()
    {
        backToDefault = false;
        yield return new WaitForSeconds(countdownTime);
        playerMovement = new PlayerMovement(speed, 1.0F);        
    }

    public static void SetMovement(PlayerMovement movement)
    {
        playerMovement = movement;
    }

    public static void StartCountdown(float time)
    {
        countdownTime = time;
        backToDefault = true;
    }
}
