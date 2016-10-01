using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {
    // Variables
    public float rotXAmt;
    public float rotYamt;
    public float rotZAmt;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotXAmt, rotYamt, rotZAmt);
	}
}
