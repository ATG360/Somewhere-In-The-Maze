using UnityEngine;
using System.Collections;
public class PlayerAttack : MonoBehaviour {
    
    public Transform AttackPoint;

    public float Radius = 3f;

    public LayerMask Enemy;

    public Animator animator;

    public GameObject Blood;
    
    public bool SwordEnabled = false;
    private void Update() 
    {
        
        if(Input.GetMouseButton(0) && SwordEnabled)
        {
            animator.SetTrigger("Attack");
            AudioManager.instance.Play("Sword");
            //Attack Logic
            Collider[] enemies = Physics.OverlapSphere(AttackPoint.position,Radius,Enemy);

            if(enemies != null)
            {
                foreach (Collider C in enemies)
                {
                    AudioManager.instance.Play("Blood");
                    Instantiate(Blood,C.transform.position,Quaternion.identity);
                    Destroy(C.gameObject);
                }
            }

        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(AttackPoint.position,Radius);
    }
}