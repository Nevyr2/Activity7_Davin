using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touched : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ennemi")
        {
           if (other.GetComponentInParent<NPCMovement>().is_attacking)
                Debug.Log("loose");   
        }
    }

    
}
