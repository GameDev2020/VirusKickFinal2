using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

    }
}

