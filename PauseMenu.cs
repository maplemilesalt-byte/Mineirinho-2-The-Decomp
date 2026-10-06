using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;

	public bool isPaused;

	private void Start()
	{
		ResumeGame();
	}

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

	private void GoMenu()
	{
		Application.LoadLevel("menu");
		pauseMenu.SetActive(value: false);
		Time.timeScale = 1f;
		isPaused = false;
	}
}
