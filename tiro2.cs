using System.Collections;
using UnityEngine;

public class tiro2 : MonoBehaviour
{
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bullet2;

	public GameObject explosion1;

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
		Object.Destroy(bullet2);
		Object.Instantiate(explosion1, transform.position, transform.rotation);
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet2);
	}
}
