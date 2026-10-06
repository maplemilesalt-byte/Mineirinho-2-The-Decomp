using UnityEngine;

public class hotGET : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public GameObject paoP1;

	public GameObject paoP2;

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
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 5;
			Object.Instantiate(paoP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 5;
			Object.Instantiate(paoP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
