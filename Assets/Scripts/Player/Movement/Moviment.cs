using UnityEngine;

public class Movement {

    float movementSpeed;
    float animatorSpeed;

    float moveHorizontal;
    float moveVertical;

    public Movement(float movementSpeed, float animatorSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.animatorSpeed = animatorSpeed;
    }

    public void Walk(Transform transform)
    {
        Vector3 movement = GetAxis() * movementSpeed;
        transform.Translate(movement * Time.deltaTime);
    }

    public void Animate(Animator animator)
    {
        animator.speed = animatorSpeed;
        SetLayer(animator);
        animator.SetFloat("x", moveHorizontal);
        animator.SetFloat("y", moveVertical);
    }

    Vector3 GetAxis()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        return new Vector3(moveHorizontal, moveVertical, 0);
    }

    void SetLayer(Animator animator)
    {
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            animator.SetLayerWeight(1, 0);
            return;
        }
        animator.SetLayerWeight(1, 1);
    }
}
