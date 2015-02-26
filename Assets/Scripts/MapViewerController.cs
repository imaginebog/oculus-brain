using UnityEngine;
using System.Collections;

public class MapViewerController : MonoBehaviour {

	public Texture2D SagitalMap; 
	public Texture2D AxialMap; 
	public Texture2D CurrentSagitalMap;
	public Texture2D CurrentAxialMap;
	public float UpdateTime = 0.5f;
	public int SignalRadio = 30;

	protected GameObject m_Center;
	protected GameObject m_Player;
	protected float m_CurrentTime;
	protected Color[] m_SagitalPixels;
	protected Color[] m_AxialPixels;
	protected int m_CurrentIndexMap;

	// Use this for initialization
	void Start () {
		//
		m_Center = GameObject.Find ("Zero");
		m_Player = GameObject.FindWithTag("Player");

		m_SagitalPixels = SagitalMap.GetPixels ();
		m_AxialPixels = AxialMap.GetPixels ();
	}

	// Update is called once per frame
	void Update () {	

		m_CurrentTime += Time.deltaTime;

		SetViewerMap ();

		if(m_CurrentTime > UpdateTime)
		{		
			m_CurrentTime = 0;
			
			//calculate image bounds in the world coordinates system
			Vector3 imageCenter = new Vector3 (AxialMap.height/2, SagitalMap.height/2, SagitalMap.width/2);
			Vector3 imageSize = new Vector3 (AxialMap.height, SagitalMap.height, SagitalMap.width);
			Bounds imageBound = new Bounds (imageCenter, imageSize);

			//ensure player is inside image bounds
			Vector3 diff = m_Player.transform.position - m_Center.transform.position;

			int i = (int) (imageSize.z - diff.z + imageCenter.z );
			int j = (int) (imageSize.y - diff.y + imageCenter.y);
			int k = (int) (imageSize.x - diff.x + imageCenter.x);

			switch(m_CurrentIndexMap)
			{
				case 0: DrawSagitalMap(i, j); 	break;				
				case 1: DrawAxialMap(i, k); break;
			}
		}				
	}

	void DrawSagitalMap(int i, int j)
	{
		CurrentSagitalMap.SetPixels (m_SagitalPixels);

		DrawPoinOnMap (-i, -j, CurrentSagitalMap);	
	}

	void DrawAxialMap(int i, int k)
	{
		CurrentAxialMap.SetPixels (m_AxialPixels);
		
		DrawPoinOnMap (i, k, CurrentAxialMap);
	}

	void DrawPoinOnMap(int x, int y, Texture2D texture)
	{	
		//Set point on map
		for (int m=-SignalRadio; m <= SignalRadio; m++)						
			for(int n=-SignalRadio; n <= SignalRadio; n++)
		{
			Color c = Color.black;
			
			if(Mathf.Abs(m) > SignalRadio - 5 || Mathf.Abs(n) > SignalRadio - 5)
				c = Color.white;
			
			texture.SetPixel (x + m, y + n, c);				
		}

		texture.Apply ();
	}

	void SetViewerMap()
	{
		if (Input.GetButtonDown ("Map")) 
			m_CurrentIndexMap++;

		if(m_CurrentIndexMap == 2)
			m_CurrentIndexMap = 0;

		switch(m_CurrentIndexMap)
		{
			case 0:
			this.GetComponent<MeshRenderer> ().material.SetTexture("_MainTex", CurrentSagitalMap);
			break;
				
			case 1:
			this.GetComponent<MeshRenderer> ().material.SetTexture("_MainTex", CurrentAxialMap);
			break;
		}

	}
}
