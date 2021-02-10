using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class PyramidMaker : MonoBehaviour
{
	[SerializeField]
	private float pyramidSize = 5f;
	private int subMeshSize = 4;
	
	private List<Material> materialList;
	private MeshRenderer meshRenderer;
	

    // Update is called once per frame
    void Update()
    {
		
		MeshFilter meshFilter = this.GetComponent<MeshFilter>();
		MeshBuilder meshBuilder = new MeshBuilder(subMeshSize);
		
		Vector3 top = new Vector3(0, pyramidSize,0);
		Vector3 base0 = Quaternion.AngleAxis(  0f, Vector3.up) * Vector3.forward * pyramidSize;
		Vector3 base1 = Quaternion.AngleAxis(240f, Vector3.up) * Vector3.forward * pyramidSize;
		Vector3 base2 = Quaternion.AngleAxis(120f, Vector3.up) * Vector3.forward * pyramidSize;
		
		meshBuilder.BuildTriangle(base0,base1,base2, 0);
		meshBuilder.BuildTriangle(base1,base0,top, 0);
		meshBuilder.BuildTriangle(base2,top,base0, 0);
		meshBuilder.BuildTriangle(top,base2,base1, 0);
		
		
		meshFilter.mesh = meshBuilder.CreateMesh();
		
		MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
		AddMaterials();
		meshRenderer.materials = materialList.ToArray();
		
        
    }
	private void AddMaterials(){
		
		Material greenMat = new Material(Shader.Find("Specular"));
		greenMat.color = Color.green;
		
		materialList = new List<Material>();
		materialList.Add(greenMat);
		materialList.Add(greenMat);
		materialList.Add(greenMat);
		materialList.Add(greenMat);
	}
}
