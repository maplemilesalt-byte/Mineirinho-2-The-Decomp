using UnityEngine;

public class portal8 : MonoBehaviour
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
			Application.LoadLevel("map5");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("map5");
		}
	}
}
