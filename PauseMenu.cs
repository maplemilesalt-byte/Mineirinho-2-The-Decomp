using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	public GameObject pauseMenu;

	public bool isPaused;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		ResumeGame();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
		if (Input.GetKeyDown("joystick button 7"))
		{
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void PauseGame()
	{
		pauseMenu.SetActive(value: true);
		Time.timeScale = 0f;
		isPaused = true;
		if (GameObject.Find("Player") != null)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
		}
		if (GameObject.Find("HatShot") != null)
		{
			GameObject.Find("HatShot").GetComponent<tiro1>().enabled = false;
		}
		if (GameObject.Find("Player2(Clone)") != null)
		{
			GameObject.Find("Player2(Clone)").GetComponent<PlayerMovementP2>().enabled = false;
		}
		if (GameObject.Find("HatShotP2(Clone)") != null)
		{
			GameObject.Find("HatShotP2(Clone)").GetComponent<tiro1P2>().enabled = false;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void ResumeGame()
	{
		pauseMenu.SetActive(value: false);
		Time.timeScale = 1f;
		isPaused = false;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		if (GameObject.Find("Player") != null)
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
		}
		if (GameObject.Find("HatShot") != null)
		{
			GameObject.Find("HatShot").GetComponent<tiro1>().enabled = true;
		}
		if (GameObject.Find("Player2(Clone)") != null)
		{
			GameObject.Find("Player2(Clone)").GetComponent<PlayerMovementP2>().enabled = true;
		}
		if (GameObject.Find("HatShotP2(Clone)") != null)
		{
			GameObject.Find("HatShotP2(Clone)").GetComponent<tiro1P2>().enabled = true;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void GoMenu()
	{
		Application.LoadLevel("menu");
		pauseMenu.SetActive(value: false);
		Time.timeScale = 1f;
		isPaused = false;
	}
}
