using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip[] Sounds;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void PlaySound(int sound, float volume = 1)
	{
		this.GetComponent<AudioSource> ().clip = Sounds[sound];
		this.GetComponent<AudioSource> ().volume = volume;
		this.GetComponent<AudioSource> ().Play ();
	}


}
