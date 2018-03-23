﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed = 10f;
    public GameObject player;
    public GameObject ImpactEffect;
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
            return;

        TriangleExplosion tr = collision.gameObject.GetComponentInChildren<TriangleExplosion>();

        if (collision.gameObject.tag == "ennemi" && tr != null)
        {
            
            tr.dead = true;
            GameObject impact = Instantiate(ImpactEffect, transform.position, Quaternion.LookRotation(transform.position));
            Destroy(impact, 0.3f);
        }

        Destroy(gameObject);
    }
}
