using UnityEngine;
using System.Collections;

public class ButtonConfig : MonoBehaviour {
    public enum buttonType {Increase, Decrease}
    public float buttonYPosOffset;
    public buttonType typeOfButton;
	// Use this for initialization
	void Start () {
        if (typeOfButton == buttonType.Increase) {
            gameObject.transform.position = new Vector3(gameObject.transform.parent.gameObject.transform.position.x,
                gameObject.transform.parent.gameObject.transform.position.y + buttonYPosOffset,
                gameObject.transform.parent.gameObject.transform.position.z);
        } else {
            gameObject.transform.position = new Vector3(gameObject.transform.parent.gameObject.transform.position.x,
                gameObject.transform.parent.gameObject.transform.position.y - buttonYPosOffset,
                gameObject.transform.parent.gameObject.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnMouseDown() {
        if (typeOfButton == buttonType.Increase) {
            Debug.Log("increase value");
            gameObject.transform.parent.gameObject.GetComponent<Button>().increaseValue();
        } else {
            gameObject.transform.parent.gameObject.GetComponent<Button>().decreaseValue();
            Debug.Log("decrease value");
        }
    }
}
