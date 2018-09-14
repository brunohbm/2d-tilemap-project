using UnityEngine;

public class PlayerMovement {

    public float movementSpeed;
    public float animatorSpeed;

    float moveHorizontal;
    float moveVertical;

    public Vector3 lastPosition;

    public PlayerMovement(float movementSpeed, float animatorSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.animatorSpeed = animatorSpeed;
    }

    public void Walk(Transform transform)
    {        
        Vector3 movement = GetAxis() * movementSpeed;
        transform.Translate(movement * Time.deltaTime);
        SaveLastPosition(GetAxis());
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
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");        
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

    void SaveLastPosition(Vector3 position)
    {
        if (position != Vector3.zero)                    
            lastPosition = position;      
    }
}
