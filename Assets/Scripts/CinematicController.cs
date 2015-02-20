using UnityEngine;
using System.Collections;

public class CinematicController : MonoBehaviour {

	public float speed2 = 100;
	//protected float m_Time;
	public bool cinematic_on = true;
	private float journeyLength;
	private float startTime;
	private Vector3 posStartCinematic;
	private Vector3 posEndCine;

	// Use this for initialization
	void Start () 
	{
		this.posStartCinematic = GameObject.Find ("StartCinematic").transform.position;
		this.transform.position = posStartCinematic;
		this.posEndCine = GameObject.Find ("StartPos").transform.position;
		this.startTime = Time.time;
		journeyLength = Vector3.Distance(posStartCinematic, posEndCine);
	}
	
	// Update is called once per frame
	void Update () {

		if (cinematic_on) {


			float distCovered = (Time.time - this.startTime) * speed2;
			float fracJourney = distCovered / journeyLength;

			this.transform.position = Vector3.Lerp(this.posStartCinematic, this.posEndCine, fracJourney);
			Debug.Log ("cine");
			if (fracJourney >= 1)
				this.cinematic_on = false;				
			}
	}


}
