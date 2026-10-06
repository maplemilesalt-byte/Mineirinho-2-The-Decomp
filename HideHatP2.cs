using UnityEngine;

public class HideHatP2 : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	public GameObject hat;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		HideObject();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void HideObject()
	{
		if (GameObject.Find("HatShotP2(Clone)") != null)
		{
			hat.SetActive(value: false);
		}
		else
		{
			hat.SetActive(value: true);
		}
	}
}
