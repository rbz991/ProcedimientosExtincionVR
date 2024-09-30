using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float lifetime = 20f;
    public byte bulletID;
    void Start()
    {
       
        Destroy(gameObject, lifetime);
     
    }

   
}
