﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    private Animator anim; // declare animation stuff value
    private bool PlayMoving; // declare the value of animation of character when moving
    public Vector2 lastMove; // declare the value of character when stopping 
    public float moveSpeed; // set up Speed of the character which can change the speed of character in Inspector > Move Speed
    private static bool PlayerExist;
    private Rigidbody2D myRigidbody; // Rigidbody
    private bool attacking; 
    public float attackTime;
    private float attackTimeCounter;
    public string startPoint;
    public bool canMove;
        // Use this for initialization
    void Start()
    {
        // when character change the map.
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        if(!PlayerExist)
        {
            PlayerExist = true;
            DontDestroyOnLoad(transform.gameObject); // this will keep the character alwayss apear in screen
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayMoving = false;
        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if (!attacking)
        { 
            if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.5f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.5f) // attack in left or right
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigidbody.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed, myRigidbody.velocity.y); // when move to collision object, character will stop on left or right
                PlayMoving = true;
                lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f);


            }

        if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f || CrossPlatformInputManager.GetAxis("Vertical") < -0.5f)// attack in upside or downside
            {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed);// when move to collision object, character will stop on upside or downside
                PlayMoving = true;
                PlayMoving = true;
            lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));

        }
        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0.5f && CrossPlatformInputManager.GetAxis("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (CrossPlatformInputManager.GetAxis("Vertical") < 0.5f && CrossPlatformInputManager.GetAxis("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            attackTimeCounter = attackTime;
            attacking = true;
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("Attack", true);
        }
    }
        if(attackTimeCounter >0)
        {
            attackTimeCounter -= Time.deltaTime;

        }
        if(attackTimeCounter <=0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
        anim.SetFloat("MoveX", CrossPlatformInputManager.GetAxis("Horizontal")); // set character when move left or right
        
        anim.SetFloat("MoveY", CrossPlatformInputManager.GetAxis("Vertical"));// set character when move up or down
        anim.SetBool("PlayMoving", PlayMoving);
        anim.SetFloat("LastMoveX", lastMove.x); // set character when stop left or right
        anim.SetFloat("LastMoveY", lastMove.y);// set character when stop up or down
        
    }
    
}

