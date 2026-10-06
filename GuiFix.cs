using UnityEngine;
using UnityEngine.EventSystems;

public class GuiFix : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	private GameObject lastselect;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		lastselect = new GameObject();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
		{
			EventSystem.current.SetSelectedGameObject(lastselect);
		}
		else
		{
			lastselect = EventSystem.current.currentSelectedGameObject;
		}
	}
}
