using System.Collections;
using UnityEngine;

public class tiro6 : MonoBehaviour
{
	// Componente de física/efeito recuperado da Assembly-CSharp; lógica original preservada.
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bullet6;

	public float radius = 1f;

	public float power = 10f;

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody component = collision.gameObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.AddForce(Vector3.up * 1000f);
		}
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	// Rotina do componente; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(3f);
		Object.Destroy(bullet6);
	}
}
