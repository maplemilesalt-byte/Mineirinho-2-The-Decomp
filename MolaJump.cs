using UnityEngine;

public class MolaJump : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	public int molaforce = 2000;

	public AudioClip molasom;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody component = collision.gameObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.AddForce(Vector3.up * molaforce);
			GetComponent<AudioSource>().PlayOneShot(molasom);
		}
	}
}
