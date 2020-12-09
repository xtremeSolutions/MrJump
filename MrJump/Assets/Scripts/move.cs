using UnityEngine;

public class move : MonoBehaviour
{
   
    public int moveSpeed = 3;
    
    void Update()
    {
        transform.Translate(Vector3.left * -Time.deltaTime*moveSpeed);
    }
}
