using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_fire : MonoBehaviour
{
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public LayerMask avoid;
    public GameObject bullet;
    public bool can_fire = false;

    Camera fpsCam;

    bool is_fire = false;
    float is_fire_time = 0f;



    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();

    }

    void Update()
    {
        if (!is_fire)
        {

            is_fire = true;


            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;


            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, avoid))
            {
                Instantiate(bullet, gunEnd.position, Quaternion.FromToRotation(Vector3.forward, hit.point - gunEnd.transform.position));

            }
            else
            {
                Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            }

        }

        if (is_fire)
        {
            is_fire_time += Time.deltaTime;
            if (is_fire_time > 2)
            {
                is_fire = false;
                is_fire_time = 0;
            }
        }


    }



}
