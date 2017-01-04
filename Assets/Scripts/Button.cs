using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    public Vector3 position;
    public enum buttonType {Health, Damage, MoveSpeed, SpawnInterval, RoF, BulletRange, BulletSpeed, MutualVision, Population}
    public buttonType typeOfButton;
	// Use this for initialization
	void Start () {
        gameObject.transform.position = gameObject.transform.parent.gameObject.transform.position + position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseValue() {

        gameObject.transform.parent.gameObject.GetComponent<ButtonManager>().takeEffect(typeOfButton, +1f);

    }
    public void decreaseValue() {

        gameObject.transform.parent.gameObject.GetComponent<ButtonManager>().takeEffect(typeOfButton, -1f);
    }
}
