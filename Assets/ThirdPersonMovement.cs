using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3;

    Vector3 velocity;
    public float turnSmoothVelocity;
    [SerializeField]
    bool isGrounded = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public RaycastHit hit;
    public AudioClip walkingGrass, walkingStone, walkingSand, jump;
    public AudioSource audioSource;

    public Transform cam;
    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();

        //Start Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Jump (if jump is broken make sure you have a ground layer and that the ground is set to that layer)
        if (Input.GetButtonDown("Jump") && isGrounded)
         {
       

            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            audioSource.volume = Random.Range(.05f, .2f);
            audioSource.pitch = Random.Range(.8f, 1.1f);
            audioSource.clip = jump;
            audioSource.Play();

        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Start Walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (isGrounded && controller.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false) {
                if (Physics.Raycast(transform.position, -Vector3.up, out hit, 2.5f))
                {
                    if (hit.collider.gameObject.tag == "Grass")
                    {
                        print ("hitting grass");
                        audioSource.volume = Random.Range(.05f, .2f);
                        audioSource.clip = walkingGrass;
                        audioSource.pitch = Random.Range(.8f, 1.1f);
                        audioSource.Play();
                    }
                    else if (hit.collider.gameObject.tag == "Stone")
                    {
                        print ("hitting stone");
                        audioSource.volume = Random.Range(.05f, .2f);
                        audioSource.pitch = Random.Range(.8f, 1.1f);
                        audioSource.clip = walkingStone;
                        audioSource.Play();
                    }
                }
            }
        }

    }
}
