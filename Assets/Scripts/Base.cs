using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
    //public Vector3 playerBasePosition = new Vector3(370f, -370f, 0);
    //public Vector3 enemyBasePosition = new Vector3(-370f, 370f, 0);
    public static bool isPlayerPositioned;
    public static bool isEnemyBasePositioned;
    public static Vector3 playerBaseSpawnPosition = new Vector3(0, 0, 0);
    public static Vector3 enemyBaseSpawnPosition = new Vector3(0, 0, 0);
    //public int money;
    public GameObject minion;
    public float spawnedMinionSpeed;
    public int spawnedMinionVision;
    public float minionSpawnInterval;
    public int activeMinions;
    public int populationLimit;
    public float minionPistolRoF;
    public float minionPistolbulletRange;
    public int minionPistolbulletDamage;
    public float minionPistolbulletSpeed;
    public float DEFAULT_MINION_SPAWN_HEIGHT;
    public float minionHealth;
    public Vector3 BASE_SPAWN_OFFSET_PLAYER = new Vector3(-30f, 6.4f, 0);
    public Vector3 BASE_SPAWN_OFFSET_ENEMY = new Vector3(30f, 6.4f, 0);
    private float spawnNext;
    //public int totalAmmo;
    //public int maxAmmo;
	// Use this for initialization
	void Start () {
        isPlayerPositioned = false;
        isEnemyBasePositioned = false;
        //isFullPopulation = false;
        //money = 0;
        spawnNext = 0;
        if (gameObject.GetComponent<Player>()) {
            playerBaseSpawnPosition = FindObjectOfType<Ground>().transform.position + BASE_SPAWN_OFFSET_PLAYER;
            gameObject.transform.position = playerBaseSpawnPosition;
            isPlayerPositioned = true;
        } else {
            enemyBaseSpawnPosition = FindObjectOfType<Ground>().transform.position + BASE_SPAWN_OFFSET_ENEMY;
            gameObject.transform.position = enemyBaseSpawnPosition;
            isEnemyBasePositioned = true;
        }

        randomizeAllParameters();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > spawnNext && activeMinions < populationLimit) {
            spawnNext = Time.time + minionSpawnInterval;
            spawnMinionsDefault();
        }
	}

    public void spawnMinionsDefault() {
        GameObject aMinion = Instantiate(minion, new Vector3(gameObject.transform.position.x, 
            DEFAULT_MINION_SPAWN_HEIGHT, gameObject.transform.position.z), Quaternion.identity) as GameObject;
        aMinion.GetComponent<Movable>().speed = spawnedMinionSpeed;
        aMinion.GetComponent<Minion>().pistolRoF = minionPistolRoF;
        aMinion.GetComponent<Minion>().pistolbulletSpeed = minionPistolbulletSpeed;
        aMinion.GetComponent<Minion>().pistolbulletDamage = minionPistolbulletDamage;
        aMinion.GetComponent<Minion>().pistolbulletRange = minionPistolbulletRange;
        aMinion.GetComponent<Health>().health = minionHealth;
        aMinion.GetComponent<Minion>().minionVision = spawnedMinionVision;
        //aMinion.GetComponent<Minion>().minionAIStage1();
        activeMinions += 1;
    }

    void randomizeAllParameters() {
        spawnedMinionSpeed = Random.Range(spawnedMinionSpeed - 1, spawnedMinionSpeed + 1);
        spawnedMinionVision = Random.Range(spawnedMinionVision - 2, spawnedMinionVision + 2);
        minionSpawnInterval = Random.Range(minionSpawnInterval - 2, minionSpawnInterval + 2);
        populationLimit = Random.Range(populationLimit - 2, populationLimit + 2);
        minionPistolRoF = Random.Range(minionPistolRoF - 2, minionPistolRoF + 2);
        minionPistolbulletRange = Random.Range(minionPistolbulletRange - 2, minionPistolbulletRange + 2);
        minionPistolbulletDamage = Random.Range(minionPistolbulletDamage - 2, minionPistolbulletDamage + 2);
        minionPistolbulletSpeed = Random.Range(minionPistolbulletSpeed - 2, minionPistolbulletSpeed + 2);
        minionHealth = Random.Range(minionHealth - 2, minionHealth + 2);
    }
}
