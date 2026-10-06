using System.Collections;
using UnityEngine;

public class tiro2 : MonoBehaviour
{
	public GameObject bullet2;

	public GameObject explosion1;

	private void Start()
	{
	}

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	private void OnCollisionEnter()
	{
		Object.Destroy(bullet2);
		Object.Instantiate(explosion1, transform.position, transform.rotation);
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet2);
	}
}
