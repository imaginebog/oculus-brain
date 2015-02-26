using UnityEngine;
using System.Collections;

public class LeapBrainController : MonoBehaviour {

	public float GestureDistance;
	public float AngularSpeed;
	public float RotationThreshold;
	public GameObject Target;
	
	protected Vector3 m_OldPosition = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	/*void Update () 
	{
		SkeletalHand hand = GameObject.FindObjectOfType<SkeletalHand>() as SkeletalHand;
		
		if(hand != null && IsGestureDetected(hand))
		{
			DoRotationByGesture(hand);
		}
	}

	bool IsGestureDetected(SkeletalHand hand)
	{
		//get finger bones
		Transform indexBone = hand.transform.GetChild(0).GetChild(2);
		Transform middleBone = hand.transform.GetChild(1).GetChild(2);
		Transform pinkyBone = hand.transform.GetChild(3).GetChild(2);
		Transform ringBone = hand.transform.GetChild(4).GetChild(2);
		Transform thumbBone = hand.transform.GetChild(5).GetChild(2);

		Transform[] fingerBones = new Transform[] {indexBone, middleBone, pinkyBone, ringBone, thumbBone};

		Transform palm = hand.transform.GetChild(2);

		//get average distance from palm
		float distance = Vector3.Distance(thumbBone.position, pinkyBone.position);

		if(distance > GestureDistance)
			return true;
		else
			return false;
	}

	void DoRotationByGesture(SkeletalHand hand)
	{
		Transform palm = hand.transform.GetChild(2);

		if(m_OldPosition == Vector3.zero)
			m_OldPosition = palm.position;

		Vector3 delta = (palm.position - m_OldPosition);

		if(Mathf.Abs(delta.x) > RotationThreshold || Mathf.Abs(delta.y) > RotationThreshold)
			Target.transform.rotation *= Quaternion.AngleAxis(AngularSpeed * Time.deltaTime, delta.normalized);
	}*/
}
