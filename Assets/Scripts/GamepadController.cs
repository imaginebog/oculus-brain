using UnityEngine;
using System.Collections;

public class GamepadController : MonoBehaviour {

	public float MotionSpeed;
	public float AngularSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetAxis("Horizontal") != 0)
			this.GetComponent<CharacterController>().Move(Input.GetAxis("Horizontal") * this.transform.right * MotionSpeed * Time.deltaTime);

		if(Input.GetAxis("Vertical") != 0)
			this.GetComponent<CharacterController>().Move(Input.GetAxis("Vertical") * this.transform.forward * MotionSpeed * Time.deltaTime);

		if (Input.GetAxis ("Horizontal2") != 0)
			this.transform.Rotate (this.transform.up, Input.GetAxis("Horizontal2") * AngularSpeed * Time.deltaTime);

		if(Input.GetAxis("Vertical2") != 0)
			this.transform.Rotate (this.transform.right, Input.GetAxis("Vertical2") * AngularSpeed * Time.deltaTime);

	}
}
