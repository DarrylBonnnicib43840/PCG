using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class PlaneMaker : MonoBehaviour
{
	
	[SerializeField]
	private float cellSize = 1f;
	
	[SerializeField]
	private int width = 24;
	
	[SerializeField]
	private int height = 24;
	
	[SerializeField]
	private int subMeshSize = 1;
	
	
	private List<Material> materialList;
	private MeshRenderer meshRenderer;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
		MeshBuilder meshBuilder = new MeshBuilder(subMeshSize);
		
		Vector3[,] points = new Vector3[width, height];
		
		for(int x =0; x< width; x++){
			for (int y =0; y< height; y++){
				
				points[x,y] = new Vector3( cellSize * x, 0, cellSize * y);
			}
			
		}
		
		for(int x = 0; x < width -1; x++){
			for(int y = 0; y < height -1; y++){
				
				Vector3 br = points[x,		y];
				Vector3 bl = points[x+1,	y];
				Vector3 tr = points[x,		y+1];
				Vector3 tl = points[x+1,	y+1];
				
				meshBuilder.BuildTriangle(bl,tr,tl,0);
				meshBuilder.BuildTriangle(bl,br,tr,0);
			
			}
			
		}
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
	}
}
