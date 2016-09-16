using UnityEngine;
using System.Collections.Generic;

public class CollisionEvents : MonoBehaviour {
	// Variables
	public ParticleSystem	explosionSystem;
	public Mesh[]	meshes=	new Mesh[1];
	public Material[]	materials=	new Material[1];

	void Start()
	{
		// Variables
		int	n=	Random.Range(0, meshes.Length);

		GetComponent<MeshFilter>().mesh=	meshes[n];
		GetComponent<MeshRenderer>().material=	materials[n];
		transform.Rotate(2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI);
	}

	void Update()
	{
		if(transform.position.sqrMagnitude> 4900)
		{
			// Variables
			AsteroidSpawner	spawner=	transform.parent.gameObject.GetComponent<AsteroidSpawner>();

			spawner.resetSpawn(gameObject);
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider c)
	{
		try
		{
			switch(c.tag.ToLower())
			{
				case "lazer": { // Asteroid gets hit by lazer and gets destroyed
					// Variables
					AsteroidSpawner	spawner=	transform.parent.gameObject.GetComponent<AsteroidSpawner>();

					spawnExplosion();
					spawner.resetSpawn(gameObject);
				};break;
			}
		} catch {}
	}

	void spawnExplosion()
	{
		
	}
}
