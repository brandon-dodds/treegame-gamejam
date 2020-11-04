using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isJump;
    public float jumpForce;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

    }
}
