using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class TriangleMaker : MonoBehaviour
{
	[SerializeField]
	private Vector3 size = Vector3.one;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		MeshFilter meshFilter = this.GetComponent<MeshFilter>();
		MeshBuilder meshBuilder = new MeshBuilder(1);
		
		Vector3 p0 = new Vector3(size.x,  size.y, -size.z);
		Vector3 p1 = new Vector3(-size.x, size.y, -size.z);
		Vector3 p2 = new Vector3(-size.x, size.y,  size.z);
		
		meshBuilder.BuildTriangle(p0,p1,p2, 0);
		
		meshFilter.mesh = meshBuilder.CreateMesh();
        
    }
}
