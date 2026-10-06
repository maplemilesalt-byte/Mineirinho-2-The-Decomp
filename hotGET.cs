using UnityEngine;

public class hotGET : MonoBehaviour
{
	public GameObject paoP1;

	public GameObject paoP2;

	private void Start()
	{
	}

	private void Update()
	{
		transform.Rotate(0f, 0f, 1f);
	}

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
