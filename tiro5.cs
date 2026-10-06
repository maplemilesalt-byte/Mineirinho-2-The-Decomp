using System.Collections;
using UnityEngine;

public class tiro5 : MonoBehaviour
{
	public GameObject bullet5;

	public GameObject explosion2;

	private void Start()
	{
	}

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	private void OnCollisionEnter()
	{
		Object.Destroy(bullet5);
		Object.Instantiate(explosion2, transform.position, transform.rotation);
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(5f);
		Object.Destroy(bullet5);
	}
}
