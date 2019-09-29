using UnityEngine;
using System.Collections;

public class QT_TrafficLight : MonoBehaviour {
    [HideInInspector]
    public Material trafficlightMaterial;
	[HideInInspector]
	public bool showLinks=false;
	[HideInInspector]
	public Color linkColor;
	[HideInInspector]
	public Vector3 controllerPosition;
	[HideInInspector]
	public GameObject[] Lights = new GameObject[3];

	// Use this for initialization
	void Awake () {
       
	}

    void Start()
    {
        
    }
	
	

    public void InitializeTrafficLight()
    {
        foreach (Transform t in transform)
        {
            if (t.name.Equals("Traffic-LightA") || t.name.Equals("Traffic-LightB"))
            {
                trafficlightMaterial = new Material(t.GetComponent<MeshRenderer>().sharedMaterial);
                trafficlightMaterial.SetInt("_RedLight", 0);
                trafficlightMaterial.SetInt("_YellowLight", 0);
                trafficlightMaterial.SetInt("_GreenLight", 0);
                t.GetComponent<MeshRenderer>().sharedMaterial = trafficlightMaterial;
            }
            else if (t.name.Contains("LOD") && trafficlightMaterial)
            {
                t.GetComponent<MeshRenderer>().sharedMaterial = trafficlightMaterial;
            }
            else if (t.name.Equals("Light-BulbGreen"))
                Lights[0] = t.gameObject;
            else if (t.name.Equals("Light-BulbYellow"))
                Lights[1] = t.gameObject;
            else if (t.name.Equals("Light-BulbRed"))
                Lights[2] = t.gameObject;

        }
    }

    public void SetLightValue(int RedOn, int YellowOn, int GreenOn)
    {
        this.trafficlightMaterial.SetInt("_RedLight", RedOn);
        this.trafficlightMaterial.SetInt("_YellowLight", YellowOn);
        this.trafficlightMaterial.SetInt("_GreenLight", GreenOn);
    }
}
