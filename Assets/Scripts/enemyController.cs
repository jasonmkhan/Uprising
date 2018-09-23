using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : actor
{

	private Rigidbody2D rbody;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		rbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		


	}
}
