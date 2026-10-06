using System;
using UnityEngine;

public class PhysicWater : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	public float waveHeight = 0.5f;

	public float waveFrequency = 0.5f;

	public float waveLength = 0.75f;

	// Rotina do componente; comportamento preservado da decompilação original.

	public Vector3 waveOriginPosition = new Vector3(0f, 0f, 0f);

	private MeshFilter meshFilter;

	public Mesh mesh;

	public Vector3[] vertices;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		CreateMeshLowPoly(meshFilter);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private MeshFilter CreateMeshLowPoly(MeshFilter mf)
	{
		mesh = mf.sharedMesh;
		Vector3[] array = mesh.vertices;
		int[] triangles = mesh.triangles;
		Vector3[] array2 = new Vector3[triangles.Length];
		for (int i = 0; i < triangles.Length; i++)
		{
			array2[i] = array[triangles[i]];
			triangles[i] = i;
		}
		mesh.vertices = array2;
		mesh.SetTriangles(triangles, 0);
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		vertices = mesh.vertices;
		return mf;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		GenerateWaves();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GenerateWaves()
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vector = vertices[i];
			vector.y = 0f;
			float num = Vector3.Distance(vector, waveOriginPosition);
			num = num % waveLength / waveLength;
			vector.y = waveHeight * Mathf.Sin(Time.time * (float)Math.PI * 2f * waveFrequency + (float)Math.PI * 2f * num);
			vertices[i] = vector;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
		mesh.MarkDynamic();
		meshFilter.mesh = mesh;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public float getHeightAtPosition(Vector3 position)
	{
		_ = Time.time;
		new Vector3(transform.position.x, transform.position.y, transform.position.z);
		return new Vector3(transform.position.x, transform.position.y, transform.position.z).y;
	}
}
