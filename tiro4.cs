using System.Collections;
using UnityEngine;

public class tiro4 : MonoBehaviour
{
	// Componente de projétil/efeito recuperado da Assembly-CSharp; lógica original preservada.
	public GameObject bullet4;

	public float speed = 50f;

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Awake()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void Update()
	{
		gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
		StartCoroutine(DelayDestroy());
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 toDirection = Vector3.Reflect(bullet4.transform.forward, collision.GetContact(0).normal);
		bullet4.transform.rotation = Quaternion.FromToRotation(Vector3.forward, toDirection);
	}

	// Rotina do projétil/efeito; comportamento preservado da decompilação original.

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet4);
	}
}
