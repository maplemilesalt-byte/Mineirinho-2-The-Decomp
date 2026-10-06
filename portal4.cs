using UnityEngine;

public class portal4 : MonoBehaviour
{
	// Componente de mundo recuperado da Assembly-CSharp; lógica original preservada.
	// Rotina do componente; comportamento preservado da decompilação original.
	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player")
		{
			Application.LoadLevel("map3");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("map3");
		}
	}
}
