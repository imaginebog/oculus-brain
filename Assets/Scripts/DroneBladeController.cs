using UnityEngine;
using System.Collections;

public class DroneBladeController : MonoBehaviour {

	public float center;
	public float speed = 18;
	Quaternion initial_rot;
	// Use this for initialization
	void Start () {
		initial_rot = Quaternion.Inverse (this.transform.parent.rotation);
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = (this.transform.parent.rotation * initial_rot ) * Vector3.right;
		//Vector3 offset =  Vector3.right;
		this.transform.RotateAround(this.transform.parent.position + center*offset, this.transform.up, speed * Time.deltaTime);
	}
}
