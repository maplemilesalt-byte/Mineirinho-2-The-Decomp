using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private int sceneToContinue;

	public void PlayGame()
	{
		Application.LoadLevel("map1");
		GameManager.NumberPlayers = 1;
	}

	public void PlayGameTwoPlayers()
	{
		Application.LoadLevel("map1");
		GameManager.NumberPlayers = 2;
	}

	public void ContinueP1()
	{
		GameManager.NumberPlayers = 1;
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");
		if (sceneToContinue != 0)
		{
			SceneManager.LoadScene(sceneToContinue);
		}
	}

	public void ContinueP2()
	{
		GameManager.NumberPlayers = 2;
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");
		if (sceneToContinue != 0)
		{
			SceneManager.LoadScene(sceneToContinue);
		}
	}

	public void GoFase1()
	{
		Application.LoadLevel("fase1");
	}

	public void GoFase3()
	{
		Application.LoadLevel("fase3");
	}

	public void GoFase5()
	{
		Application.LoadLevel("fase5");
	}

	public void GoFase7()
	{
		Application.LoadLevel("fase7");
	}

	public void GoFase9()
	{
		Application.LoadLevel("fase9");
	}

	public void GoFase11()
	{
		Application.LoadLevel("fase11");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void GoCredits()
	{
		Application.LoadLevel("credits");
	}

	public void GoControls()
	{
		Application.LoadLevel("controls");
	}

	public void GoInstructions()
	{
		Application.LoadLevel("instructions");
	}

	public void GoMenu()
	{
		Application.LoadLevel("menu");
	}
}
