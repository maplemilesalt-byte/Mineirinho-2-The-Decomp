using System.Collections;
using UnityEngine;

public class tiro6 : MonoBehaviour
{
	public GameObject bullet6;

	public float radius = 1f;

	public float power = 10f;

	private void Start()
	{
	}

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody component = collision.gameObject.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.AddForce(Vector3.up * 1000f);
		}
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(3f);
		Object.Destroy(bullet6);
	}
}
