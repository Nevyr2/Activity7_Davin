using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touched : MonoBehaviour
{
    public bool loose = false;
    Animation anim;
    private float time = 0;
    Rigidbody rb;
    private void Start()
    {
        anim = GetComponent<Animation>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (loose)
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            anim.Play("die");
            time += Time.deltaTime;
            if (time > 3)
                Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
            //if (other.GetComponentInParent<NPCMovement>().is_attacking)
            GetComponent<time_slow>().dead = true;
            loose = true;
        }
    }

}
