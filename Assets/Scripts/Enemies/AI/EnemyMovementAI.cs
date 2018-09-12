using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour {

    public float movementSpeed;
    public float moveDistance;
    public float stoppedTime;

    Vector3 nextPosition;

    bool wait;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if(nextPosition != null)
        Gizmos.DrawLine(transform.position, nextPosition);
        Gizmos.DrawWireSphere(transform.position, moveDistance);
    }

    void Start ()
    {
        nextPosition = transform.position;
    }
	
	void Update ()
    {        
        if(!wait)
            CheckDistance();
	}

    private void Move()
    { 
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, movementSpeed);
    }

    private void CheckDistance()
    {
        if(Vector3.Distance(transform.position, nextPosition) > 0)
        {
            Move();
            return;
        }
        StartCoroutine("WaitForWalk");
    }

    private void GetNextPosition()
    {
        Vector3 newPosition = new Vector3(
            Random.Range(-moveDistance, moveDistance),
            Random.Range(-moveDistance, moveDistance),
            0);

        newPosition += nextPosition;

        RaycastHit2D raycastHit2D = Physics2D.LinecastNonAlloc(transform.position, newPosition);        
        if (raycastHit2D.collider != null)
        {
            nextPosition = newPosition;
            wait = false;
            return;
        }
        GetNextPosition();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
        else
        {
            wait = true;
            GetNextPosition();
            return;
        }
    }

    IEnumerator WaitForWalk()
    {
        wait = true;
        yield return new WaitForSeconds(stoppedTime);
        GetNextPosition();
    }
}
