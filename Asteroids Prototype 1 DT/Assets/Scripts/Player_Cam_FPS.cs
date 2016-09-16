using UnityEngine;
using System.Collections;

public class Player_Cam_FPS : MonoBehaviour {
    //set variables
    public float look_Sensitivity = 5f;
    public float x_Rotation;
    public float y_Rotation;

	// Use this for initialization
	void Start () {
		Cursor.lockState=	CursorLockMode.Locked;
	}
    

	// Update is called once per frame
	void Update () {

        //in theory, should start moving the camera
        x_Rotation -= Input.GetAxis("Mouse Y") * look_Sensitivity;
        y_Rotation += Input.GetAxis("Mouse X") * look_Sensitivity;

        //sets a restriciton so camera doesn't go past looking all the
        // way up or down
        x_Rotation = Mathf.Clamp(x_Rotation, -90, 90);

        //I don't know what this does
        transform.rotation = Quaternion.Euler(x_Rotation, y_Rotation, 0);

		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
