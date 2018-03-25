using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject[] rooms;
    public GameObject npc;
    public GameObject npc_fire;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(npc_fire, rooms[Random.Range(0, rooms.Length - 1)].transform.position + new Vector3(Random.insideUnitCircle.x*3.5f, 0.1f, Random.insideUnitCircle.y*3.5f), Quaternion.identity);
        }

        Instantiate(npc, rooms[7].transform.position + new Vector3(Random.insideUnitCircle.x * 3.5f, 0.1f, Random.insideUnitCircle.y * 3.5f), Quaternion.identity);
        Instantiate(npc, rooms[Random.Range(0, rooms.Length - 1)].transform.position + new Vector3(Random.insideUnitCircle.x * 2f, 0.1f, Random.insideUnitCircle.y * 2f), Quaternion.identity);
    }
	// Update is called once per frame
	void Update () {

    }
}
