using System.Collections;
using UnityEngine;

public class tiro5 : MonoBehaviour
{
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bullet5;

	public GameObject explosion2;

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void OnCollisionEnter()
	{
		Object.Destroy(bullet5);
		Object.Instantiate(explosion2, transform.position, transform.rotation);
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(5f);
		Object.Destroy(bullet5);
	}
}
