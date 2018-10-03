using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController2 : actor
{
	public float enemySpeed = 8f;
	private float distToDestination;
	private float distToPlayer;
	private int nextPosition;
	private Rigidbody2D rbody;
	private Animator animator;
	private Transform playerTransform;
	private Transform selfTransform;
	private Vector3 playerPosition;
	private Vector3 direction;
	//private Vector3 destination;
	private Vector3 selfPosition;
	//private Vector2 velocity;

	// Use this for initialization
	void Start ()
	{
		rbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		nextPosition = 0;
		//velocity = new Vector2(1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//PLAN: Stationary
		//If player comes too close, scan which direction player is coming from and hop on opposite side of player
		//Limit to 4 directions, north south east west
		switch(nextPosition){
			case 0 : //Idle
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				selfPosition = selfTransform.position;
				distToPlayer = Vector3.Distance(playerPosition, selfPosition);
				if (distToPlayer < 3f) nextPosition = 1;
				//Debug.Log(nextPosition, gameObject);
				break;
			case 1 :
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (2 * (playerPosition - selfTransform.position)).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToPlayer = Vector3.Distance(playerPosition, selfPosition);
				if (distToPlayer < 3f) nextPosition = 3; //Debug.Log(nextPosition, gameObject);
				break;
			case 2 :
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (playerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToPlayer = Vector3.Distance(playerPosition,selfPosition);
				if (distToPlayer < 3f) nextPosition = 0;
				break;
			case 3 :
				selfTransform = GetComponent<Transform>();
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToDestination = Vector3.Distance(direction, selfPosition);
				if (distToDestination < 5f) nextPosition = 0; //Debug.Log(distToDestination, gameObject);
				break;
		}
		//rbody.MovePosition(playerPosition + velocity * Time.deltaTime);
	}
}
