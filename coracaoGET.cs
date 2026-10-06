using UnityEngine;

public class coracaoGET : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public GameObject issoP1;

	public GameObject issoP2;

	// Rotina preservada da decompilação original.

	private void Start()
	{
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
		transform.Rotate(0f, 0f, 1f);
	}

	// Rotina preservada da decompilação original.

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
