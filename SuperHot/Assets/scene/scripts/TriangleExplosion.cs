using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriangleExplosion : MonoBehaviour {

    public bool dead;
    public GameObject player;
	public IEnumerator SplitMesh (bool destroy)
    {

		if(GetComponent<Collider>())
        {
			GetComponent<Collider>().enabled = false;
		}

		// bake mesh at current animation moment. WARNING: this is costly
		Mesh baked = new Mesh();
		GetComponent<SkinnedMeshRenderer>().BakeMesh(baked);

		Material[] materials = new Material[0];

		materials = GetComponent<SkinnedMeshRenderer>().materials;

		Vector3[] verts = baked.vertices;
		Vector3[] normals = baked.normals;
		Vector2[] uvs = baked.uv;

        for (int submesh = 0; submesh < baked.subMeshCount; submesh++) {

            int[] indices = baked.GetTriangles(submesh);
            for (int i = 0; i < indices.Length; i += 3)
            {
				Vector3[] newVerts = new Vector3[3];
				Vector3[] newNormals = new Vector3[3];
				Vector2[] newUvs = new Vector2[3];
				for (int n = 0; n < 3; n++)
                {
					int index = indices[i + n];
					newVerts[n] = verts[index];
					newUvs[n] = uvs[index];
					newNormals[n] = normals[index];
				}

				Mesh mesh = new Mesh();
				mesh.vertices = newVerts;
				mesh.normals = newNormals;
				mesh.uv = newUvs;

				mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

				GameObject GO = new GameObject("Triangle " + (i / 3));
				GO.layer = LayerMask.NameToLayer("Particle");
				GO.transform.position = transform.position;
				GO.transform.rotation = transform.rotation;
				GO.AddComponent<MeshRenderer>().material = materials[submesh];
				GO.AddComponent<MeshFilter>().mesh = mesh;
				//GO.AddComponent<BoxCollider>();
				GO.AddComponent<Rigidbody> ();
				GO.GetComponent<Rigidbody> ().mass = 0.1f;
				GO.GetComponent<Rigidbody> ().useGravity = true;
				//GO.GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Extrapolate;
				//Vector3 explosionPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Vector3 force = new Vector3 (Random.Range (-500f * Time.timeScale, 500f * Time.timeScale), Random.Range (-500f * Time.timeScale, 500f * Time.timeScale), Random.Range (-500f * Time.timeScale, 500f * Time.timeScale));
				GO.GetComponent<Rigidbody>().AddForce(force);
				Destroy(GO, 1f*Time.timeScale + Random.Range(0.0f, 3*Time.timeScale));
			}
		}
			
		GetComponent<SkinnedMeshRenderer>().enabled = false;

		yield return new WaitForSeconds(0.2f);
        Destroy(transform.parent.gameObject);

    }

	void Awake() {		

	}
	void Update() {
		if (dead)
        {
			Time.timeScale = 0.1f;
			Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
			StartCoroutine(SplitMesh(true));
            dead = false;
		}
    }
}

