using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour {

    Transform player;
    CircleCollider2D cricleCollider2D;

    public float speed;
    public float stopDistance;
    public float followDistance;
    
    bool near;

    private void OnDrawGizmosSelected () {
        //*Follow Wire*//
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);

        //*Stop Wire*//
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    void Start () {
        player = GameObject.FindWithTag("Player").transform;        
	}
	
	void Update () {
        if (near) {
            Follow();
            CheckStopDistance();
        } else {
            CheckFollowDistance();
        }
	}

    void Follow () {
        transform.position = Vector3.MoveTowards(transform.position, player.position, (speed * Time.deltaTime));
    }

    void CheckStopDistance() {        
        if (GetDistance() >= stopDistance) {
            near = false;
        }                
    }

    void CheckFollowDistance() {
        if (GetDistance() <= followDistance) {
            near = true;
        }
    }

    float GetDistance() {
        return Vector3.Distance(transform.position, player.position);
    }
}
