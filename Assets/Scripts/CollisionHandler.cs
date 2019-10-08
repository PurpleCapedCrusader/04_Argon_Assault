﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        print("CollisionHandler.StartDeathSequence");
        SendMessage("OnPlayerDeath");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
