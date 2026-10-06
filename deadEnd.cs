using System.Collections;
using UnityEngine;

public class deadEnd : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	// Rotina preservada da decompilação original.
	private void Start()
	{
		StartCoroutine(gotoEnd());
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
	}

	// Rotina preservada da decompilação original.

	private IEnumerator gotoEnd()
	{
		yield return new WaitForSeconds(5f);
		Application.LoadLevel("END");
	}
}
