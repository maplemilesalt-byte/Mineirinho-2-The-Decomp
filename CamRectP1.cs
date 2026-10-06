using UnityEngine;

public class CamRectP1 : MonoBehaviour
{
	// Controle de câmera recuperado da Assembly-CSharp; lógica original preservada.
	// Rotina da câmera; comportamento preservado da decompilação original.
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

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void Update()
	{
	}
}
