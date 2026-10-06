using UnityEngine;

public class pimentaGET : MonoBehaviour
{
	public GameObject pimentaP1;

	public GameObject pimentaP2;

	private void Start()
	{
	}

	private void Update()
	{
		transform.Rotate(0f, 0f, 1f);
	}

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player")
		{
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 2;
			Object.Instantiate(pimentaP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 2;
			Object.Instantiate(pimentaP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
