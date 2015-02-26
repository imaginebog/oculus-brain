using UnityEngine;
using System.Collections;

public class BrainMapZoneController : MonoBehaviour {

	public Color ZoneColor = Color.white;
	public string FullName;

	BrainMapReader m_Reader = null;

	// Use this for initialization
	void Start () {
		ZoneColor.b = Random.Range (0, 1.0f);
		ZoneColor.g = Random.Range (0, 1.0f);
		ZoneColor.r = Random.Range (0, 1.0f);
		ZoneColor.a = 0.1f;

		m_Reader = GameObject.FindObjectOfType<BrainMapReader> ();

		this.GetComponent<MeshRenderer> ().material.SetColor("_Color", ZoneColor);
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<MeshRenderer> ().material.SetColor("_Color", ZoneColor);

		if(m_Reader.NamesDict.ContainsKey(this.transform.parent.name))
			this.FullName = m_Reader.NamesDict[this.transform.parent.name];
		else
			this.FullName = this.transform.parent.name.Replace(".vtk",string.Empty);
	}

	void OnTriggerStay(Collider hit)
	{
		if(hit.gameObject.tag == "Player")
			GameObject.Find ("TextZone").GetComponent<SpriteText>().Text = this.FullName;
	}
}
