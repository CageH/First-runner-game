using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;


    private float jumpForce = 8.0f;
    private float gravityModifier = 1.5f;
    private float topBounds = 5.0f;


    private bool isOnGround;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
        if (transform.position.y > topBounds)
        {
            transform.position = new Vector3(transform.position.x, topBounds, transform.position.z);
        }
    }
    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Prefabs"))
        {

        }
    }
}
