using UnityEngine;

public class rampJump : MonoBehaviour
{
	// Componente de mundo recuperado da Assembly-CSharp; lógica original preservada.
	public int rampforce = 1000;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody component = collision.gameObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.AddForce(Vector3.up * rampforce);
		}
	}
}
