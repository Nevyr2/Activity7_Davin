using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(prefab, rooms[Random.Range(0, rooms.Length)].transform.position + new Vector3(Random.insideUnitCircle.x*3.5f, 0.1f, Random.insideUnitCircle.y*3.5f), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }
}
