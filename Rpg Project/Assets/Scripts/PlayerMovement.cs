using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpVelocity = 10f;
    bool grounded;
    Vector3 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        transform.position += movement * MovementSpeed * Time.deltaTime;
        jump();
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
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
