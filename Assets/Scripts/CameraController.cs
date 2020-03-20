﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float speed = 100f;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Follow the player
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //Moving alone
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
