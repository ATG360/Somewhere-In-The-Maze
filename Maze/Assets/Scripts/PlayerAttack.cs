using UnityEngine;
using System.Collections;
public class PlayerAttack : MonoBehaviour {
    
    public Transform AttackPoint;

    public float Radius = 3f;

    public LayerMask Enemy;

    public Animator animator;
    
    private void Update() 
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attack");

            //Attack Logic
            Collider[] enemies = Physics.OverlapSphere(AttackPoint.position,Radius,Enemy);

            if(enemies != null)
            {
                foreach (Collider C in enemies)
                {
                   StartCoroutine(Destroyer(C.gameObject));
                }
            }

        }
    }

    IEnumerator Destroyer(GameObject GO)
    {
        yield return new WaitForSeconds(.3f);

        Destroy(GO);
    }

}