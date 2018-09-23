using UnityEngine;
using System.Collections;

public enum Direction
{
	UP,
	DOWN,
	LEFT,
	RIGHT
}

public class playerController : actor
{
	//
	public static bool moving = false;
	//adjust speed here
	public float speed = 2.0f;
	//speed when attacking
	public float slowdownSpeed = .5f;

	private float previousX = 0.0f;
	private float previousY = 0.0f;

	private Rigidbody2D rb2d;
	private Animator anim;

	public Direction GetDirection()
	{
		if (previousX > 0.5f)
		{
			return Direction.RIGHT;
		}
		else if (previousX < -0.5f)
		{
			return Direction.LEFT;
		}
		else if (previousY > 0.5f)
		{
			return Direction.UP;
		}
		else
		{
			return Direction.DOWN;
		}
	}

    private void Start()
    {
        //Store rigidbody information
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

		float x;
		float y;

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        moving = (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f);

        if (moving)
        {
            previousX = x;
            previousY = y;
        }
        
        anim.SetFloat("directionX", previousX);
        anim.SetFloat("directionY", previousY);
        anim.SetBool("moving", moving);
       
        if (PlayerAttack.attacking == true)
        {
            speed = slowdownSpeed;
        }
        else
        {
            speed = 2.0f;
        }

        Vector2 velocity;
        velocity.x = x * speed;
        velocity.y = y * speed;

        if (PlayerRoll.rolling == false)
        {
            rb2d.velocity = velocity;
        }

        
    }
    

}
