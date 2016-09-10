using UnityEngine;
using Math=	System.Math;

public class AsteroidSpawner : MonoBehaviour {
	// Variables
	public GameObject	asteroid;
	public float	minRadius=	4;
	public float	maxRadius=	10;
	public float	minTheta=	0f;
	public float	maxTheta=	360f;
	public float	minPhi=	0f;
	public float	maxPhi=	180f;
	public int	maxSize=	100;

	// --- Methods ---

	public void spawn()
	{
		// Variables
		Vector3	pos=	getSpawnPos();
		GameObject	obj=	(GameObject)GameObject.Instantiate(asteroid, pos, Quaternion.identity);

		obj.transform.parent=	transform;
	}

	public Vector3 getSpawnPos()
	{
		// Variables
		float	theta=	((float)(Random.value*2*Math.PI)%(toRadians(maxTheta-minTheta)))+toRadians(minTheta);
		float	phi=	((float)(Random.value*Math.PI)%(toRadians(maxPhi-minPhi)))+toRadians(minPhi);
		float	val=	(Random.value*(maxRadius-minRadius)+minRadius);
		
		return new Vector3(
			(float)(Math.Sin(phi)*Math.Cos(theta))*val,
			(float)(Math.Cos(phi))*val,
			(float)(Math.Sin(phi)*Math.Sin(theta))*val
		);
	}

	// Converts the degrees to radians
	private float toRadians(float deg)
	{
		return (deg*((float)Math.PI/180f));
	}
	
	// --- Scripted Methods ---

	void Start()
	{
		for(int i= 0; i< maxSize; i++)
			spawn();
	}
}
