using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public LayerMask avoid;
    public GameObject bullet;

    Animation anim;
    AudioSource audio_fire;

    Camera fpsCam;

    bool is_fire = false;
    float is_fire_time = 0f;



    void Start()
    {
        anim = GameObject.Find("ShooterFPSWeapon").GetComponent<Animation>();
        audio_fire = GameObject.Find("Gun").GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !is_fire)
        {
            
            is_fire = true;
            anim.Play("recul");
            
            audio_fire.enabled = false;
            audio_fire.enabled = true;

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
            if (is_fire_time > anim.clip.length)
            {
                is_fire = false;
                is_fire_time = 0;
            }
        }

    
    }

    

}
