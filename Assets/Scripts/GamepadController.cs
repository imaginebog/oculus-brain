using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GamepadController : MonoBehaviour {

	public float Speed;
	public float AngularSpeed;
	public float ScaleSpeed;
	public float RotationThreshold;
	public GameObject m_ProteinPrefab;

	protected Quaternion m_DeltaOrientantion;
	protected Transform m_InitialRayOrientation;
	protected int m_ProteinCount = 0;
	protected bool m_CreationMode = false;

	public List<Vector3> m_ProteinsPos;


	// Use this for initialization
	void Start () {
		this.GetComponentInChildren<TextMesh> ().text = string.Empty;

		Transform DirectionRay = GameObject.Find("DirectionRay").transform;
		m_InitialRayOrientation = Transform.Instantiate(DirectionRay.transform) as Transform;

		if(File.Exists(@"C:\Users\Imagine\Desktop\proteins.txt"))
		{
			string[] m_data = File.ReadAllLines(@"C:\Users\Imagine\Desktop\proteins.txt");
			foreach(string data in m_data)
			{
				float x = float.Parse(data.Split(';')[0]);
				float y = float.Parse(data.Split(';')[1]);
				float z = float.Parse(data.Split(';')[2]);

				Vector3 pos = new Vector3(x,y,z);

				GameObject protein = GameObject.Instantiate(m_ProteinPrefab, pos, Quaternion.identity) as GameObject;
				protein.transform.parent = GameObject.Find("Proteins").transform;
				m_ProteinCount++;
				protein.GetComponent<ProteinController>().text = m_ProteinCount.ToString();
			}
		}
		m_ProteinCount = Mathf.Min( 10,m_ProteinCount);

		//Transform fordwardDir = GameObject.Find("ForwardDirection").transform;

		Transform OVRCamera = GameObject.Find("OVRCameraController").transform;	
		OVRCamera.GetComponent<OVRCameraController>().SetYRotation(0);

		//OVRDevice ovr_dev = OVRCamera.GetComponent<OVRDevice> ();

		//fordwardDir.transform.rotation = DirectionRay.transform.rotation;
		//OVRCamera.transform.rotation = DirectionRay.transform.rotation;

		//OVRCamera.transform.rotation = DirectionRay.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		Transform fordwardDir = GameObject.Find("ForwardDirection").transform;
		/*
		Transform DirectionRay = GameObject.Find("DirectionRay").transform;
		Transform OVRCamera = GameObject.Find("OVRCameraController").transform;	

		//Vector3 m_LookDirection = DirectionRay.forward - m_InitialRayOrientation.forward;
		//m_LookDirection = m_LookDirection - Vector3.Dot (m_LookDirection, Vector3.up)*Vector3.up;
		float angle = Vector3.Angle (m_InitialRayOrientation.forward, DirectionRay.forward);
		Vector3 delta = DirectionRay.forward - m_InitialRayOrientation.forward;

		//float angle = 0; //Quaternion.Angle (m_RayOrientation, DirectionRay.rotation);
		//Vector3 axis = Vector3.one;
		//m_DeltaOrientantion.ToAngleAxis(out angle, out axis);        
		Debug.Log ("================");
		Debug.Log (angle);
		Debug.Log (delta);
		//Debug.Log (m_InitialRayOrientation.forward);
		//Debug.Log (DirectionRay.forward);
		//Debug.Log (axis);
		//Debug.Log (m_DeltaOrientantion.eulerAngles);
		float abs_delta_x = Mathf.Abs (delta.x);
		float abs_delta_y = Mathf.Abs (delta.y);
		if( abs_delta_x > RotationThreshold)
		{
			fordwardDir.Rotate (Vector3.up* delta.x*(abs_delta_x-RotationThreshold) * AngularSpeed * Time.deltaTime);
			float rot_speed = Mathf.Abs (delta.x*abs_delta_x * AngularSpeed);
			Debug.Log(rot_speed);
			//this.transform.Rotate(Vector3.up, AngularSpeed * delta.x * Time.deltaTime);
		}
		if(abs_delta_y > RotationThreshold)
		{
			fordwardDir.Rotate (Vector3.right * delta.y *(abs_delta_y-RotationThreshold)* (-AngularSpeed) * Time.deltaTime);
			//this.transform.Rotate(Vector3.forward, AngularSpeed * delta.y * Time.deltaTime);
		}

		//else
			//fordwardDir.rotation = DirectionRay.rotation;
		*/
		float direction = 1;
		float drone_speed = 0;

		// left hand, movement and pan
		{
			uint i = 0;
			if ( SixenseInput.Controllers[i] != null )
			{						
	
				if(SixenseInput.Controllers[i].JoystickY != 0)
				{
					direction = SixenseInput.Controllers[i].JoystickY;
					this.GetComponent<CharacterController>().Move(fordwardDir.forward * direction * Speed * Time.deltaTime);
					drone_speed = Mathf.Abs(direction);
				}
				if(SixenseInput.Controllers[i].JoystickX != 0)
				{
					direction = SixenseInput.Controllers[i].JoystickX;
					this.GetComponent<CharacterController>().Move(fordwardDir.right * direction * Speed * 0.5f*  Time.deltaTime);
				}
				if(SixenseInput.Controllers[i].Trigger == 1)
				{
					direction = 1;
					this.GetComponent<CharacterController>().Move(fordwardDir.forward * direction * Speed * Time.deltaTime);
				}

				if(false && SixenseInput.Controllers[i].JoystickY != 0)
				{
					direction = SixenseInput.Controllers[i].JoystickY;
					this.GetComponent<CharacterController>().Move(fordwardDir.forward * direction * Speed * Time.deltaTime);
				}

				if(false && SixenseInput.Controllers[i].GetButtonUp(SixenseButtons.FOUR))
				{
					m_CreationMode = !m_CreationMode;
					this.ShowText(m_CreationMode ? "Modo de creacion encendido" : "Modo de creacion apagado");
				}
				/*
				if(false && SixenseInput.Controllers[i].GetButtonUp(SixenseButtons.START))
				{
					//DestroyObject(m_InitialRayOrientation);
					m_InitialRayOrientation.position = DirectionRay.transform.position;
					m_InitialRayOrientation.localScale = DirectionRay.transform.localScale;
					m_InitialRayOrientation.rotation = DirectionRay.transform.rotation;

					//fordwardDir.transform.rotation = DirectionRay.transform.rotation;
					//OVRCamera.transform.rotation = DirectionRay.transform.rotation;
				}
*/
				if(m_CreationMode && SixenseInput.Controllers[i].GetButtonDown(SixenseButtons.ONE))
				{
					Vector3 pos = GameObject.Find("TopDrone").transform.position + this.transform.forward*3 - this.transform.up*2;
					GameObject protein = GameObject.Instantiate(m_ProteinPrefab, pos, Quaternion.identity) as GameObject;
					protein.transform.parent = GameObject.Find("Proteins").transform;
					m_ProteinCount++;
					protein.GetComponent<ProteinController>().text = m_ProteinCount.ToString();

					m_ProteinsPos.Add(protein.transform.position);
					SavePositions();
				}

				if(SixenseInput.Controllers[i].GetButtonUp(SixenseButtons.ONE))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
		// right hand, elevation
		{
			uint i = 1;
			if (SixenseInput.Controllers [i] != null) {		
			if (true && SixenseInput.Controllers [i].JoystickY != 0) {
				direction = SixenseInput.Controllers [i].JoystickY;
				this.transform.Rotate(Vector3.right*Time.deltaTime*AngularSpeed*direction*Mathf.Abs(direction));
			}
			if (SixenseInput.Controllers [i].JoystickX != 0) {
				// left -> right : -1 -> 1
				direction = SixenseInput.Controllers [i].JoystickX;
				this.transform.Rotate(Vector3.up*Time.deltaTime*AngularSpeed*direction*Mathf.Abs(direction));
				//this.transform.Rotate(Vector3.up, AngularSpeed * direction * Time.deltaTime);
			}

		}
		}

		float min_distance = float.MaxValue;
		int index_nearest=-1;
		GameObject proteins = GameObject.Find ("Proteins");
		//Debug.Log ("Proteins");
		for(int i=0; i < proteins.transform.childCount; i++)
		{
			Transform protein = proteins.transform.GetChild(i);
			float distance = Vector3.Distance(this.transform.position, protein.position);
			//Debug.Log(i);
			//Debug.Log(distance);
			if(distance < min_distance){
				index_nearest = i;
				min_distance = distance;
			}

		}
		//Debug.Log(index_nearest);
		if(index_nearest != -1)
		{
			Transform source = GameObject.Find("TopDrone").transform;
			Transform nearest = proteins.transform.GetChild (index_nearest);
			this.GetComponent<LineRenderer>().SetPosition(0, source.position);
			this.GetComponent<LineRenderer>().SetPosition(1, nearest.position);
		}

		//m_RayOrientation = DirectionRay.rotation;
		//this.GetComponentInChildren<AudioSource> ().pitch = 1.0f + drone_speed/0.5f;
		GameObject.Find("PA_Drone").GetComponent<AudioSource> ().pitch = 1.0f + drone_speed/0.5f;
	}

	void OnTriggerEnter(Collider hit)
	{
		if (!m_CreationMode && hit.gameObject.tag == "Protein") 
		{
			this.GetComponent<SoundController>().PlaySound(0);

			m_ProteinCount--;
			this.StartCoroutine(ShowText(m_ProteinCount.ToString()));
			DestroyObject(hit.gameObject, Time.deltaTime);

			if (m_ProteinCount <= 0){

				GameObject drone = GameObject.Find("PA_Drone");
				drone.SetActive(false);

				GameObject fadePlane = GameObject.Find("FadePlane") as GameObject;
				fadePlane.GetComponent<FadeController>().enable = true;

				this.GetComponent<SoundController>().PlaySound(1);
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Wall")
		{
			Debug.Log("Colision!!");
			GameObject.Find("ForwardDirection").GetComponent<AudioSource>().Play();
		}
	}

	void SavePositions()
	{
		List<string> posProteins = new List<string> ();
		for(int i=0; i < m_ProteinsPos.Count; i++)
			posProteins.Add(string.Format("{0};{1};{2}", m_ProteinsPos[i].x, m_ProteinsPos[i].y, m_ProteinsPos[i].z)); 

		File.WriteAllLines (@"C:\Users\Imagine\Desktop\proteins.txt", posProteins.ToArray());
		Debug.Log ("guardado" + posProteins.Count.ToString());
	}



	IEnumerator ShowText(string text)
	{	
		this.GetComponentInChildren<TextMesh> ().text = text;
		yield return new WaitForSeconds (5);
		this.GetComponentInChildren<TextMesh> ().text = string.Empty;
	}
}

