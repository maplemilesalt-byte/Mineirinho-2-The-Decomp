using UnityEngine;

public class portal7 : MonoBehaviour
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
			Application.LoadLevel("fase8");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("fase8");
		}
	}
}
