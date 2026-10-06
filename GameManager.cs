using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private bool gameHasEnded;

	public float restartDelay = 4f;

	public static int NumberPlayers;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void EndGame()
	{
		_ = gameHasEnded;
		gameHasEnded = true;
		Invoke("Restart", restartDelay);
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
