//Uses
using UnityEngine;
using System.Collections;

//Space ship class
public class ZackSpaceShipMove : MonoBehaviour
{

    //Declare publics
    public GameObject gobjSpaceShip;
    public GameObject gobjEnemySpaceShip;
    public int intSpeed;

    //Declare privates
    private int intObjectIndex = 0;
    private float fltTimeLimit = 0f;
    private bool[] ablnTimer = new bool[4];
    private float fltRotation = -45f;
    private bool blnShipDeactivated = false;

    //Update method of Unity
    private void Update()
    {
        //Update time limit
        fltTimeLimit -= Time.deltaTime;
        //Check the ship timer
        CheckShipTimer();
        //Check if need to rotate
        if (ablnTimer[1])
        {
            //Rotate ship if not deactivated
            if (!blnShipDeactivated)
            {
                //Rotate ship
                RotateObject(1, new Vector3(0, 30, fltRotation));
                //Increase rotation
                fltRotation -= 2;
            }
        }
    }

    //Check the asteroid timer to begin another asteroid for moving
    private void CheckShipTimer()
    {
        //Check time limit
        if (!ablnTimer[0])
        {
            //After 1.5 seconds
            if (fltTimeLimit <= -1.5)
            {
                //Set
                ablnTimer[0] = true;
                //Create a space ship
                CreateObjectAndMove(gobjSpaceShip, new Vector3(-17.1f, 0f, -8f), new Vector3(0f, 30f, -45f), new Vector3(-3.34f, 0, 15.83f), intSpeed);
            }
        }
        //Check time limit
        if (!ablnTimer[1])
        {
            //After 2 seconds
            if (fltTimeLimit <= -2)
            {
                //Set
                ablnTimer[1] = true;
            }
        }
        //Check time limit
        if (!ablnTimer[2])
        {
            //After 6 seconds
            if (fltTimeLimit <= -6)
            {
                //Set
                ablnTimer[2] = true;
                //Deactivate the ship
                DeactivateObject(0);
            }
        }
        //Check time limit
        if (!ablnTimer[3])
        {
            //After 7.5 seconds
            if (fltTimeLimit <= -7.5)
            {
                //Set
                ablnTimer[3] = true;
                //Set
                blnShipDeactivated = true;
                //Deactivate the ship
                DeactivateObject(1);
            }
        }
    }

    //Deactivate object
    private void DeactivateObject(int intIndex)
    {
        //Grab object
        GameObject objObject = transform.GetChild(intIndex).gameObject;
        //Deactivate this object
        objObject.SetActive(false);
    }

    //Use this for initialization
    void Start()
    {
        //Create an enemy space ship
        CreateObjectAndMove(gobjEnemySpaceShip, new Vector3(55f, 0f, -20f), new Vector3(0f, -30f, 0f), new Vector3(25f, 0f, 20f), intSpeed + 50);
    }

    //Create space ship
    private void CreateObjectAndMove(GameObject gobjObject, Vector3 v3Spawn, Vector3 v3Rotation, Vector3 v3MoveTo, int intSpeed)
    {
        //Create the object
        GameObject.Instantiate(gobjObject, v3Spawn, Quaternion.identity, transform);
        //Set active incase it is not
        gobjObject.SetActive(true);
        //Move object to location
        MoveObject(intObjectIndex, v3Spawn);
        //Rotate object
        RotateObject(intObjectIndex, v3Rotation);
        //Prepare to move to
        MoveObjectTo(intObjectIndex, v3Spawn, v3MoveTo, intSpeed);
        //Increase
        intObjectIndex += 1;
    }

    //Move object to location
    private void MoveObject(int intIndex, Vector3 v3Spawn)
    {
        //Grab object
        GameObject objObject = transform.GetChild(intIndex).gameObject;
        //Move to location
        objObject.transform.position = v3Spawn;
    }

    //Rotate object
    private void RotateObject(int intIndex, Vector3 v3Rotation)
    {
        //Grab object
        GameObject objObject = transform.GetChild(intIndex).gameObject;
        //Rotate
        objObject.transform.rotation = Quaternion.Euler(v3Rotation);
    }

    //Make object move to
    private void MoveObjectTo(int intIndex, Vector3 v3Spawn, Vector3 v3MoveTo, int intSpeed)
    {
        //Grab object
        GameObject objObject = transform.GetChild(intIndex).gameObject;
        //Declare
        Vector3 v3EndPosition = v3MoveTo - v3Spawn;
        //Normalize the movement
        v3EndPosition.Normalize();
        //Add force to the object
        objObject.GetComponent<Rigidbody>().AddForce(intSpeed * v3EndPosition);
    }

    //                Vector3 PositionV = -14.6f * transform.forward - 5.41f * transform.right;
    //Vector3 PositionV2 = -1f * PositionV - (11.6f * transform.right);

}