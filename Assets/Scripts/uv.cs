using UnityEngine;
using System.Collections;

public class uv : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var uvs = GetComponent<MeshFilter>().mesh.uv;
        foreach(var uv in uvs)
        {
            Debug.LogFormat("uv.x:{0},uv.y:{1}", uv.x, uv.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
