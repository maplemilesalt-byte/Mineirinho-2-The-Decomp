using UnityEngine;

public class coracaoGET : MonoBehaviour
{
	public GameObject issoP1;

	public GameObject issoP2;

	private void Start()
	{
	}

	private void Update()
	{
		transform.Rotate(0f, 0f, 1f);
	}

	private void OnTriggerStay(Collider target)
	{
		if (target.tag == "Player")
		{
			GameObject.Find("Player").GetComponent<PlayerMovement>().currentHealth++;
			Object.Instantiate(issoP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("Player2(Clone)").GetComponent<PlayerMovementP2>().currentHealth++;
			Object.Instantiate(issoP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
