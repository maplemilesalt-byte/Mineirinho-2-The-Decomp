using System.Collections;
using UnityEngine;

public class tiro4 : MonoBehaviour
{
	public GameObject bullet4;

	public float speed = 50f;

	private void Awake()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	private void Update()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
		StartCoroutine(DelayDestroy());
	}

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 toDirection = Vector3.Reflect(bullet4.transform.forward, collision.GetContact(0).normal);
		bullet4.transform.rotation = Quaternion.FromToRotation(Vector3.forward, toDirection);
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet4);
	}
}
