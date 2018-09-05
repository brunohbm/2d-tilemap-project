using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {  
    
    public float speed;

    static Movement playerMovement;
    Animator animator;

    static float countdownTime = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = new Movement(speed, 1.0F);
    }

    void Update()
    {
        if (countdownTime != 0)
            StartCoroutine("BackToDefault");

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
        yield return new WaitForSeconds(countdownTime);
        playerMovement = new Movement(speed, 1.0F);
        countdownTime = 0;
    }

    public static void SetMovement(Movement movement)
    {
        playerMovement = movement;
    }

    public static void StartCountdown(float time)
    {
        countdownTime = time;
    }
}
