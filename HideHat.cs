using UnityEngine;

public class HideHat : MonoBehaviour
{
	public GameObject hat;

	private void Start()
	{
	}

	private void Update()
	{
		HideObject();
	}

	private void HideObject()
	{
		if (GameObject.Find("HatShot(Clone)") != null)
		{
			hat.SetActive(value: false);
		}
		else
		{
			hat.SetActive(value: true);
		}
	}
}
