using UnityEngine;

public class HideHatP2 : MonoBehaviour
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
