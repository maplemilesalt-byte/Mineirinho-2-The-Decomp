using System.Collections;
using UnityEngine;

public class smokeAdd : MonoBehaviour
{
	public GameObject smoke;

	public AudioClip surfsound;

	private void Start()
	{
	}

	private void Update()
	{
		GetComponent<AudioSource>().PlayOneShot(surfsound);
		StartCoroutine(DelayDestroy());
	}

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(0.4f);
		Object.Destroy(smoke);
	}
}
