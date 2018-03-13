using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    Transform tr_Player;
    public Transform enemy;
    float f_RotSpeed = 3f;
    float f_MoveSpeed = 2f;
    bool inside = false;
    Animator anim_NPC;
    public Collider Player;
    public GameObject NPC;
    float near = 0f;
    bool animate = false;
    public bool idle = false;
    // Use this for initialization
    void Start ()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim_NPC = NPC.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (idle)
        {
            anim_NPC.Play("Idle_01", -1);
        }
        else
        {
            if (inside)
            {

                if (!animate)
                {
                    anim_NPC.Play("Running_1", -1);
                    animate = true;
                }

                near += Time.deltaTime;
                if (near > 0.7f)
                {
                    anim_NPC.Play("Jump_Kick_To_Head", -1);
                    near = 0;
                }

                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(tr_Player.position - enemy.transform.position), f_RotSpeed * Time.deltaTime * 2);
                enemy.transform.position += enemy.transform.forward * f_MoveSpeed * Time.deltaTime;
                enemy.transform.position = new Vector3(enemy.transform.position.x, 0.1f, enemy.transform.position.z);
            }
            else
            {
                anim_NPC.Play("Walk_&_Look_Around_2", -1);
                animate = false;
            }
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

