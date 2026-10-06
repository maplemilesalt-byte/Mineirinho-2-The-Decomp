using UnityEngine;

public class portal9 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player")
		{
			Application.LoadLevel("fase10");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("fase10");
		}
	}
}
