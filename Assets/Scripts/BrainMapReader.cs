using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class BrainMapReader : MonoBehaviour {

	public Dictionary<string, string> NamesDict;

	// Use this for initialization
	void Start () {
	
		NamesDict = new Dictionary<string, string> ();
		string[] lines = File.ReadAllLines (@"C:\free_surfer_long_names.txt");

		for(int i=0; i< lines.Length; i++)
		{
			string[] names = lines [i].Trim().Split(':');
			NamesDict.Add(names[0].Trim() + ".vtk", names[1].Trim());	

			//Debug.Log (names[0] + ".vtk");
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
