using System.Collections;
using UnityEngine;

public class smokeAdd : MonoBehaviour
{
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject smoke;

	public AudioClip surfsound;

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Update()
	{
		GetComponent<AudioSource>().PlayOneShot(surfsound);
		StartCoroutine(DelayDestroy());
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(0.4f);
		Object.Destroy(smoke);
	}
}
