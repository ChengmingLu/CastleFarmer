using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public bool win;
    public bool lose;
    public enum Orientation {Left, Right};
    public static Orientation playerOrientation;
    public Sprite playerSpriteLeft, playerSpriteRight, pistolSpriteLeft, pistolSpriteRight;
    //private float PLAYER_MOVEMENT_BOUND = 40f;
    private bool waitForBasePosition;
    private Vector3 PLAYER_POSITION_OFFSET = new Vector3(5f, -1.5f, 0);
    //public Vector3 PLAYER_SPAWN_OFFSET = new Vector3(0, -3f, 0);
	// Use this for initialization
	void Start () {
        playerOrientation = Orientation.Left;
        win = false;
        lose = false;
        waitForBasePosition = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (waitForBasePosition && Base.isPlayerPositioned) {
            gameObject.transform.position = Base.playerBaseSpawnPosition + PLAYER_POSITION_OFFSET;
            waitForBasePosition = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            playerOrientation = Orientation.Left;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSpriteLeft;
            gameObject.GetComponentInChildren<Pistol>().gameObject.GetComponent<SpriteRenderer>().sprite = pistolSpriteLeft;
            gameObject.GetComponent<Movable>().moveLeft();
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            playerOrientation = Orientation.Right;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSpriteRight;
            gameObject.GetComponentInChildren<Pistol>().gameObject.GetComponent<SpriteRenderer>().sprite = pistolSpriteRight;
            gameObject.GetComponent<Movable>().moveRight();
        } else {
            gameObject.GetComponent<Movable>().stablizePosition();
        }
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("Attacking");
            attack();
        }
	}

    public void attack() {
        if (playerOrientation == Orientation.Left) {
            gameObject.GetComponentInChildren<Pistol>().spawnProjectileLeft();
        } else {
            gameObject.GetComponentInChildren<Pistol>().spawnProjectileRight();
        }
    }


    public void showMenu() {

    }

    public void hideMenu() {

    }
}
