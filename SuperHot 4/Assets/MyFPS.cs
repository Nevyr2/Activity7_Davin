using UnityEngine;
using System.Collections;

public class MyFPS : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("vertical", Input.GetAxis ("Vertical"));
		anim.SetFloat ("horizontal", Input.GetAxis ("Horizontal"));	
	}
}
