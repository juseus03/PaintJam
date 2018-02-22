using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionChild : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponentInParent<SnakeCtrl>().RemoveTail();
        
        if(collision.CompareTag("Persona"))
            gameObject.GetComponentInParent<SnakeCtrl>().AddTail();

        if (collision.CompareTag("Bolardo"))
            gameObject.GetComponentInParent<SnakeCtrl>().RemoveTail();
    }
}
