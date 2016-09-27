//Uses
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Collision class
public class CollisionEvents : MonoBehaviour
{

    //Public declares
    public GameObject objSmallerAsteroid;
    public Mesh[] meshes = new Mesh[1];
    public Material[] materials = new Material[1];

<<<<<<< HEAD
    //Private declares
    private const float fltSMALLASTEROIDSEPARATION = 0.25f;
    private float fltTimeLimit = 3f;
    private bool blnCreatedSmallAsteroids = false;

    void Start()
    {
        //Declare
        int n = Random.Range(0, meshes.Length);

        GetComponent<MeshFilter>().mesh = meshes[n];
        GetComponent<MeshRenderer>().material = materials[n];
        transform.Rotate(2f * Random.value * Mathf.PI, 2f * Random.value * Mathf.PI, 2f * Random.value * Mathf.PI);
        GetComponent<AudioSource>().enabled = false;
    }

    //Update method of Unity
    private void Update()
    {
        //Check the asteroid timer
        CheckRemoveSmallAsteroidsTimer();
    }

    //Check the remove small asteroids timer
    private void CheckRemoveSmallAsteroidsTimer()
    {
        //Check if there are asteroids to remove
        if (blnCreatedSmallAsteroids)
        {
            //Update time limit
            fltTimeLimit -= Time.deltaTime;
            //Check time limit
            if (fltTimeLimit <= 0)
            {
                //Remove small asteroids
                for (int intLoop = 0; intLoop < 5; intLoop++)
                {
                    //Remove object
                    RemoveSmallAsteroid(intLoop);
                }
                //Set
                blnCreatedSmallAsteroids = false;
            }
        }
    }
=======
public class CollisionEvents : MonoBehaviour {
    public Text G_O_Test;
	public Mesh[]	meshes=	new Mesh[1];
	public Material[]	materials=	new Material[1];
    public GameObject explosion;

    void Start()
	{
		// Variables
		int	n=	Random.Range(0, meshes.Length);
>>>>>>> master

    private void RemoveSmallAsteroid(int intIndex)
    {
        //Find the small asteroid object
        GameObject objAsteroid = transform.GetChild(intIndex).gameObject;
        //Destroy
        Destroy(objAsteroid);
    }

    //telling you what is being passed
    //in this case, 'col' represents the passed collision parameter
    void OnTriggerEnter(Collider col)
    {
<<<<<<< HEAD

        //if lazer beam enters into the Asteroid BoxCollider
        if (col.tag == "Lazer")
        {

            //Create small asteroids
            CreateSmallAsteroids(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                                 this.gameObject.transform.position.z);

            //destroys the Lazer
            //the lazer is the pass through that triggers the collider trigger event
            Destroy(col.gameObject);

            //destroys the Asteroid
            //this. is the physical object, so in this case, the Asteroid has this script
            Destroy(this.gameObject);

            //Count
            AsteroidSpawner.intKills++;

        }
        else
        {
            //if asteroid hits gun or camera, game over and restart game
            if (col.tag == "Player")
            {
                ////set gameOver to be true to start decrementing the game over timer to reset the game
                //ResetGame.gameOver = true;
            }

        }

    }

    private void CreateSmallAsteroids(float fltX, float fltY, float fltZ)
    {
        //Declare
        Vector3 v3Vector = new Vector3();
        //Show smaller asteroids falling towards player
        for (int i = 0; i < 5; i++)
        {
            //Set
            v3Vector = new Vector3(fltX, fltY, fltZ);
            //Update the vector with some change
            switch (i)
            {
                case 0:
                    v3Vector.x = v3Vector.x + fltSMALLASTEROIDSEPARATION;
                    v3Vector.y = v3Vector.y + fltSMALLASTEROIDSEPARATION;
                    v3Vector.z = v3Vector.z + fltSMALLASTEROIDSEPARATION;
                    break;
                case 1:
                    v3Vector.x = v3Vector.x - fltSMALLASTEROIDSEPARATION;
                    v3Vector.y = v3Vector.y - fltSMALLASTEROIDSEPARATION;
                    v3Vector.z = v3Vector.z - fltSMALLASTEROIDSEPARATION;
                    break;
                case 2:
                    v3Vector.x = v3Vector.x + fltSMALLASTEROIDSEPARATION;
                    v3Vector.y = v3Vector.y - fltSMALLASTEROIDSEPARATION;
                    v3Vector.z = v3Vector.z + fltSMALLASTEROIDSEPARATION;
                    break;
                case 3:
                    v3Vector.x = v3Vector.x - fltSMALLASTEROIDSEPARATION;
                    v3Vector.y = v3Vector.y + fltSMALLASTEROIDSEPARATION;
                    v3Vector.z = v3Vector.z - fltSMALLASTEROIDSEPARATION;
                    break;
                case 4:
                    v3Vector.x = v3Vector.x + fltSMALLASTEROIDSEPARATION;
                    v3Vector.y = v3Vector.y + fltSMALLASTEROIDSEPARATION;
                    v3Vector.z = v3Vector.z - fltSMALLASTEROIDSEPARATION;
                    break;
            }
            //Create smaller asteroid
            GameObject.Instantiate(objSmallerAsteroid, v3Vector, Quaternion.identity);
            //Move this smaller asteroid to the spawn position, sometimes instantiate defaults to 0, 0, 0
            objSmallerAsteroid.transform.position = v3Vector;
            ////Move the smaller asteroid
            //MoveAsteroid(i);
        }
        //Set
        blnCreatedSmallAsteroids = true;
=======
		try {
			//if lazer beam enters into the Asteroid BoxCollider
			if (col.tag== "Lazer")
			{
				//destroys the Lazer
				//the lazer is the pass through that triggers the collider trigger event
				Destroy(col.gameObject);

				//destroys the Asteroid
				//this. is the physical object, so in this case, the Asteroid has this script
				Destroy(this.gameObject);
                Debug.Log("this is when to instantiate explostion");
                Instantiate(explosion, transform.position, transform.rotation);
            }

			//if asteroid hits gun or camera, game over and restart game
			if (col.tag== "Player")
			{
				//set gameOver to be true to start decrementing the game over timer to reset the game
				ResetGame.gameOver = true;

				//message showing game over
				//GameObject.Find("ThePlayer").GetComponent<PlayerScript>().Health -= 10.0f;
				//UnityEngine.UI.Text Game_Over_Text;
				//Game_Over_Text = GetComponent<UnityEngine.UI.Text>();
				//Game_Over_Text.enabled = true;
				//GUIText Game_Over_Text;
				//Game_Over_Text.enabled = true;
				//GetComponent(Game_Over_Text).enabled = true;
				//G_O_Test = GameObject.Find("Game_Over_Text").GetComponent<Text>();
				//G_O_Test.gameObject.Equals(true);
            
			}
		} catch {}
>>>>>>> master
    }

    ////Move the asteroid to player position or offset near player
    //private void MoveAsteroid(int intIndex)
    //{
    //    //Declare
    //    GameObject objAsteroid = transform.GetChild(intIndex).gameObject;
    //    Vector3 v3Movement = new Vector3(//X
    //                                     -1f * objAsteroid.transform.position.x,
    //                                     //Y
    //                                     -1f * objAsteroid.transform.position.y,
    //                                     //Z
    //                                     -1f * objAsteroid.transform.position.z);
    //    //Normalize the movement
    //    v3Movement.Normalize();
    //    //Add force to the object
    //    objAsteroid.GetComponent<Rigidbody>().AddForce(350f * v3Movement);
    //}

}

//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;



//public class CollisionEvents : MonoBehaviour {
//    public Text G_O_Test;
//	public Mesh[]	meshes=	new Mesh[1];
//	public Material[]	materials=	new Material[1];

//	void Start()
//	{
//		// Variables
//		int	n=	Random.Range(0, meshes.Length);

//		GetComponent<MeshFilter>().mesh=	meshes[n];
//		GetComponent<MeshRenderer>().material=	materials[n];
//		transform.Rotate(2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI);
//		GetComponent<AudioSource>().enabled=	false;
//	}

//    //destroy asteroid on collission with lazer
//    //this script is on the asteroid prefab

//    //telling you what is being passed
//    //in this case, 'col' represents the passed collision parameter
//    void OnTriggerEnter(Collider col)
//    {
//		try {
//			//if lazer beam enters into the Asteroid BoxCollider
//			if (col.tag== "Lazer")
//			{
//				//destroys the Lazer
//				//the lazer is the pass through that triggers the collider trigger event
//				Destroy(col.gameObject);

//				//destroys the Asteroid
//				//this. is the physical object, so in this case, the Asteroid has this script
//				Destroy(this.gameObject);
//			}

//			//if asteroid hits gun or camera, game over and restart game
//			if (col.tag== "Player")
//			{
//				//set gameOver to be true to start decrementing the game over timer to reset the game
//				ResetGame.gameOver = true;

//				//message showing game over
//				//GameObject.Find("ThePlayer").GetComponent<PlayerScript>().Health -= 10.0f;
//				//UnityEngine.UI.Text Game_Over_Text;
//				//Game_Over_Text = GetComponent<UnityEngine.UI.Text>();
//				//Game_Over_Text.enabled = true;
//				//GUIText Game_Over_Text;
//				//Game_Over_Text.enabled = true;
//				//GetComponent(Game_Over_Text).enabled = true;
//				//G_O_Test = GameObject.Find("Game_Over_Text").GetComponent<Text>();
//				//G_O_Test.gameObject.Equals(true);

//			}
//		} catch {}
//    }

//}