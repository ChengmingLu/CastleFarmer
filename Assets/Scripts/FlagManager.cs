using UnityEngine;
using System.Collections;

public class FlagManager : MonoBehaviour {
    public enum flagSystemComplexity {Simple, Complex}
    public flagSystemComplexity difficulty;
    public static int playerFlagCount;
    public static int enemyFlagCount;
    public static float playerFlagPoints;
    public static float enemyFlagPoints;
    public Vector3[] flagPositions;
    public GameObject flagPrefab;
    public float flagManagerInitialPositionOffset;
    private Vector3 referenceFlagManagerPosition;
	// Use this for initialization
	void Start () {
        playerFlagCount = 0;
        playerFlagPoints = 0;
        enemyFlagCount = 0;
        enemyFlagPoints = 0;
        Vector3 groundPosition = FindObjectOfType<Ground>().gameObject.transform.position;
        gameObject.transform.position = groundPosition + new Vector3(0, flagManagerInitialPositionOffset, 0);
        referenceFlagManagerPosition = gameObject.transform.position;
        spawnFlags();
	}
	
	// Update is called once per frame
	void Update () {
        playerFlagPoints += Time.deltaTime * playerFlagCount;
        enemyFlagPoints += Time.deltaTime * enemyFlagCount;
        Debug.Log(playerFlagPoints);
        Debug.Log(enemyFlagPoints);
	}

    void spawnFlags() {
        for (int i = 0; i < flagPositions.Length; i++) {
            GameObject tempObject = Instantiate(flagPrefab, flagPositions[i] + referenceFlagManagerPosition, Quaternion.identity) as GameObject;
            tempObject.transform.parent = gameObject.transform;
        }
    }

    public static void logFlagCount() {
        Debug.Log("Player owns " + playerFlagCount + " flag(s)");
        Debug.Log("Enemy owns " + enemyFlagCount + " flag(s)");
    }

    public static void updateFlagOwnership() {
        int playerFlagCounter = 0;
        int enemyFlagCounter = 0;
        GameObject[] tempObjects = GameObject.FindGameObjectsWithTag("Flag");
        
        for (int i = 0; i < tempObjects.Length; i++) {
            //Debug.Log(tempObjects[i].transform.position);
            if (tempObjects[i].GetComponent<Flag>().flagBelongsTo == Flag.Belonging.PlayerFlag) {
                playerFlagCounter += 1;
            } else if (tempObjects[i].GetComponent<Flag>().flagBelongsTo == Flag.Belonging.EnemyFlag) {
                enemyFlagCounter += 1;
            }
        }
        playerFlagCount = playerFlagCounter;
        enemyFlagCount = enemyFlagCounter;
    }
    //public static void incrementFlagCount(Minion.Identity minionIdentity) {
    //    if (minionIdentity == Minion.Identity.Player) {
    //        playerFlagCount += 1;
    //    } else {
    //        enemyFlagCount += 1;
    //    }
    //}
    //public static void decrementFlagCount(Minion.Identity minionIdentity) {
    //    if (minionIdentity == Minion.Identity.Player) {
    //        playerFlagCount -= 1;
    //    } else {
    //        enemyFlagCount -= 1;
    //    }
}
