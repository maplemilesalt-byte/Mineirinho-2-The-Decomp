using System.Collections;
using UnityEngine;

public class tiroINI4 : MonoBehaviour
{
	// Componente de física/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bulletINI4;

	public GameObject expINI4shot;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnCollisionEnter()
	{
		Object.Destroy(bulletINI4);
		Object.Instantiate(expINI4shot, transform.position, transform.rotation);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(10f);
		Object.Destroy(bulletINI4);
	}
}
