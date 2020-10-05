using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform Player;

    public float DISTANCE_FROM_DOOR = 15f;

    public Vector3 LerpValue;
    
    Vector3 BasePos;

    public bool IsSpecial = false;

    PlayerMove playerMove;


    private void Start() {
        BasePos = transform.position;
        playerMove = Player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player)
            return;

        if(IsSpecial && playerMove.IsHaveKey)
        {
            if(Vector3.Distance(transform.position,Player.position) < DISTANCE_FROM_DOOR)
            {
                transform.position = Vector3.MoveTowards(transform.position,LerpValue,5f * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,BasePos,5f * Time.deltaTime);
            }
            
        }
        else{
            //Not have key
            
        }
        if(!IsSpecial)
        if(Vector3.Distance(transform.position,Player.position) < DISTANCE_FROM_DOOR)
        {
            transform.position = Vector3.MoveTowards(transform.position,LerpValue,5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,BasePos,5f * Time.deltaTime);
        }
    }
}
