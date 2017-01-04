using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    public enum Belonging { PlayerFlag, EnemyFlag, NotOwned }
    public Belonging flagBelongsTo;
    public Sprite notOwnedSprite;
    public Sprite ownedByPlayerSprite;
    public Sprite ownedByEnemySprite;
	// Use this for initialization

	void Start () {
        flagBelongsTo = Belonging.NotOwned;
        changeFlagSprite(notOwnedSprite);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void registerFlagConquest(Minion.Identity minionIdentity) {
        if (minionIdentity == Minion.Identity.Enemy) {
            switch (flagBelongsTo) {
                case Belonging.PlayerFlag: {
                        flagBelongsTo = Belonging.EnemyFlag;
                        changeFlagSprite(ownedByEnemySprite);
                        break;
                }
                case Belonging.EnemyFlag: break;
                default: {
                        flagBelongsTo = Belonging.EnemyFlag;
                        changeFlagSprite(ownedByEnemySprite);
                        break;
                }
            }  
        }
        if (minionIdentity == Minion.Identity.Player) {
            switch (flagBelongsTo) {
                case Belonging.PlayerFlag: break;
                case Belonging.EnemyFlag: {
                        flagBelongsTo = Belonging.PlayerFlag;
                        changeFlagSprite(ownedByPlayerSprite);
                        break;
                    }
                default: {
                        flagBelongsTo = Belonging.PlayerFlag;
                        changeFlagSprite(ownedByPlayerSprite);
                        break;
                    }
            }   
        }
        FlagManager.updateFlagOwnership();
        //FlagManager.logFlagCount();
    }
    private void changeFlagSprite(Sprite flagSprite) {
        gameObject.GetComponent<SpriteRenderer>().sprite = flagSprite;
    }
}
