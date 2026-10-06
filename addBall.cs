using System.Collections;
using UnityEngine;

public class addBall : MonoBehaviour
{
	public Transform addBola;

	public Rigidbody bola;

	public float delayTiro = 4f;

	public bool canShoot;

	private void Start()
	{
		canShoot = true;
	}

	private void Update()
	{
		if (canShoot)
		{
			Object.Instantiate(bola, addBola.position, addBola.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 0f));
			canShoot = false;
			StartCoroutine(ShotCooldown());
		}
	}

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}
}
