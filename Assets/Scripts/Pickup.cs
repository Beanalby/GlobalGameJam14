using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        if(other.tag != "Player") {
            return;
        }
        GameObject.Find("WorldState").GetComponent<GameState>().AddPickup();
        Destroy(gameObject);
    }
}
