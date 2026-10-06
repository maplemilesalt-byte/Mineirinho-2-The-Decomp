using UnityEngine;

public class Floater : MonoBehaviour
{
	// Componente de física/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public float buoyancy = 20f;

	public float viscosity = 20f;

	private Rigidbody rb;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void FixedUpdate()
	{
		Vector3[] vertices = WaterDeformation.mesh.vertices;
		Vector3[] array = new Vector3[vertices.Length];
		for (int i = 0; i < vertices.Length; i++)
		{
			array[i] = WaterDeformation.water.TransformPoint(vertices[i]);
		}
		Vector3 vector = NearestVertice(transform.position, array);
		if (transform.position.y < vector.y)
		{
			rb.AddForce(Vector3.up * buoyancy);
			rb.velocity /= viscosity / 100f + 1f;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private Vector3 NearestVertice(Vector3 pos, Vector3[] verts)
	{
		Vector3 result = Vector3.zero;
		float num = 100f;
		for (int i = 0; i < verts.Length; i++)
		{
			if (Vector3.Distance(pos, verts[i]) < num)
			{
				result = verts[i];
				num = Vector3.Distance(pos, verts[i]);
			}
		}
		return result;
	}
}
