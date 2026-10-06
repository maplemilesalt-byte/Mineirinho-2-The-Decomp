using UnityEngine;

public class MolaJump : MonoBehaviour
{
	public int molaforce = 2000;

	public AudioClip molasom;

	private void Start()
	{
	}

	private void Update()
	{
	}

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
