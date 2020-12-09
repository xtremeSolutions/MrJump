using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject endPortal;
    public Transform destination;

    void Update() {
        destination = endPortal.GetComponent<Transform>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector2(destination.position.x,destination.position.y);
         }
    }
}
