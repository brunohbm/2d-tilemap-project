using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;
	
	void FixedUpdate () {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smothedPosition;
	}
}
