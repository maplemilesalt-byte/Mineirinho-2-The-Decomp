using UnityEngine;
using UnityEngine.SceneManagement;

public class saveLevel : MonoBehaviour
{
	private int currentSceneIndex;

	private void Start()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
	}

	private void Update()
	{
	}
}
