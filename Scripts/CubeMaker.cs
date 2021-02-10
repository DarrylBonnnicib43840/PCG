using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class CubeMaker : MonoBehaviour
{
		[SerializeField]
	private Vector3 size = Vector3.one;
	private List<Material> materialsList;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		MeshFilter meshFilter = this.GetComponent<MeshFilter>();
		MeshBuilder meshBuilder = new MeshBuilder(6);
		
		//top vertices
		 Vector3 t0 = new Vector3(size.x,	size.y,	-size.z);
		 Vector3 t1 = new Vector3(-size.x,	size.y,	-size.z);
		 Vector3 t2 = new Vector3(-size.x,	size.y,	size.z);
		 Vector3 t3 = new Vector3(size.x,	size.y,	size.z);
		 
		 //bottom vertices
		 Vector3 b0 = new Vector3(size.x,	-size.y,	-size.z);
		 Vector3 b1 = new Vector3(-size.x,	-size.y,	-size.z);
		 Vector3 b2 = new Vector3(-size.x,	-size.y,	size.z);
		 Vector3 b3 = new Vector3(size.x,	-size.y,	size.z);
		 
		 //top square
		 meshBuilder.BuildTriangle(t0, t1, t2, 0);
		 meshBuilder.BuildTriangle(t0, t2, t3, 0);
		 
		 //bottom square
		 meshBuilder.BuildTriangle(b2, b1, b0, 1);
		 meshBuilder.BuildTriangle(b3, b2, b0, 1);
		 
		 //back sqaure
		 meshBuilder.BuildTriangle(b0, t1, t0, 2);
		 meshBuilder.BuildTriangle(b0, b1, t1, 2);
		 
		 //front square
		 meshBuilder.BuildTriangle(b3, t0, t3, 3);
		 meshBuilder.BuildTriangle(b3, b0, t0, 3);
		 
		 //left square
		 meshBuilder.BuildTriangle(b1, t2, t1, 4);
		 meshBuilder.BuildTriangle(b1, b2, t2, 4);
		 
		 //right square
		 meshBuilder.BuildTriangle(b2, t3, t2, 5);
		 meshBuilder.BuildTriangle(b2, b3, t3, 5);

		 
		meshFilter.mesh = meshBuilder.CreateMesh();
		
		MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
		AddMaterials();
		meshRenderer.materials = materialsList.ToArray();
		
		
    }
	private void AddMaterials(){
		
		Material redMat = new Material(Shader.Find("Specular"));
		redMat.color = Color.red;
		
		Material blueMat = new Material(Shader.Find("Specular"));
		blueMat.color = Color.blue;
		
		Material greenMat = new Material(Shader.Find("Specular"));
		greenMat.color = Color.green;
		
		Material  magentaMat = new Material(Shader.Find("Specular"));
		magentaMat.color = Color.magenta;
		
		Material yellowMat = new Material(Shader.Find("Specular"));
		yellowMat.color = Color.yellow;
		
		Material whiteMat = new Material(Shader.Find("Specular"));
		whiteMat.color = Color.white;
		
		materialsList = new List<Material>();
		materialsList.Add(redMat);
		materialsList.Add(blueMat);
		materialsList.Add(greenMat);
		materialsList.Add(magentaMat);
		materialsList.Add(yellowMat);
		materialsList.Add(whiteMat);
	}

}
