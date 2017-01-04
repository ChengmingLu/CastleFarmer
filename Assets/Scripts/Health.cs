using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Debug.Log(gameObject + " is destroyed with health below 0");
            if (gameObject.GetComponent<Minion>() && gameObject.GetComponent<Player>()) {
                if (GameObject.FindGameObjectWithTag("Base")) {
                    GameObject baseObject = GameObject.FindGameObjectWithTag("Base");
                    baseObject.GetComponent<Base>().activeMinions -= 1;
                }
            } else if (gameObject.GetComponent<Minion>() && gameObject.GetComponent<Enemy>()) {
                if (GameObject.FindGameObjectWithTag("EnemyBase")) {
                    GameObject enemyBaseObject = GameObject.FindGameObjectWithTag("EnemyBase");
                    enemyBaseObject.GetComponent<Base>().activeMinions -= 1;
                }  
            }
            Destroy(gameObject);
        }
	}
}
