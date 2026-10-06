using UnityEngine;

public class head2visible : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public GameObject Kbeca2;

	// Rotina preservada da decompilação original.

	private void Start()
	{
		if (GameManager.NumberPlayers == 2)
		{
			Kbeca2.SetActive(value: true);
		}
		if (GameManager.NumberPlayers == 1)
		{
			Kbeca2.SetActive(value: false);
		}
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
	}
}
