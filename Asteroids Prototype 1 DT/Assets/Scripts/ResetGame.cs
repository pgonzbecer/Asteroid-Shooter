using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {
    //public variable for the timer on the game over screen
    public static bool gameOver = false;
    //timer, set to 5 seconds
    public float timeLeft = 5.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Right shift resets the game
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Application.LoadLevel("With_Camera_And_Lazers");
        }
        
        //Back button on xbox controller resets the game
        else if (Input.GetButtonDown("Back_Button"))
        {
            Application.LoadLevel("With_Camera_And_Lazers");
        }
        //check for gameover!
        if (gameOver == true)
        {
            //decrement timer
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                //reset the gameover bool and reload game
                gameOver = false;
                Application.LoadLevel("With_Camera_And_Lazers");
            }
        }

    }
}
