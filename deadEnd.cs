using System.Collections;
using UnityEngine;

public class deadEnd : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(gotoEnd());
	}

	private void Update()
	{
	}

	private IEnumerator gotoEnd()
	{
		yield return new WaitForSeconds(5f);
		Application.LoadLevel("END");
	}
}
