using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
    public Minion.Identity minionProperty;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z);
	}

    public void takeEffect(Button.buttonType typeOfButton, float deltaValue) {
        switch (typeOfButton) {
            case Button.buttonType.BulletRange:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionPistolbulletRange += deltaValue;
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionPistolbulletRange += deltaValue;
                }
                break;
            case Button.buttonType.BulletSpeed:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionPistolbulletSpeed += deltaValue;
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionPistolbulletSpeed += deltaValue;
                }
                break;
            case Button.buttonType.Damage:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionPistolbulletDamage += Mathf.RoundToInt(deltaValue);
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionPistolbulletDamage += Mathf.RoundToInt(deltaValue);
                }
                break;
            case Button.buttonType.Health:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionHealth += Mathf.RoundToInt(deltaValue);
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionHealth += Mathf.RoundToInt(deltaValue);
                }
                break;
            case Button.buttonType.MoveSpeed:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().spawnedMinionSpeed += deltaValue;
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().spawnedMinionSpeed += deltaValue;
                }
                break;
            case Button.buttonType.MutualVision:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().spawnedMinionVision += Mathf.RoundToInt(deltaValue);
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().spawnedMinionVision += Mathf.RoundToInt(deltaValue);
                }
                break;
            case Button.buttonType.Population:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().populationLimit += Mathf.RoundToInt(deltaValue);
                }
                break;
            case Button.buttonType.RoF:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionPistolRoF += Mathf.RoundToInt(deltaValue);
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionPistolRoF += Mathf.RoundToInt(deltaValue);
                }
                break;
            case Button.buttonType.SpawnInterval:
                if (minionProperty == Minion.Identity.Player) {
                    GameObject.FindGameObjectWithTag("Base").GetComponent<Base>().minionSpawnInterval += deltaValue;
                } else {
                    GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<Base>().minionSpawnInterval += deltaValue;
                }
                break;
            default:
                break;
        }
    }
}
