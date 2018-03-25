using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {


    bool inside = true;
    Animator anim_NPC;
    public Collider Player;
    public GameObject NPC;
    public bool is_attacking = false;


    void Start ()
    {
        anim_NPC = NPC.GetComponent<Animator>();
    }



    void Update()
    {

        if (inside)
        {
            anim_NPC.Play("Jump_Kick_To_Head", -1);
            is_attacking = true;
        }
    }
       

            
	

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
             inside = true;
    }
    private void OnTriggerExit(Collider other)  
    {
        if (other == Player)
            inside = false;
    }
}

