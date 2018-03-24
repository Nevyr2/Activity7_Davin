using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed;
    public GameObject player;
    public GameObject ImpactEffect;
    public GameObject map;


	void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
	}
    private void OnCollisionEnter(Collision collision)
    {

        TriangleExplosion tr = collision.gameObject.GetComponentInChildren<TriangleExplosion>();

        if (collision.gameObject.tag == "ennemi" && tr != null)
        {
            Debug.Log("loose");
            tr.dead = true;
            GameObject impact = Instantiate(ImpactEffect, transform.position, Quaternion.LookRotation(transform.position));
            Destroy(impact, 0.3f);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("loose");
            GameObject impact = Instantiate(ImpactEffect, transform.position, Quaternion.LookRotation(transform.position));
            Destroy(impact, 0.3f);
            Destroy(gameObject);
        }
    }
}
