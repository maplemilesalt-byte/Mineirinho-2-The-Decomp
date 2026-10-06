using System.Collections;
using UnityEngine;

public class tiroINI4 : MonoBehaviour
{
	public GameObject bulletINI4;

	public GameObject expINI4shot;

	private void Start()
	{
	}

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	private void OnCollisionEnter()
	{
		Object.Destroy(bulletINI4);
		Object.Instantiate(expINI4shot, transform.position, transform.rotation);
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(10f);
		Object.Destroy(bulletINI4);
	}
}
