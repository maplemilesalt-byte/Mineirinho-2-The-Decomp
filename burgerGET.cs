using UnityEngine;

public class burgerGET : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public GameObject burgerP1;

	public GameObject burgerP2;

	// Rotina preservada da decompilação original.

	private void Start()
	{
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
		transform.Rotate(0f, 1f, 0f);
	}

	// Rotina preservada da decompilação original.

	private void OnTriggerStay(Collider target)
	{
		if (target.tag == "Player")
		{
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 6;
			Object.Instantiate(burgerP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 6;
			Object.Instantiate(burgerP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
