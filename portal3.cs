using UnityEngine;

public class portal3 : MonoBehaviour
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
			Application.LoadLevel("fase4");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("fase4");
		}
	}
}
