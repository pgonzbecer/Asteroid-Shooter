﻿using UnityEngine;
using System.Collections;

public class Rotation_Script : MonoBehaviour {
    public float tumble;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
