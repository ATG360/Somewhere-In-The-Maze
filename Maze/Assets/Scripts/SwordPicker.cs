using UnityEngine;

public class SwordPicker : MonoBehaviour
{
    public GameObject Sword;

    public float Radius;

    public LayerMask Player;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.CheckSphere(transform.position,Radius,Player))
            {
                Sword.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

}
