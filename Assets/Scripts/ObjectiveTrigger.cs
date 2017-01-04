using UnityEngine;
using System.Collections;

public class ObjectiveTrigger : MonoBehaviour {
    public enum comparison {Greater, Equal, Less}
    //public int playerFlagCount;
    public int playerFlagCountMultiplier;
    //public int enemyFlagCount;
    public comparison operatora;
    public int enemyFlagCountMultiplier;
    public int minimumPlayerFlagPoints;
    public int minimumEnemyFlagPoints;
    private GameObject levelLoader;
    //GameObject flagManagerGameObject;
	// Use this for initialization
	void Start () {
        levelLoader = FindObjectOfType<loadLevel>().gameObject;
        //flagManagerGameObject = FindObjectOfType<FlagManager>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerFlagCountMultiplier >=1 && enemyFlagCountMultiplier >=1 && minimumEnemyFlagPoints > 0 
            && minimumPlayerFlagPoints > 0 && minimumPlayerFlagPoints < FlagManager.playerFlagPoints && 
            minimumEnemyFlagPoints < FlagManager.enemyFlagPoints) {
            switch (operatora) {
                case comparison.Equal:
                    if (FlagManager.playerFlagCount == FlagManager.enemyFlagCount) {
                        triggerVictory();
                    }
                    break;
                case comparison.Greater:
                    if (FlagManager.playerFlagCount > FlagManager.enemyFlagCount) {
                        triggerVictory();
                    }
                    break;
                case comparison.Less:
                    if (FlagManager.playerFlagCount < FlagManager.enemyFlagCount) {
                        triggerVictory();
                    }
                    break;
                default:
                    break;
            }
        }
	}

    void triggerVictory() {
        Debug.Log("to victory");
        levelLoader.GetComponent<loadLevel>().loadNext();
    }
}
