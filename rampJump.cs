using UnityEngine;

public class rampJump : MonoBehaviour
{
	public int rampforce = 1000;

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
			component.AddForce(Vector3.up * rampforce);
		}
	}
}
