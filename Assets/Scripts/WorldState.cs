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
            UpdateWorld(GameWorld.human);
        } else if(Input.GetKeyDown(KeyCode.S)) {
            UpdateWorld(GameWorld.race);
        } else if(Input.GetKeyDown(KeyCode.D)) {
            UpdateWorld(GameWorld.dino);
        } else if(Input.GetKeyDown(KeyCode.F)) {
            UpdateWorld(GameWorld.space);
        }
    }

    public void UpdateWorld(GameWorld newWorld) {
        this.world = newWorld;
        foreach (WorldSwitcher obj in GameObject.FindObjectsOfType<WorldSwitcher>()) {
            obj.WorldSwitched(newWorld);
        }
    }
}
