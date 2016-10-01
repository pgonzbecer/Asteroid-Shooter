using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	// Variables
	public float	lookSensitivity=	5f;
	private float	rotX;
	private float	rotY;

	// --- Methods ---

	void Start()
	{
		rotX=	0f;
		rotY=	0f;
		Cursor.lockState=	CursorLockMode.Locked;
	}

	void Update()
	{
		rotX-=	(Input.GetAxis("Mouse Y")*lookSensitivity);
		rotY+=	(Input.GetAxis("Mouse X")*lookSensitivity);
		
		rotX=	Mathf.Clamp(rotX, -90f, 90f);

		transform.rotation=	Quaternion.Euler(rotX, rotY, 0f);
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
