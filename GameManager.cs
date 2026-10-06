using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	private bool gameHasEnded;

	public float restartDelay = 4f;

	public static int NumberPlayers;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void EndGame()
	{
		_ = gameHasEnded;
		gameHasEnded = true;
		Invoke("Restart", restartDelay);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
