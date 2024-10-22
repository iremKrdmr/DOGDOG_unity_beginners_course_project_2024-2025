using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float moveSpeed;

    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;
        Vector3 movement = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.y);

        rigidbody.velocity = movement;

    }
}
