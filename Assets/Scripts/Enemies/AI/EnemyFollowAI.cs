using UnityEngine;

public class EnemyFollowAI : MonoBehaviour {

    Transform player;
    CircleCollider2D cricleCollider2D;
    EnemyMovementAI movimentScript;

    public float followSpeed;
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
        movimentScript = GetComponent<EnemyMovementAI>();
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
        transform.position = Vector3.MoveTowards(transform.position, player.position, (followSpeed * Time.deltaTime));
    }

    void CheckStopDistance() {        
        if (GetDistance() >= stopDistance) {
            movimentScript.enabled = true;
            near = false;
        }                
    }

    void CheckFollowDistance() {
        if (GetDistance() <= followDistance) {
            movimentScript.enabled = false;
            near = true;
        }
    }

    float GetDistance() {
        return Vector3.Distance(transform.position, player.position);
    }
}
