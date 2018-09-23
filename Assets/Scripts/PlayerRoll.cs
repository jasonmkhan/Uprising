using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour {

    // Use this for initialization
    public static bool rolling = false;



    private float thrust = 5;
    private Rigidbody2D rb2d;
    public Animator anim;
    private float previousX = 0.0f;
    private float previousY = 0.0f;

    //adjust cooldown here
    private float coolDown = 1.5f;
    //adjust anim length here
    private float rollAnimLength=.5f;


    private float rollTimer = 0;
    private float cd = 0;

    private float x;
    private float y;
    private static Vector2 v2;

    private void Start()
    {
        //Store rigidbody information
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //rb2d.mass = .5f;
    }

    // Update is called once per frame
    void Update () {


        
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");


        if (Input.GetButton("Fire2") && !rolling && cd == 0)
        {

            rolling = true;
            anim.SetBool("rolling",rolling);
            if (x== 0&&y==0)
            { 
             v2.x = 1*thrust;
            }
            else
            {
                v2.x = x*thrust;
            }
            v2.y = y*thrust;
            

            rollTimer = rollAnimLength;
            cd = coolDown;
           
        }
        if (rolling)
        {
            rb2d.velocity = v2;
            if (rollTimer > 0)
            {
                rollTimer -= Time.deltaTime;
            }
            else
            {
                rolling = false;
                anim.SetBool("rolling", rolling);
               
            }
        }
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            cd = 0;
        }
    }

}

