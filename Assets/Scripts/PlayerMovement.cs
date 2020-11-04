using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update#

    public CharacterController2D controller;
    public Player player;
    public float runSpeed = 40f;

    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ice" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("a");
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }
}
