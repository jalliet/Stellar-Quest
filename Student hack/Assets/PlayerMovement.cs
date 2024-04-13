using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float speed = 0.1f;
    public float maxSpeed = 5f; // Add this line at the top of your class
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    private Transform transform;
    private GameObject ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.drag = 3;
        transform = GetComponent<Transform>();
        ground = GameObject.Find("Ground");
    }

    void Update()
    {


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("jump");
        }

        
        
    }
    void LateUpdate(){
        Debug.Log("move across");
        float userInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 100;
        rb.AddForce(new Vector3(userInput * speed, 0f, 0f), ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the collision object has the "Ground" tag
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // Check if the collision is from above
                if (contact.normal == Vector3.up)
                {
                    isGrounded = true;
                    Debug.Log("grounded");
                    break;
                }
            }
        }
    }
}
