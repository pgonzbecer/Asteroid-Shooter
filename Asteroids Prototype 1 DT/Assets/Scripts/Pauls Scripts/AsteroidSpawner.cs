//Uses
using UnityEngine;
using UnityEngine.UI;
using Math = System.Math;
using System.Collections.Generic;

//Asteroid spawner class
public class AsteroidSpawner : MonoBehaviour
{

    //Global declares
    public static int intKills = 0;

    //Public declares
    public GameObject asteroid;
    public float minRadius = 4;
    public float maxRadius = 10;
    public float minTheta = 0f;
    public float maxTheta = 360f;
    public float minPhi = 0f;
    public float maxPhi = 180f;
    public int maxSize = 100;
    public Text endText;
    public float maxSpeed;

    //Private declares
    private float fltTimeLimit = 5f;
    private int intAsteroidIndex = 1;

    //Start at the beginning of the game
    private void Start()
    {
        //Set static kills, this resets the kills every game
        intKills = 0;
        //Loop to create asteroids
        for (int intLoop = 0; intLoop < maxSize; intLoop++)
        {
            //Create the object into the game object collection
            GameObject.Instantiate(asteroid, v3SpawnPositionWithinASphereShape(), Quaternion.identity, transform);
            //Check for first one
            if (intLoop == 0)
            {
                //Move object
                MoveAsteroid(intLoop);
            }
        }
    }

    //Update method of Unity
    private void Update()
    {
        //Check the asteroid timer
        CheckAsteroidTimer();
    }

    //Check the asteroid timer to begin another asteroid for moving
    private void CheckAsteroidTimer()
    {
        //Update time limit
        fltTimeLimit -= Time.deltaTime;
        //Check time limit
        if (fltTimeLimit <= 0)
        {
            //Declare
            bool blnError = true;
            //Move another asteroid
            while (blnError)
            {
                try
                {
                    //Try to move asteroid
                    MoveAsteroid(intAsteroidIndex);
                    //Successful means no error
                    blnError = false;
                }
                catch
                {
                    //Increase asteroid number
                    intAsteroidIndex += 1;
                }
            }
            //Increase asteroid number
            intAsteroidIndex += 1;
            //Reset time limit
            fltTimeLimit = 5f;
        }
    }

    //Random vector position around the player in a sphere shape
    private Vector3 v3SpawnPositionWithinASphereShape()
    {
        //Declare
        float fltTheta = ((float)(Random.value * 2 * Math.PI) % (fltDegreestoRadians(maxTheta - minTheta))) + fltDegreestoRadians(minTheta);
        float fltPhi = ((float)(Random.value * Math.PI) % (fltDegreestoRadians(maxPhi - minPhi))) + fltDegreestoRadians(minPhi);
        float fltVal = (Random.value * (maxRadius - minRadius) + minRadius);
        //Return
        return new Vector3(//X
                           (float)(Math.Sin(fltPhi) * Math.Cos(fltTheta)) * fltVal,
                           //Y
                           (float)(Math.Cos(fltPhi)) * fltVal,
                           //Z
                           (float)(Math.Sin(fltPhi) * Math.Sin(fltTheta)) * fltVal);
    }

    //Converts degrees to radians
    private float fltDegreestoRadians(float fltDegrees)
    {
        //Return
        return (fltDegrees * ((float)Math.PI / 180f));
    }

    //Move the asteroid to player position or offset near player
    private void MoveAsteroid(int intIndex, bool blnOffsetToPlayer = true)
    {
        //Declare
        GameObject objAsteroid = transform.GetChild(intIndex).gameObject;
        Vector3 v3Movement = new Vector3(//X
                                         -1f * objAsteroid.transform.position.x, 
                                         //Y
                                         -1f * objAsteroid.transform.position.y, 
                                         //Z
                                         -1f * objAsteroid.transform.position.z);
        //Check if move to player or offset
        if (blnOffsetToPlayer)
        {
            //Move towards player but offset
            v3Movement = v3OffsetPositionToPlayer(v3Movement, 3.2f);
        }
        //Normalize the movement
        v3Movement.Normalize();
        //Add force to the object
        objAsteroid.GetComponent<Rigidbody>().AddForce(maxSpeed * v3Movement);
        //Enable audio on asteroid
        objAsteroid.GetComponent<AudioSource>().enabled = true;
    }

    //Get the offset vector so not to hit player with asteroid
    private Vector3 v3OffsetPositionToPlayer(Vector3 v3Vector, float fltOffset)
    {
        //Declare
        float fltAmount = (fltOffset * (2f * Random.value - 1f));
        Vector3 v3Offset = fltAmount * (Vector3.Cross(v3Vector, Vector3.up).normalized);
        //Return
        return v3Offset + v3Vector;
    }

    ////Collision detection with the game collection
    //private void OnTriggerEnter(Collider col)
    //{
    //    //Check for game over first time
    //    if (!blnGameOver)
    //    {
    //        //Update text
    //        endText.text = endText.text + " Asteroid kills: " + intKills;
    //        //Show end game text
    //        endText.enabled = true;
    //        //Set
    //        blnGameOver = true;
    //    }
    //}

    //public void resetSpawn(GameObject obj)
    //{
    //    obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    obj.GetComponent<AudioSource>().enabled=	false;
    //    obj.transform.position = v3SpawnPositionWithinASphereShape();
    //    startMoving(1);
    //}

    //void addToQueue(int index)
    //{
    //    queue.Enqueue(index);
    //}

    //public void startMoving(int amt)
    //{
    //    // Variables
    //    int	n=	0;

    //    for(int i= 0; i< amt; i++)
    //    {
    //        n=	queue.Dequeue();
    //        //moveAsteroid(n);
    //        queue.Enqueue(n);
    //    }
    //}

}

//using UnityEngine;
//using UnityEngine.UI;
//using Math=	System.Math;
//using System.Collections.Generic;

//public class AsteroidSpawner : MonoBehaviour
//{
//    // Variables
//    public GameObject asteroid;
//    public float minRadius = 4;
//    public float maxRadius = 10;
//    public float minTheta = 0f;
//    public float maxTheta = 360f;
//    public float minPhi = 0f;
//    public float maxPhi = 180f;
//    public int maxSize = 100;
//    public Text endText;
//    public float maxSpeed;
//    private Queue<int> queue = new Queue<int>();

//    // --- Methods ---

//    public void spawn()
//    {
//        GameObject.Instantiate(asteroid, getSpawnPos(), Quaternion.identity, transform);
//    }

//    public void resetSpawn(GameObject obj)
//    {
//        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
//        obj.GetComponent<AudioSource>().enabled = false;
//        obj.transform.position = getSpawnPos();
//        startMoving(1);
//    }

//    public Vector3 getSpawnPos()
//    {
//        // Variables
//        float theta = ((float)(Random.value * 2 * Math.PI) % (toRadians(maxTheta - minTheta))) + toRadians(minTheta);
//        float phi = ((float)(Random.value * Math.PI) % (toRadians(maxPhi - minPhi))) + toRadians(minPhi);
//        float val = (Random.value * (maxRadius - minRadius) + minRadius);

//        return new Vector3(
//            (float)(Math.Sin(phi) * Math.Cos(theta)) * val,
//            (float)(Math.Cos(phi)) * val,
//            (float)(Math.Sin(phi) * Math.Sin(theta)) * val
//        );
//    }

//    // Converts the degrees to radians
//    private float toRadians(float deg)
//    {
//        return (deg * ((float)Math.PI / 180f));
//    }

//    void addToQueue(int index)
//    {
//        queue.Enqueue(index);
//    }

//    public void startMoving(int amt)
//    {
//        // Variables
//        int n = 0;

//        for (int i = 0; i < amt; i++)
//        {
//            n = queue.Dequeue();
//            moveAsteroid(n);
//            queue.Enqueue(n);
//        }
//    }

//    Vector3 getOffsetVector(Vector3 v, float offsetLength)
//    {
//        // Variables
//        float amount = (offsetLength * (2f * Random.value - 1f));
//        Vector3 offset = amount * (Vector3.Cross(v, Vector3.up).normalized);

//        return offset + v;
//    }

//    void moveAsteroid(int index)
//    {
//        // Variables
//        GameObject obj = transform.GetChild(index).gameObject;
//        Vector3 movement = new Vector3(-1f * obj.transform.position.x, -1f * obj.transform.position.y, -1f * obj.transform.position.z);

//        movement = getOffsetVector(movement, 3.2f);
//        movement.Normalize();
//        obj.GetComponent<Rigidbody>().AddForce(maxSpeed * movement * Random.value);
//        obj.GetComponent<AudioSource>().enabled = true;
//    }

//    // --- Scripted Methods ---

//    void Start()
//    {
//        for (int i = 0; i < maxSize; i++)
//        {
//            spawn();
//            addToQueue(i);
//        }
//        startMoving(10);
//    }

//    void OnTriggerEnter(Collider col) // This is when it hits the player
//    {
//        resetSpawn(col.gameObject);
//        Debug.Log("ASTEROID HIT");
//        endText.enabled = true;
//    }

//    //collision with lazer 
//}