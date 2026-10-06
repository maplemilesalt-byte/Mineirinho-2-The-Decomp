using System.Collections;
using UnityEngine;

public class addBall : MonoBehaviour
{
	// Componente de gameplay recuperado da Assembly-CSharp; comentários documentam sua função.
	public Transform addBola;

	public Rigidbody bola;

	public float delayTiro = 4f;

	public bool canShoot;

	// Rotina preservada da decompilação original.

	private void Start()
	{
		canShoot = true;
	}

	// Rotina preservada da decompilação original.

	private void Update()
	{
		if (canShoot)
		{
			Object.Instantiate(bola, addBola.position, addBola.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 0f));
			canShoot = false;
			StartCoroutine(ShotCooldown());
		}
	}

	// Rotina preservada da decompilação original.

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}
}
