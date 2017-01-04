using UnityEngine;
using System.Collections;

public class visionControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("entering collision");
        GameObject colliderObject = collider.gameObject;
        if (colliderObject.transform.parent && colliderObject.transform.parent.gameObject.GetComponent<Enemy>() &&
            gameObject.transform.parent.gameObject.GetComponent<Player>()) {
            //Debug.Log("Enemy detected by player");
            //gameObject.transform.parent.gameObject.GetComponent<Movable>().stablizePosition();
            gameObject.transform.parent.gameObject.GetComponent<Minion>().attack();
            gameObject.transform.parent.gameObject.GetComponent<Minion>().enableAIStage1 = false;
            gameObject.transform.parent.gameObject.GetComponent<Minion>().enableAIStage2 = true;
            //gameObject.transform.parent.gameObject.GetComponent<Minion>().minionAIStage2();

            //Debug.Log("AI stage 1 set for player minion");
        } else if (colliderObject.transform.parent && colliderObject.transform.parent.gameObject.GetComponent<Player>() &&
            gameObject.transform.parent.gameObject.GetComponent<Enemy>()) {
            //Debug.Log("Player detected by minion");
            //gameObject.transform.parent.gameObject.GetComponent<Movable>().stablizePosition();
            gameObject.transform.parent.gameObject.GetComponent<Minion>().attack();
            //gameObject.transform.parent.gameObject.GetComponent<Minion>().minionAIStage2();
            gameObject.transform.parent.gameObject.GetComponent<Minion>().enableAIStage1 = false;
            gameObject.transform.parent.gameObject.GetComponent<Minion>().enableAIStage2 = true;
            //Debug.Log("AI stage 1 set for enemy minion");
        } else if (colliderObject.GetComponent<Base>() && colliderObject.GetComponent<Enemy>() &&
            gameObject.transform.parent.gameObject.GetComponent<Player>() ||
            colliderObject.GetComponent<Base>() && colliderObject.GetComponent<Player>() &&
            gameObject.transform.parent.gameObject.GetComponent<Enemy>()) {
            //Debug.Log("Base Found, entering stage 3");
            gameObject.transform.parent.gameObject.GetComponent<Minion>().enterFinalStage();
            Destroy(gameObject.GetComponent<visionControl>());
        } else if (colliderObject.GetComponent<Flag>()) {
            if (gameObject.transform.parent.gameObject.GetComponent<Player>()) {
                colliderObject.GetComponent<Flag>().registerFlagConquest(Minion.Identity.Player);
            } else {
                colliderObject.GetComponent<Flag>().registerFlagConquest(Minion.Identity.Enemy);
            }
        }

        //if (colliderObject.transform.parent && colliderObject.transform.parent.gameObject.GetComponent<Enemy>() &&
        //    gameObject.transform.parent.gameObject.GetComponent<Enemy>() ||
        //    colliderObject.transform.parent && colliderObject.transform.parent.gameObject.GetComponent<Player>() &&
        //    gameObject.transform.parent.gameObject.GetComponent<Player>()) {
        //    Debug.Log("allied ahead");
        //    gameObject.transform.parent.gameObject.GetComponent<Movable>().stablizePosition();
        //    gameObject.transform.parent.gameObject.GetComponent<Minion>().isMoving = false;
        //}
    }

    public void setColliderSize(Vector2 newColliderSize) {
        gameObject.GetComponent<BoxCollider2D>().size = newColliderSize;
    }
}
