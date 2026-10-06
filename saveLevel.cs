using UnityEngine;
using UnityEngine.SceneManagement;

public class saveLevel : MonoBehaviour
{
	// IA/comportamento de inimigo recuperado da Assembly-CSharp; lógica original preservada.
	private int currentSceneIndex;

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Start()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Update()
	{
	}
}
