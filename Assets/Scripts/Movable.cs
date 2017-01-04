using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float speed;
    public Vector3 destination;
    public bool isMoving;
    public static float leftBaseLimit;
    public static float rightBaseLimit;
    //private Vector3 moveThreshold = new Vector3(2f, 2f, 0);
    //private bool needToMove = false;
    //private bool reachedDestination = false;
	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("Base")) {
            leftBaseLimit = GameObject.FindGameObjectWithTag("Base").transform.position.x;
        } else {
            leftBaseLimit = gameObject.transform.position.x;
            rightBaseLimit = gameObject.transform.position.x;
        }
        if (GameObject.FindGameObjectWithTag("EnemyBase")) {
            rightBaseLimit = GameObject.FindGameObjectWithTag("EnemyBase").transform.position.x;
        } else {
            leftBaseLimit = gameObject.transform.position.x;
            rightBaseLimit = gameObject.transform.position.x;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if ((Mathf.Abs(destination.x - gameObject.transform.position.x) >= moveThreshold.x ||
            //Mathf.Abs(destination.y - gameObject.transform.position.y) >= moveThreshold.y) && needToMove) {
            //if (Math) {

            //}
            //Debug.Log(mousPos + " is mouse position:moving");
            //Debug.Log("in movable: " + destination + " is object position:moving");
            //gameObject.transform.Translate(((destination - 
            //gameObject.transform.position) * speed * Time.deltaTime));
            //move(destination);
        //} else {
            //stop();
            //

        //}
        gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBaseLimit, rightBaseLimit), transform.position.y, transform.position.z);
	}

    public void stablizePosition() {
        destination = gameObject.transform.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
        isMoving = false;
    }

    public void moveLeft() {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left.normalized * speed;
        isMoving = true;
        //reachedDestination = false;
        //needToMove = true;
    }

    public void moveLeft(float speed) {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left.normalized * speed;
        isMoving = true;
    }
    public void moveRight() {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right.normalized * speed;
        isMoving = true;
    }

    public void moveRight(float speed) {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right.normalized * speed;
        isMoving = true;
    }

    public void touchDown(float speed) {
        if (!gameObject.GetComponent<Projectile>().onTarget) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -speed);
        }
    }
    //private void stop() {
        //stablizePosition();
        //needToMove = false;
        //reachedDestination = true;
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
    //}
}
