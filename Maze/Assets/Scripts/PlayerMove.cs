using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public bool IsHaveKey = false;
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

    float Health = 100f;

    public Slider slider;

    public GameObject Blood;

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics.CheckSphere(point.position, radius, ground);

        if (Grounded && velocity.y < 0f)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0f || z != 0f)
        {
            animator.SetTrigger("Run");
            if (Grounded)
                audioSource.volume = 1f;
        }

        else
        {
            animator.SetTrigger("Idle");
            audioSource.volume = 0f;
        }

        if (!Grounded)
            audioSource.volume = 0f;

        Vector3 Move = transform.forward * z + transform.right * x;

        characterController.Move(Move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            AudioManager.instance.Play("Jump");
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
        }

        characterController.Move(velocity * Time.deltaTime);

        //characterController.Move(velocity)

        if (Health <= 0f)
        {
            AudioManager.instance.Play("Blood");
            Instantiate(Blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    public void DamagePlayer(float Damage)
    {
        Health -= Damage;
        slider.value = Health;
    }

    private void OnDestroy()
    {
        GameManager.instance.RestartLevel();
    }
}
