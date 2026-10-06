using System.Collections;
using UnityEngine;

public class tiro1P2 : MonoBehaviour
{
	public bool returning;

	public Transform target;

	public Rigidbody bullet1;

	private Vector3 playerposition;

	private void Start()
	{
		returning = false;
		target = GameObject.Find("Player2(Clone)").transform;
		playerposition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
		StartCoroutine(Boom());
	}

	private void Update()
	{
		_ = returning;
		if (!returning)
		{
			return;
		}
		if (target != null)
		{
			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100f, ForceMode.Acceleration);
			transform.LookAt(target);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), Time.deltaTime * 40f);
			if (returning && Vector3.Distance(target.transform.position, transform.position) < 1.5f)
			{
				GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().canShoot = true;
				Object.Destroy(gameObject);
			}
		}
		else
		{
			Object.Destroy(gameObject);
		}
	}

	private void OnCollisionEnter()
	{
		returning = true;
	}

	private IEnumerator Boom()
	{
		yield return new WaitForSeconds(0.2f);
		returning = true;
	}
}
