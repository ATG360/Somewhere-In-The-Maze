using UnityEngine;

public class SwordPicker : MonoBehaviour
{
    public GameObject Sword;

    public float Radius;

    public LayerMask Player;

    public GameObject SwordUI;
    private void Update() {

        if(Physics.CheckSphere(transform.position,Radius,Player))
        {
            SwordUI.SetActive(true);
            
        }
        else{
            SwordUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.CheckSphere(transform.position,Radius,Player))
            {
                SwordUI.SetActive(false);
                Sword.SetActive(true);
                FindObjectOfType<PlayerAttack>().SwordEnabled = true;
                Destroy(gameObject);
            }
        }
    }

}
