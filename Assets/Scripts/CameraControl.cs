using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float cameraFoV = 5f;
    public float cameraYPosOffset;
    private Vector3 cameraOffset = new Vector3(0f, 2f, -10f);
    //float cameraThreshold = 20f;
    //float cameraBoundary = 400f;
    //float maxCameraFoV = 10f;
    //float minCameraFoV = 5f;
    //float scrollSensitivity = 50f;
    private float boundOfGround = 25f;
    private float cameraYPos;
    Camera cam;
    //Camera cam;
    //float speed = 200f;
    void Start () {
        cameraYPos = transform.position.y + cameraYPosOffset;
        cam = GameObject.FindObjectOfType<Camera>();
	}
	// Update is called once per frame
	void Update () {
        //if (Mathf.Abs(Input.mousePosition.x - Screen.width) <= cameraThreshold
        //    && transform.position.x <= cameraBoundary) {
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);  
        //}
        //if (Input.mousePosition.x <= cameraThreshold
        //    && transform.position.x >= -cameraBoundary) {
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);  
        //}
        //if (Mathf.Abs(Input.mousePosition.y - Screen.height) <= cameraThreshold
        //    && transform.position.y <= cameraBoundary) {
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);  
        //}
        //if (Input.mousePosition.y <= cameraThreshold
        //    && transform.position.y >= -cameraBoundary) {
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);  
        //}


        //cameraFoV -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        //cameraFoV = Mathf.Clamp(cameraFoV, minCameraFoV, maxCameraFoV);
        cam.orthographicSize = cameraFoV;
        if (FindObjectOfType<PlayerControl>()) {
            gameObject.transform.position = FindObjectOfType<PlayerControl>().transform.position + cameraOffset;
        } else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                gameObject.GetComponent<Movable>().moveLeft();
                Debug.LogWarning("Player is missing, camera is taking control by itself");
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                gameObject.GetComponent<Movable>().moveRight();
                Debug.LogWarning("Player is missing, camera is taking control by itself");
            } else {
                //Debug.Log("camera is idle");
                gameObject.GetComponent<Movable>().stablizePosition();
            }
        }
        
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, FindObjectOfType<Ground>().transform.position.x -
            boundOfGround, FindObjectOfType<Ground>().transform.position.x + boundOfGround), cameraYPos, transform.position.z);
        
	}


    bool isCameraOutOfBound() {
        return gameObject.transform.position.x < FindObjectOfType<Ground>().transform.position.x - boundOfGround || gameObject.transform.position.x > FindObjectOfType<Ground>().transform.position.x + boundOfGround;
    }
}
