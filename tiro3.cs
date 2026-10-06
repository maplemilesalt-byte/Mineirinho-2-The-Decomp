using System.Collections;
using UnityEngine;

public class tiro3 : MonoBehaviour
{
	public GameObject bullet3;

	private void Start()
	{
	}

	private void Update()
	{
		StartCoroutine(DelayDestroy());
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(bullet3);
	}
}
