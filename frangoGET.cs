using UnityEngine;

public class frangoGET : MonoBehaviour
{
	public GameObject frangoP1;

	public GameObject frangoP2;

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
