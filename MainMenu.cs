using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	// Controle de interface/menu recuperado da Assembly-CSharp.
	private int sceneToContinue;

	// Rotina do componente; comportamento preservado da decompilação original.

	public void PlayGame()
	{
		Application.LoadLevel("map1");
		GameManager.NumberPlayers = 1;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void PlayGameTwoPlayers()
	{
		Application.LoadLevel("map1");
		GameManager.NumberPlayers = 2;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void ContinueP1()
	{
		GameManager.NumberPlayers = 1;
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");
		if (sceneToContinue != 0)
		{
			SceneManager.LoadScene(sceneToContinue);
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void ContinueP2()
	{
		GameManager.NumberPlayers = 2;
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");
		if (sceneToContinue != 0)
		{
			SceneManager.LoadScene(sceneToContinue);
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase1()
	{
		Application.LoadLevel("fase1");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase3()
	{
		Application.LoadLevel("fase3");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase5()
	{
		Application.LoadLevel("fase5");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase7()
	{
		Application.LoadLevel("fase7");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase9()
	{
		Application.LoadLevel("fase9");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoFase11()
	{
		Application.LoadLevel("fase11");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void QuitGame()
	{
		Application.Quit();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoCredits()
	{
		Application.LoadLevel("credits");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoControls()
	{
		Application.LoadLevel("controls");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoInstructions()
	{
		Application.LoadLevel("instructions");
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void GoMenu()
	{
		Application.LoadLevel("menu");
	}
}
