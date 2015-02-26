using UnityEngine;
using System;
using System.Collections;

public class LeapShipController : MonoBehaviour {

	public float MotionSpeed;
	public float AngularSpeed;
	public float MotionThreshold;
	public float RotationThreshold;

	Vector3[] m_HandBones;
	Vector3 m_PalmPreviousPos = Vector3.zero;
	Vector3 m_PalmCurrentPos = Vector3.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
/*	void Update () {
	
		SkeletalHand hand = GameObject.FindObjectOfType<SkeletalHand> ();

		if(hand != null)
		{
			Vector3 indexBone = hand.transform.GetChild(0).GetChild(2).position;
			Vector3 middleBone = hand.transform.GetChild(1).GetChild(2).position;
			Vector3 pinkyBone = hand.transform.GetChild(3).GetChild(2).position;
			Vector3 ringBone = hand.transform.GetChild(4).GetChild(2).position;
			Vector3 thumbBone = hand.transform.GetChild(5).GetChild(2).position;
			Vector3 palmBone = hand.transform.GetChild(2).position;
			m_HandBones = new Vector3[]{indexBone, middleBone, pinkyBone, ringBone, thumbBone, palmBone };

			m_PalmPreviousPos = hand.transform.GetChild(2).position;
		}

		if(m_HandBones 	!= null)
		{
			RunGesture();
			RotationGesture();
		}
	}

	void RunGesture()
	{
		//claculate average distance between fingers
		foreach(Vector3 bone in m_HandBones)
		{
			Vector3 thumb = m_HandBones[Convert.ToInt32(EHandFinger.Thumb)];
			Vector3 pinky = m_HandBones[Convert.ToInt32(EHandFinger.Pinky)];

			float dist = Vector3.Distance(thumb, pinky);
			float speed = 0;
			if(dist > MotionThreshold)
				speed =  MotionSpeed * dist;
			else
				speed = 0;

			this.GetComponent<CharacterController>().Move(this.transform.forward * speed * Time.deltaTime); 
		}
	}

	void RotationGesture()
	{

	}*/
	

}

enum EHandFinger
{
	Index,
	Middle,
	Pinky,
	Ring,
	Thumb,
	Palm
}
