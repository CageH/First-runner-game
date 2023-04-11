using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;


    private float jumpForce = 8.0f;
    private float speed = 10.0f;
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
        Move();
        
    }
    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRb.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
