using UnityEngine;
using System.Collections;

public enum GameWorld { human, race, dino, space };

public class WorldState : MonoBehaviour {

    private GameWorld world;
    public GameWorld World {
        get { return world; }
    }

	void Start () {
        world = GameWorld.human;
	}
	
    public void Update() {
        if(Input.GetKeyDown(KeyCode.A)) {
            HandleUpdateWorld(GameWorld.human);
        } else if(Input.GetKeyDown(KeyCode.S)) {
            HandleUpdateWorld(GameWorld.race);
        } else if(Input.GetKeyDown(KeyCode.D)) {
            HandleUpdateWorld(GameWorld.dino);
        } else if(Input.GetKeyDown(KeyCode.F)) {
            HandleUpdateWorld(GameWorld.space);
        }
    }

    private void HandleUpdateWorld(GameWorld newWorld) {
        this.world = newWorld;
        foreach (WorldSwitcher obj in GameObject.FindObjectsOfType<WorldSwitcher>()) {
            obj.WorldSwitched(newWorld);
        }
        SendMessage("UpdateWorld", newWorld);
    }
}
