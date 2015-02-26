using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class CalculateBoundingBox : MonoBehaviour {

	// Use this for initialization
	void Start () {	


		Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

		MeshFilter[] meshes = GetComponentsInChildren<MeshFilter>();
		for(int i=0; i < meshes.Length; i++)
		{			
			Bounds meshbounds = meshes[i].mesh.bounds;
			bounds.Encapsulate(meshbounds);		
		}

		this.GetComponent<BoxCollider> ().center = bounds.center;
		this.GetComponent<BoxCollider> ().size = bounds.size;

		Debug.Log ((bounds.size*2).ToString());

		this.transform.FindChild ("Zero").transform.position = bounds.center;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
