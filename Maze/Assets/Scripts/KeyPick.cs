using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPick : MonoBehaviour
{
    public float Radius = 5f;

    public LayerMask Player;

    public GameObject KeyUI;

    void Update()
    {
        if(Physics.CheckSphere(transform.position,Radius,Player))
        {
            KeyUI.SetActive(true);
        }
            else{
                KeyUI.SetActive(false);
            }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.CheckSphere(transform.position,Radius,Player))
            {
                KeyUI.SetActive(false);
                FindObjectOfType<PlayerMove>().IsHaveKey = true;
                Destroy(gameObject);
            }
        }
    }
}
