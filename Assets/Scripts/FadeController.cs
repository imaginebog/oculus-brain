using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

	public float speed = 10.0f;
	public bool enable = false;
	protected float alpha;

	// Use this for initialization
	void Start () 
	{
		alpha = 0;
		Color c = this.GetComponent<MeshRenderer> ().material.color;
		this.GetComponent<MeshRenderer> ().material.color = new Color(c.r, c.g, c.b, 0); 
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(enable)
		{
			alpha += Time.deltaTime;	
			if(alpha < 1)
			{
				Color c = this.GetComponent<MeshRenderer> ().material.color;
				this.GetComponent<MeshRenderer> ().material.color = new Color(c.r, c.g, c.b, alpha); 
			}
			else
			{
				Application.LoadLevel("Final");
			}
		}
	}
}
