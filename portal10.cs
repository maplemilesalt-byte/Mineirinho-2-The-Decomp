using UnityEngine;

public class portal10 : MonoBehaviour
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
			Application.LoadLevel("map6");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("map6");
		}
	}
}
