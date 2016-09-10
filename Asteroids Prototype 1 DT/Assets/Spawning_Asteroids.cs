using UnityEngine;
using System.Collections;

public class Spawning_Asteroids : MonoBehaviour {
    //using Paul's Formula
    public float R1;
    public float R2;
    public float R3;
    public float Asteroid;
    public float Max_Asteroids = 50;

    public GameObject Enemy_Asteroid;

	// Use this for initialization
	void Start ()
    {
        
    }

    
	
    //make a collision function to call in the update function
    void OnCollisionEnter(Collision Player_Cam_FPS)
    {

    }

	// Update is called once per frame
	void Update () {
        
	}
}
