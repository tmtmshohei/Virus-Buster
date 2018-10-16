using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wireframe : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        SkinnedMeshRenderer meshFilter = GetComponent<SkinnedMeshRenderer>();
        meshFilter.sharedMesh.SetIndices(meshFilter.sharedMesh.GetIndices(0), MeshTopology.Lines, 0);
	}
	

}
