using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

	public static bool attacking = false;
	private static float attackTimer = 0.2f;
	//adjust anim length here
	private float attackAnimCd =  .3f;
	private float hAnimCd = .6f;
	//adjust cooldown here

	[Range(0.25f, 1.0f)]
	public float coolDown = .6f;
	[Range(0.25f, 1.0f)]
	public float hcoolDown = .7f;

	public int fastAttackDamgae = 1;
	public int heavyAttackDamage = 3;

	private float cd = 0;
	private Animator anim;

	private bool fastAttack = false;
	private bool heavyAttack = false;

	public hitbox tophitbox;
	public hitbox bottomhitbox;
	public hitbox lefthitbox;
	public hitbox righthitbox;
	private hitbox enabledHitbox;

	private playerController playerCont;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		playerCont = gameObject.GetComponent<playerController>();
		//attackTrigger.enabled = false;
	}

	// gets the hitbox based on what direction the player is looking
	private hitbox GetHitbox()
	{
		Direction direction = playerCont.GetDirection();
		hitbox hitbox = null;
		switch (direction)
		{
			case Direction.LEFT: hitbox = lefthitbox; break;
			case Direction.RIGHT: hitbox = righthitbox; break;
			case Direction.UP: hitbox = tophitbox; break;
			case Direction.DOWN: hitbox = bottomhitbox; break;
			default:
				Debug.LogError("Invalid direction, I don't know which hitbox to pick help me");
				break;
		}

		return hitbox;
	}

	// Update is called once per frame
	void Update ()
	{

		// figure out which hitbox we should use if we attack

		if (Input.GetButton("Fire1") && !attacking && cd == 0 && PlayerRoll.rolling == false)
		{
			fastAttack = true;
			attacking = true;
			anim.SetBool("attacking", attacking);
			anim.SetBool("fastAtt", fastAttack);
			attackTimer = attackAnimCd;
			cd = coolDown;
			
			enabledHitbox = GetHitbox();
			enabledHitbox.ActivateHitbox(fastAttackDamgae);
		}
		if (Input.GetButton("Fire3") && !attacking && cd == 0 && PlayerRoll.rolling == false)
		{
			heavyAttack = true;
			attacking = true;
			anim.SetBool("attacking", attacking);
			anim.SetBool("heavyAtt", heavyAttack);
			attackTimer = hAnimCd;
			cd = hcoolDown;

			enabledHitbox = GetHitbox();
			enabledHitbox.ActivateHitbox(heavyAttackDamage);
		}

		if (fastAttack)
		{
			if (attacking)
			{

				if (attackTimer > 0)
				{
					attackTimer -= Time.deltaTime;
				}
				else
				{
					attackTimer = 0;
					attacking = false;
					anim.SetBool("attacking", attacking);
					enabledHitbox.DeactivateHitbox();
					enabledHitbox = null;
					//  attackTrigger.enabled = false;
				}

			}
			if (cd > 0)
			{
				cd -= Time.deltaTime;
			}
			else
			{
				cd = 0;
				fastAttack = false;
				anim.SetBool("fastAtt", fastAttack);
			}
		}
		if (heavyAttack)
		{
			if (attacking)
			{

				if (attackTimer > 0)
				{
					attackTimer -= Time.deltaTime;
				}
				else
				{
					attackTimer = 0;
					attacking = false;
					anim.SetBool("attacking", attacking);
					enabledHitbox.DeactivateHitbox();
					enabledHitbox = null;
					//  attackTrigger.enabled = false;
				}

			}
			if (cd > 0)
			{
				cd -= Time.deltaTime;
			}
			else
			{
				cd = 0;
				heavyAttack = false;
				anim.SetBool("heavyAtt", heavyAttack);
			}
		}
	}
}
