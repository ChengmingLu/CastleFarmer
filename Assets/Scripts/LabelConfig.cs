using UnityEngine;
using System.Collections;

public class LabelConfig : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.position = gameObject.transform.parent.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
