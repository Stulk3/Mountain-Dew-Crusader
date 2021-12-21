using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D JotaroRigidBody;
    
    void Start()
    {
        JotaroRigidBody = this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
}
