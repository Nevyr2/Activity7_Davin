﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_fire_mv : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 3f;
    bool inside = false;
    public Collider Player;

    private void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime * 2);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            GetComponent<npc_fire>().can_fire = true; 
            inside = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other == Player)
        {
            GetComponent<npc_fire>().can_fire = false;
            inside = false;
        }

    }
}
