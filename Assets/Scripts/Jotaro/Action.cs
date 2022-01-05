using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{


    public GameObject target;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 4f)
        {
            Debug.Log("Работает");
        }
    }

    internal void Invoke()
    {
        throw new NotImplementedException();
    }
}
