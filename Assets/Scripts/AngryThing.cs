using UnityEngine;
using System.Collections;

public class AngryThing : MonoBehaviour {
    public float angryRange = 8f;
    public bool isX = false;

    float lastCheck = -1, checkCooldown = .25f;
    int playerMask;

    private GameObject target = null;

    public void Start() {
        playerMask = 1 << LayerMask.NameToLayer("Player");
    }
    public void Update() {
        UpdateTarget();
        HandleMovement();
    }

    private void UpdateTarget() {
        if(Time.time - lastCheck > checkCooldown) {
            if (target == null) {
                // see if they're in range
                Collider[] hits;
                hits = Physics.OverlapSphere(transform.position, angryRange,
                    playerMask);
                if (hits.Length != 0) {
                    target = hits[0].gameObject;
                }
            } else {
                // see if they've left range
                float distance = (target.transform.position - transform.position).magnitude;
                if (distance > angryRange) {
                    target = null;
                }
            }
        }
    }

    private void HandleMovement() {
        if (target == null) {
            return;
        }

        // move towards the player
        Vector3 dest = transform.position;
        if (isX) {
            dest.x = target.transform.position.x;
        } else {
            dest.z = target.transform.position.z;
        }
        transform.position = Vector3.Lerp(transform.position, dest, .1f);
    }

    public void OnCollisionEnter(Collision collision) {
        Debug.Log(name + " collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.SendMessage("GotHit", gameObject);
        }
    }
}
