using UnityEngine;

public class frangoGET : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public GameObject frangoP1;

	public GameObject frangoP2;

	// Rotina preservada da decompilação original.

	private void Start()
	{
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
		transform.Rotate(0f, 0f, 1f);
	}

	// Rotina preservada da decompilação original.

	private void OnTriggerStay(Collider target)
	{
		if (target.tag == "Player")
		{
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 3;
			Object.Instantiate(frangoP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 3;
			Object.Instantiate(frangoP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
