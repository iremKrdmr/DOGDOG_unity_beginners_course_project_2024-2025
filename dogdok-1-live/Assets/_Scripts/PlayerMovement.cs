using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float moveSpeed;
    public float jumpForce;
    public bool grounded;

    void Start()
    {

    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } 

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        Vector3 movement = transform.right * moveDirection.x + transform.forward * moveDirection.y;
        movement.y = rigidbody.velocity.y;

        rigidbody.velocity = movement;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
