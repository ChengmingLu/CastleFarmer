using UnityEngine;
using System.Collections;

public class TechTree : MonoBehaviour {
    private bool waitForBasePosition;
    private Vector3 TECHTREE_POSITION_OFFSET = new Vector3(-7f, 1.6f, 0);
    
	// Use this for initialization
	void Start () {
        waitForBasePosition = true;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Base.isPlayerPositioned && waitForBasePosition) {
            gameObject.transform.position = Base.playerBaseSpawnPosition + TECHTREE_POSITION_OFFSET;
            waitForBasePosition = false;
        }
	}

    bool isPlayerInRange() {
        return false;
    }

    public void showMenu() {

    }

    public void hideMenu() {

    }
}
