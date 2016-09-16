using UnityEngine;
using Math=	System.Math;
using System.Collections.Generic;

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
	private Queue<int>	queue=	new Queue<int>();

    // --- Methods ---

    public void spawn()
    {
        GameObject.Instantiate(asteroid, getSpawnPos(), Quaternion.identity, transform);
    }

    public void resetSpawn(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = getSpawnPos();
		startMoving(1);
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

	void addToQueue(int index)
	{
		queue.Enqueue(index);
	}

	public void startMoving(int amt)
	{
		// Variables
		int	n=	0;

		for(int i= 0; i< amt; i++)
		{
			n=	queue.Dequeue();
			moveAsteroid(n);
			queue.Enqueue(n);
		}
	}

	Vector3 getOffsetVector(Vector3 v, float offsetLength)
	{
		// Variables
		float	amount=	(offsetLength*(2f*Random.value-1f));
		Vector3	offset=	amount*(Vector3.Cross(v, Vector3.up).normalized);

		return offset+v;
	}

	void moveAsteroid(int index)
	{
		// Variables
		GameObject	obj=	transform.GetChild(index).gameObject;
        Vector3 movement = new Vector3(-1f*obj.transform.position.x, -1f*obj.transform.position.y, -1f*obj.transform.position.z);
        
		movement=	getOffsetVector(movement, 3.2f);
		movement.Normalize();
        obj.GetComponent<Rigidbody>().AddForce(400f*movement*Random.value);
	}
	
	// --- Scripted Methods ---

	void Start()
	{
        for (int i = 0; i < maxSize; i++)
        {
			spawn();
			addToQueue(i);
        }
		startMoving(10);
	}

    void OnTriggerEnter(Collider col) // This is when it hits the player
    {
        resetSpawn(col.gameObject);
    }

    //collision with lazer 
}
