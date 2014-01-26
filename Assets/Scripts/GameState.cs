using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
    private int pickups = 0;
    public int Pickups {
        get { return pickups; }
    }

    public void AddPickup() {
        pickups++;
    }

    public void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 100), "Juice boxes: " + pickups);
    }
}

