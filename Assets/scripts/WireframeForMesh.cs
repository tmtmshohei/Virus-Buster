using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireframeForMesh : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh.SetIndices(meshFilter.mesh.GetIndices(0), MeshTopology.Lines, 0);
	}
	

}
