﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toRight : MonoBehaviour
{
    public float theSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*theSpeed*Time.deltaTime);
        if(transform.position.x==-20)
        {
            Destroy(gameObject);
        }
        
    }
}
