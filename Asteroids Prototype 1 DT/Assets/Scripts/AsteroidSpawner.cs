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

    public void spawn(bool canmove)
    {
        // Variables
        Vector3 pos = getSpawnPos();
        GameObject obj = (GameObject)GameObject.Instantiate(asteroid, pos, Quaternion.identity);

        obj.transform.parent = transform;
        if (canmove)
        {
            
            Vector3 movement = ( new Vector3( (-1) * obj.transform.position.x, (-1) * obj.transform.position.y, (-1) * obj.transform.position.z) );
            movement.Normalize();
            obj.GetComponent<Rigidbody>().AddForce(movement * Random.value * 400);
        }
    }

    public void resetSpawn(GameObject obj, bool canmove)
    {
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = getSpawnPos();
        if (canmove)
        {

            Vector3 movement = (new Vector3((-1) * obj.transform.position.x, (-1) * obj.transform.position.y, (-1) * obj.transform.position.z));
            movement.Normalize();
            obj.GetComponent<Rigidbody>().AddForce(movement * Random.value * 2);
        }
    }

    public void update()
    {

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
        int h = 0;
        for (int i = 0; i < maxSize; i++)
        {
            if (Random.value< 0.25f && h< 10)
            {
                h++;
                spawn(true);
            }
            else
            {
                spawn(false);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("HERKADERK");
        resetSpawn(col.gameObject, Random.value< 0.25f);
    }

    //collision with lazer 
}
