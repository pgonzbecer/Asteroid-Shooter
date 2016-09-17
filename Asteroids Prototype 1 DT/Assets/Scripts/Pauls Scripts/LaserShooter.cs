using UnityEngine;
using System.Collections;

public class LaserShooter : MonoBehaviour {
	// Variables
	public GameObject	laser;

	// --- Methods ---

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
			spawnLaser();
	}

	void spawnLaser()
	{
		// Variables
		GameObject	obj=	(GameObject)GameObject.Instantiate(laser);
	}
}
