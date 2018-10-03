using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : actor
{
	public float enemySpeed = 0f;
	private float distToMarker;
	private float distToPlayer;
	private int nextPosition;
	private Rigidbody2D rbody;
	private Animator animator;
	private Transform playerTransform;
	private Transform markerTransform;
	private Transform selfTransform;
	private Vector3 playerPosition;
	private Vector3 direction;
	private Vector3 selfPosition;
	private Vector3 markerPosition;
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
		switch(nextPosition){
			case 0 : //Move Towards Player
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (playerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				distToPlayer = Vector3.Distance(playerPosition, selfPosition);
				if (distToPlayer > 4f) nextPosition = 1;
				break;
			case 1 :
				markerTransform = GameObject.FindWithTag("Marker_001").GetComponent<Transform>();
				markerPosition = markerTransform.position;
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (markerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToMarker = Vector3.Distance(markerPosition, selfPosition);
				distToPlayer = Vector3.Distance(playerPosition, selfPosition);
				if (distToMarker < .1f) nextPosition = 2;
				if (distToPlayer < 4f) nextPosition = 0;
				break;
			case 2 :
			markerTransform = GameObject.FindWithTag("Marker_002").GetComponent<Transform>();
				markerPosition = markerTransform.position;
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (markerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToMarker = Vector3.Distance(markerPosition, selfPosition);
				distToPlayer = Vector3.Distance(playerPosition,selfPosition);
				if (distToMarker < .1f) nextPosition = 3;
				if (distToPlayer < 4f) nextPosition = 0;
				break;
			case 3 :
			markerTransform = GameObject.FindWithTag("Marker_003").GetComponent<Transform>();
				markerPosition = markerTransform.position;
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (markerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToMarker = Vector3.Distance(markerPosition, selfPosition);
				distToPlayer = Vector3.Distance(playerPosition,selfPosition);
				if (distToMarker < .1f) nextPosition = 4;
				if (distToPlayer < 4f) nextPosition = 0;
				break;
			case 4 :
			markerTransform = GameObject.FindWithTag("Marker_004").GetComponent<Transform>();
				markerPosition = markerTransform.position;
				playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
				playerPosition = playerTransform.position;
				selfTransform = GetComponent<Transform>();
				direction = (markerPosition - selfTransform.position).normalized ;
				selfTransform.position += direction * enemySpeed * Time.deltaTime;
				selfPosition = selfTransform.position;
				distToMarker = Vector3.Distance(markerPosition, selfPosition);
				distToPlayer = Vector3.Distance(playerPosition,selfPosition);
				if (distToMarker < .1f) nextPosition = 1;
				if (distToPlayer < 4f) nextPosition = 0;
				break;
		}
		//rbody.MovePosition(playerPosition + velocity * Time.deltaTime);
	}
}
