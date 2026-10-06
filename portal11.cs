using UnityEngine;

public class portal11 : MonoBehaviour
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
			Application.LoadLevel("fase12");
		}
		if (target.tag == "Player2")
		{
			Application.LoadLevel("fase12");
		}
	}
}
