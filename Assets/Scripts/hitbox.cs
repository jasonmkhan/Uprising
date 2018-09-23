using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{

	public int damage = 0;
	private Collider2D col;

	private void Start()
	{
		col = GetComponent<Collider2D>();
	}

	public void ActivateHitbox(int damage)
	{
		this.damage = damage;
		this.col.enabled = true;
	}

	public void DeactivateHitbox()
	{
		this.col.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{

		// try to get the actors that the colliders are a part of
		// it's assumed that the parent of the collider is the actor

		actor myActor = this.GetComponentInParent<actor>();
		actor otherActor = collider.GetComponentInParent<actor>();

		// hurt the other actor
		otherActor.health -= damage;

		if (otherActor.health <= 0)
		{
			Destroy(otherActor.gameObject);
		}

	}

}
