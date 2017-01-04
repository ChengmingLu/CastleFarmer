using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public enum Identity {Enemy, Player};
    public Identity projectileIdentity;
    public int damage;
    public float range;
    public bool onTarget;
    //public static float projectileLifeTime;
    public float touchDownSpeed;
    private float rangeInLifeTime;
	// Use this for initialization
	void Start () {
        rangeInLifeTime = Time.time + range / gameObject.GetComponent<Movable>().speed;
        onTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > rangeInLifeTime ) {
            gameObject.GetComponent<Movable>().touchDown(touchDownSpeed);
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject colliderGameObject = collider.gameObject;
        if (colliderGameObject.GetComponent<Health>() && ((colliderGameObject.GetComponent<Enemy>() && projectileIdentity == Identity.Player
            || colliderGameObject.GetComponent<Player>() && projectileIdentity == Identity.Enemy))) {
            colliderGameObject.GetComponent<Health>().health -= damage;
            //Debug.Log("oh I hit something : " + colliderGameObject);
            gameObject.GetComponent<Movable>().stablizePosition();
            gameObject.transform.parent = collider.transform;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            onTarget = true;
        } else if (colliderGameObject.GetComponent<Ground>()) {
            //Debug.Log("Projectile touch down");
            Destroy(gameObject);
        }
    }   
}
