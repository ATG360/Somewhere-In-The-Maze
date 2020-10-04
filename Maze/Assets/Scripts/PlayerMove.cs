using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10f;

    public float gravity = -9.81f;

    public float JumpHeight = 3f;

    public CharacterController characterController;

    public Animator animator;
    
    Vector3 velocity;

    public Transform point;

    public float radius = 1f;

    public LayerMask ground;

    bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Grounded = Physics.CheckSphere(point.position,radius,ground);
        
        if(Grounded && velocity.y < 0f)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if(x != 0f || z != 0f)
            animator.SetTrigger("Run");
        else
            animator.SetTrigger("Idle");

        Vector3 Move = transform.forward * z + transform.right * x;  

        characterController.Move(Move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && Grounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        characterController.Move(velocity * Time.deltaTime);

        //characterController.Move(velocity)

    }
}
