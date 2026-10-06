using System.Collections;
using UnityEngine;

public class tiro3 : MonoBehaviour
{
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bullet3;

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

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet3);
	}
}
