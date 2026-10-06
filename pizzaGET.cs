using UnityEngine;

public class pizzaGET : MonoBehaviour
{
	public GameObject pizzaP1;

	public GameObject pizzaP2;

	private void Start()
	{
	}

	private void Update()
	{
		transform.Rotate(0f, 1f, 0f);
	}

	private void OnTriggerStay(Collider target)
	{
		if (target.tag == "Player")
		{
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 4;
			Object.Instantiate(pizzaP1, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
		if (target.tag == "Player2")
		{
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 4;
			Object.Instantiate(pizzaP2, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
		}
	}
}
