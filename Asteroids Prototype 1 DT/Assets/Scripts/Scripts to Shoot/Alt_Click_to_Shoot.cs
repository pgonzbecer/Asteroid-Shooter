using UnityEngine;
using System.Collections;

public class Alt_Click_to_Shoot : MonoBehaviour {

    //Drag in the Lazer emitter from the component Inspector
    public GameObject Left_Lazer_Emitter;

    //Drag in the Lazer Prefab from the Component Inspector
    public GameObject Lazer;

    //Enter the speed of the Lazer from the Component Inspector
    public float Lazer_Forward_Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //The Lazer Instantiation happens here
            GameObject Temporary_Lazer_Handler;
            Temporary_Lazer_Handler = Instantiate(Lazer, Left_Lazer_Emitter.transform.position, Left_Lazer_Emitter.transform.rotation) as GameObject;

            //sometimes lazers may appear rotated incorrectly due to the way its pivot was set from the original modeling backage.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Lazer_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Lazer and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Lazer_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Lazer_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Lazer_Forward_Force);

            //Basic Clean Up, set the Lazers to self destruct after 3 seconds
            Destroy(Temporary_Lazer_Handler, 3.0f);


        }
        else if (Input.GetButtonDown("LBumper_Button"))
        {
            //repeat the process for the mouse button

            //The Lazer Instantiation happens here
            GameObject Temporary_Lazer_Handler;
            Temporary_Lazer_Handler = Instantiate(Lazer, Left_Lazer_Emitter.transform.position, Left_Lazer_Emitter.transform.rotation) as GameObject;

            //sometimes lazers may appear rotated incorrectly due to the way its pivot was set from the original modeling backage.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Lazer_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Lazer and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Lazer_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Lazer_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Lazer_Forward_Force);

            //Basic Clean Up, set the Lazers to self destruct after 3 seconds
            Destroy(Temporary_Lazer_Handler, 3.0f);
        }


    }

}
