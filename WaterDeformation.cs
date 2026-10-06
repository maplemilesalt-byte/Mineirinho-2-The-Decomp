using UnityEngine;

public class WaterDeformation : MonoBehaviour
{
	public static Mesh mesh;

	public static Transform water;

	public float deformAmount = 1f;

	public float scale = 2.5f;

	public float speed = 1f;

	private Vector2 time = Vector2.zero;

	private void Start()
	{
		water = transform;
		mesh = GetComponent<MeshFilter>().mesh;
	}

	private void Update()
	{
		time = new Vector2(Time.time, Time.time) * speed;
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = Deform(vertices[i]);
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
		GetComponent<MeshFilter>().mesh = mesh;
	}

	private Vector3 Deform(Vector3 v)
	{
		v.y = Mathf.PerlinNoise(v.x / scale + time.x, v.z / scale + time.y) * deformAmount;
		return v;
	}
}
