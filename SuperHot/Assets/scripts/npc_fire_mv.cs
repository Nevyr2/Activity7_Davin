using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_fire_mv : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 3f;
    float f_MoveSpeed = 2f;
    bool inside = false;
    Animator anim_NPC;
    GameObject NPC;
    public Collider Player;

    private void Start()
    {
        NPC = gameObject;
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim_NPC = NPC.GetComponent<Animator>();
    }
    void Update()
    {
        if (inside)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            inside = true;
            anim_NPC.Play("enemi_fire", -1);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other == Player)
            inside = false;
    }
}
