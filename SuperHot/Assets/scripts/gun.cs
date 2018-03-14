using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{


    int gunDamage = 5;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public LayerMask avoid;

    Animation anim;
    AudioSource audio_fire;

    public GameObject ImpactEffect;

    Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    private LineRenderer laserLine;

    bool is_fire = false;
    float is_fire_time = 0f;



    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
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

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, avoid))
            {
                laserLine.SetPosition(1, hit.point);

                target Target = hit.transform.GetComponent<target>();
                BoxCollider Target_collider = hit.transform.GetComponent<BoxCollider>();
                if (Target != null)
                {
                    Target.TakeDamage(gunDamage);
                    GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact, 0.5f);

                }
                else
                {
                    Debug.Log("no tatget");
                    laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
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



    private IEnumerator ShotEffect()
    {
        audio_fire.enabled = true;
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}
