using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class CollisionEvents : MonoBehaviour {
    public Text G_O_Test;
	public Mesh[]	meshes=	new Mesh[1];
	public Material[]	materials=	new Material[1];
    public GameObject explosion;

    void Start()
	{
		// Variables
		int	n=	Random.Range(0, meshes.Length);

		GetComponent<MeshFilter>().mesh=	meshes[n];
		GetComponent<MeshRenderer>().material=	materials[n];
		transform.Rotate(2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI, 2f*Random.value*Mathf.PI);
		GetComponent<AudioSource>().enabled=	false;
	}
    
    //destroy asteroid on collission with lazer
    //this script is on the asteroid prefab

    //telling you what is being passed
    //in this case, 'col' represents the passed collision parameter
    void OnTriggerEnter(Collider col)
    {
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
    }

}
