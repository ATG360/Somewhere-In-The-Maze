using UnityEngine;

public class SpecialCam : MonoBehaviour
{
    public Vector3 Offset;
    public Transform Player;
   
    void Update()
    {
        if(!Player)
            return;
        
        transform.position = Player.position + Offset;
    }
}
