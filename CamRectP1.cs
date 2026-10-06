using UnityEngine;

public class CamRectP1 : MonoBehaviour
{
	private void Start()
	{
		if (GameManager.NumberPlayers == 1)
		{
			Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
		}
		if (GameManager.NumberPlayers == 2)
		{
			Camera.main.rect = new Rect(0f, 0f, 0.5f, 1f);
		}
	}

	private void Update()
	{
	}
}
