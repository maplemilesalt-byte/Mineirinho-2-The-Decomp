using UnityEngine;
using UnityEngine.EventSystems;

public class GuiFix : MonoBehaviour
{
	private GameObject lastselect;

	private void Start()
	{
		lastselect = new GameObject();
	}

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
