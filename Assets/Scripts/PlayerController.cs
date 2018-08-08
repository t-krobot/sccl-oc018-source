﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;
    public bool canRun = true;
    public GameObject theQuestionHolder;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);//an x and a y value

            if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)) && !theQuestionHolder.active)
            { //need to change to touch screen
                if (grounded)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                }
            }
            myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
            myAnimator.SetBool("Grounded", grounded);
        }
    }

    public void ToggleRunning()
    {
        canRun = !canRun;
    }
}
