﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;
    public float forwardSpeed = 70;
    public float slideSpeed = 10;
    private const float LANE_DISTANCE = 5;
    public int desiredLane = 1; //0=left ; 1=middle ; 2=right

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
}

    // Update is called once per frame
    void Update()
    {

        //Gather the inputs on which lane we should be
        if (MobileInput.Instance.SwipeLeft)
        {
            SwitchLane(false);
            animator.SetBool("swipeLeft", true);

        }
        if (MobileInput.Instance.SwipeRight)
        {
            SwitchLane(true);
            animator.SetBool("swipeRight", true);

        }

        //move left
        if (Input.GetKeyDown("q"))
        {
            SwitchLane(false);
            animator.SetBool("swipeLeft", true);
        }

        //move right
        if (Input.GetKeyDown("d"))
        {
            SwitchLane(true);
            animator.SetBool("swipeRight", true);
        }

        //Calculate the next position
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }



        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).x * slideSpeed;
        moveVector.z = forwardSpeed;

        //Move the character
        controller.Move(moveVector * Time.deltaTime);

    }

    private void SwitchLane(bool goingRight)
    {
        //avoid player to go outside the three main line
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }


}
