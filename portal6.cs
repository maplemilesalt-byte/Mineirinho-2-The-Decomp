using UnityEngine;

public class portal6 : MonoBehaviour
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
			Application.LoadLevel("map4");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("map4");
		}
	}
}
