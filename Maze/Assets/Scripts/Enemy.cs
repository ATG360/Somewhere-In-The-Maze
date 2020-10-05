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

    public float Radius = .4f;

    public LayerMask PlayerMask;

    public float damage = 2f;
    
    private void Awake() {
        Player = GameObject.Find("FPS").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player)
            return;

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
        Physics.CheckSphere(transform.position,Radius,PlayerMask);

            if(Physics.CheckSphere(transform.position,Radius,PlayerMask))
            {
                Player.GetComponent<PlayerMove>().DamagePlayer(damage);                
            }
    }
}
