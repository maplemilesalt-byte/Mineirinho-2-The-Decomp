using UnityEngine;

public class destroysound : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		Object.Destroy(gameObject, 2f);
	}
}
