using UnityEngine;

public class head2visible : MonoBehaviour
{
	public GameObject Kbeca2;

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

	private void Update()
	{
	}
}
