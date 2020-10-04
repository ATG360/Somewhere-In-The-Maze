using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float RunDist = 20f;

    public float AttackDist = 8f;

    public Transform Player;

    public float speed = 15f;

    bool IsFollow = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Player.position) < RunDist || IsFollow)
        {
            if(Vector3.Distance(transform.position,Player.position) < AttackDist)
            {
                //Attack
                Attack();
            }
            else{
                //Run
                Run();
            }   
        }
        else{
            //Be Idle
        }
    }

    void Run()
    {
        animator.SetTrigger("Run");
        IsFollow = true;
        Vector3 Rot = new Vector3(Player.position.x,transform.position.y,Player.position.z);
        transform.LookAt(Rot);
        Vector3 Target = new Vector3(Player.position.x,transform.position.y,Player.position.z);
        transform.position = Vector3.MoveTowards(transform.position,Target,speed * Time.deltaTime);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Run();
        //Attack Animation
        //Attack Logic
    }
}
