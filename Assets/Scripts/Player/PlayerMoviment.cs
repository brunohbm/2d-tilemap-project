using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {

    public float speed;

    float moveHorizontal;
    float moveVertical;

    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
        Move();
        SetAnimation();
	}

    void Move() {
        Vector3 moviment = GetAxis() * speed;
        transform.Translate(moviment * Time.deltaTime);
    }

    Vector3 GetAxis() {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        return new Vector3(moveHorizontal, moveVertical, 0);
    }

    void SetAnimation() {
        SetLayer();
        animator.SetFloat("x", moveHorizontal);
        animator.SetFloat("y", moveVertical);
    }

    void SetLayer() {
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetLayerWeight(1, 0);
            return;
        }
        animator.SetLayerWeight(1, 1);
    }
}
