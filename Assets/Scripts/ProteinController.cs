using UnityEngine;
using System.Collections;

public class ProteinController : MonoBehaviour {

	public float randomTime;
	public float speed;
	public string text;

	float currentTime=0;
	float left;
	float up;
	float ford;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		currentTime += Time.deltaTime;

		if(currentTime > randomTime)
		{

			System.Random rand = new System.Random();
			int next = rand.Next (0,6);

			switch (next) 
			{
				case 0: left=1;  up=0; ford=0;	break;
				case 1: left=-1; up=0; ford=0;	break;
				case 2: left=0;  up=1; ford=0;	break;
				case 3: left=0;  up=-1; ford=0;	break;
				case 4: left=0;  up=0; ford=1;	break;
				case 5: left=0;  up=0; ford=-1;	break;
			}

			currentTime = 0;
		}

		//this.transform.Translate(new Vector3(left * speed * Time.deltaTime, up *  speed * Time.deltaTime, ford * speed * Time.deltaTime));
		this.transform.Rotate(new Vector3(left, up, ford), speed * 10 * Time.deltaTime);
	}

}
