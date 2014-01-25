using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour {

    public GameObject humanVersion, raceVersion, dinoVersion, spaceVersion;

    public void WorldSwitched(GameWorld world) {
        Debug.Log("Switching to " + world);
        GameObject current = transform.parent.gameObject;
        transform.parent = null;
        transform.position = current.transform.position;
        transform.rotation = current.transform.rotation;
        Debug.Log("Destroying " + current.name);
        Destroy(current);
        GameObject prefab = null;
        switch (world) {
            case GameWorld.human:
                prefab = humanVersion; break;
            case GameWorld.race:
                prefab = raceVersion; break;
            case GameWorld.dino:
                prefab = dinoVersion; break;
            case GameWorld.space:
                prefab = spaceVersion; break;
        }
        current = Instantiate(prefab) as GameObject;
        current.transform.position = transform.position;
        current.transform.rotation = transform.rotation;
        // if it has a switcher, delete ourselves
        Transform otherSwitcher = transform.Find("switcher");
        if (otherSwitcher != null) {
            //Destroy(gameObject);
        } else {
            transform.parent = current.transform;
        }
    }
}
