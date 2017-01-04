using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {
    public int minionVision;
    public enum Orientation {Left, Right};
    public enum Identity {Player, Enemy};
    public Orientation minionOrientation;
    public Identity minionIdentity;
    public Sprite pistolSpriteLeft;
    public Sprite pistolSpriteRight;
    public bool enableAIStage1;
    public bool enableAIStage2;
    public float pistolRoF;
    public float pistolbulletRange;
    public int pistolbulletDamage;
    public float pistolbulletSpeed;
    private const float DEFAULT_Y_SIZE = 0.5f;
    private float nextSwitchToStage1;
    private float nextSwitchToStage2;
    private bool concentrateFire;
    private float minionEscapeSpeed;
	// Use this for initialization
	void Start () {
        minionEscapeSpeed = gameObject.GetComponent<Movable>().speed * 1.5f;
        gameObject.GetComponentInChildren<Pistol>().RoF = pistolRoF;
        gameObject.GetComponentInChildren<Pistol>().bulletDamage = pistolbulletDamage;
        gameObject.GetComponentInChildren<Pistol>().bulletRange = pistolbulletRange;
        gameObject.GetComponentInChildren<Pistol>().bulletSpeed = pistolbulletSpeed;
        nextSwitchToStage1 = 0;
        nextSwitchToStage2 = 0;
        if (gameObject.GetComponent<Player>()) {
            minionOrientation = Orientation.Right;
            minionIdentity = Identity.Player;
        } else if (gameObject.GetComponent<Enemy>()) {
            minionOrientation = Orientation.Left;
            minionIdentity = Identity.Enemy;
        }
        enableAIStage1 = true;
        enableAIStage2 = false;
        concentrateFire = false;
        gameObject.GetComponentInChildren<visionControl>().setColliderSize(new Vector2(minionVision, DEFAULT_Y_SIZE));
	}
	
	// Update is called once per frame
	void Update () {
        if (minionOrientation == Orientation.Left) {
            gameObject.GetComponentInChildren<Pistol>().gameObject.GetComponent<SpriteRenderer>().sprite = pistolSpriteLeft;
        } else {
            gameObject.GetComponentInChildren<Pistol>().gameObject.GetComponent<SpriteRenderer>().sprite = pistolSpriteRight;
        }
        if (enableAIStage1 && !enableAIStage2) {
            minionAIStage1();
        } else if (!enableAIStage1 && enableAIStage2) {
            minionAIStage2();
        } else if (concentrateFire) {
            attack();
        }
	}

    public void attack() {
        if (minionOrientation == Orientation.Left) {
            gameObject.GetComponentInChildren<Pistol>().spawnProjectileLeft();
        } else {
            gameObject.GetComponentInChildren<Pistol>().spawnProjectileRight();
        }
    }

    public void minionAIStage1() {
        if (Time.time > nextSwitchToStage2) {
            float randomTime = Random.Range(4, 8);
            Debug.Log(minionIdentity + " in stage 1 and random time of " + randomTime );
            nextSwitchToStage2 = Time.time + randomTime;
            if (gameObject.GetComponent<Player>()) {
                gameObject.GetComponent<Movable>().moveRight();
            //minionOrientation = Orientation.Right;
            } else {
                gameObject.GetComponent<Movable>().moveLeft();
            //minionOrientation = Orientation.Left;
            }
        }        
    }
    public void minionAIStage2() {
        if (Time.time > nextSwitchToStage1) {
            float randomTime = Random.Range(4, 8);
            Debug.Log(minionIdentity + " in stage 2 and random time of " + randomTime );
            nextSwitchToStage1 = Time.time + randomTime;
            //float tempTIme = Time.time + Random.Range(1, 4);
            //while (Time.time < tempTIme) {
                //Debug.Log("time is less then temp time: " + tempTIme);
                //Debug.Log(Time.time);
            if (gameObject.GetComponent<Player>()) {
                gameObject.GetComponent<Movable>().moveLeft(minionEscapeSpeed);
                //minionOrientation = Orientation.Left;
            } else {
                gameObject.GetComponent<Movable>().moveRight(minionEscapeSpeed);
                //minionOrientation = Orientation.Right;
            }
            //}
            
        }
        enableAIStage2 = false;
        enableAIStage1 = true;
    }

    public void enterFinalStage() {
        enableAIStage1 = false;
        enableAIStage2 = false;
        gameObject.GetComponent<Movable>().stablizePosition();
        concentrateFire = true;
    }
}
