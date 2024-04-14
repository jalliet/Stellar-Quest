using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 5f; // Add this line at the top of your class
    public float damping = 0.2f; 
    public float jumpForce = 0.01f;
    private Rigidbody rb;
    private Vector3 startPosition;

    private Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.drag = 3;
        startPosition = transform.position;

        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
    }
    void FixedUpdate(){
        if (transform.position.y < -4){
            rb.position = startPosition;
            rb.velocity = Vector3.zero;
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        }
        
        Debug.Log("Checking jump conditions");
        Debug.Log(rb.velocity.y);
        Debug.Log(Input.GetKey(KeyCode.Space));
        if(rb.velocity.y < 0.005f && rb.velocity.y > -0.005f && Input.GetKey(KeyCode.Space)){
            Debug.Log("Jumped");
            rb.AddForce(0f, jumpForce, 0f,ForceMode.Impulse);
        }
        

        float userInput = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * 100;
        rb.AddForce(new Vector3(userInput * speed, 0f, 0f), ForceMode.Force);

        if(userInput == 0 && rb.velocity.x != 0){
            rb.velocity += new Vector3((-1*rb.velocity.x*damping), 0f, 0f);
        }
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);

        playerAnimator.SetFloat("Velocity", rb.velocity.x*100);
    } 

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground")) // Check if the collision object has the "Ground" tag
    //    {
    //        foreach (ContactPoint contact in collision.contacts)
    //        {
    //            // Check if the collision is from above
    //            if (contact.normal == Vector3.up)
    //            {
    //                isGrounded = true;
    //                Debug.Log("grounded");
    //                break;
    //            }
    //        }
    //    }
    //}
}
