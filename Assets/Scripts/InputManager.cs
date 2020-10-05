using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject ethan;
    public int playerSpeed;
    private Rigidbody rb;
    private Transform ethanTransform;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = ethan.GetComponent<Rigidbody>();
        ethanTransform = ethan.GetComponent<Transform>();
        animator = ethan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        KeyMovement(); 
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJump", true);
        } else
        {
            animator.SetBool("IsJump", false);
        }
    }

    private void KeyMovement()
    {
        float move = Input.GetAxis("Horizontal");
        int sprint = 1;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 2;
        }

        if (move != 0)
        {
            float y = move > 0 ? 90 : -90;
            ethanTransform.eulerAngles = new Vector3(0, y, 0);
            rb.velocity = new Vector3(sprint * playerSpeed * move, rb.velocity.y, rb.velocity.z);
        } else
        {
            rb.velocity = new Vector3(0,0,0);

        }

        animator.SetFloat("Speed", Mathf.Abs(move) * playerSpeed);
    }
}
