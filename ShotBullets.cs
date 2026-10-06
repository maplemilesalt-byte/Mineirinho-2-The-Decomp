using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShotBullets : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	public bool canShoot;

	public Transform atirador;

	public Rigidbody bullet1;

	public Rigidbody bullet2;

	public Rigidbody bullet3;

	public Rigidbody bullet4;

	public Rigidbody bullet5;

	public Rigidbody bullet6;

	public float delayTiro2 = 0.5f;

	public float delayTiro3 = 0.2f;

	public float delayTiro4 = 0.5f;

	public float delayTiro5 = 0.7f;

	public float delayTiro6 = 0.5f;

	public int tipotiro = 1;

	public Image hud1;

	public Image hud2;

	public Image hud3;

	public Image hud4;

	public Image hud5;

	public Image hud6;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		canShoot = true;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (tipotiro == 1)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet1, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 50f));
				canShoot = false;
			}
			hud1.enabled = true;
			hud2.enabled = false;
			hud3.enabled = false;
			hud4.enabled = false;
			hud5.enabled = false;
			hud6.enabled = false;
		}
		if (tipotiro == 2)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet2, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 50f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			hud1.enabled = false;
			hud2.enabled = true;
			hud3.enabled = false;
			hud4.enabled = false;
			hud5.enabled = false;
			hud6.enabled = false;
		}
		if (tipotiro == 3)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet3, atirador.position, atirador.rotation * Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0, 360)))).velocity = transform.TransformDirection(new Vector3(0f, 0f, 70f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			hud1.enabled = false;
			hud2.enabled = false;
			hud3.enabled = true;
			hud4.enabled = false;
			hud5.enabled = false;
			hud6.enabled = false;
		}
		if (tipotiro == 4)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet4, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 50f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			hud1.enabled = false;
			hud2.enabled = false;
			hud3.enabled = false;
			hud4.enabled = true;
			hud5.enabled = false;
			hud6.enabled = false;
		}
		if (tipotiro == 5)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet5, atirador.position, atirador.rotation * Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0, 360)))).velocity = transform.TransformDirection(new Vector3(0f, 0f, 30f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			hud1.enabled = false;
			hud2.enabled = false;
			hud3.enabled = false;
			hud4.enabled = false;
			hud5.enabled = true;
			hud6.enabled = false;
		}
		if (tipotiro == 6)
		{
			if (Input.GetButton("Fire1") && canShoot)
			{
				Object.Instantiate(bullet6, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 50f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			hud1.enabled = false;
			hud2.enabled = false;
			hud3.enabled = false;
			hud4.enabled = false;
			hud5.enabled = false;
			hud6.enabled = true;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private IEnumerator ShotCooldown()
	{
		if (tipotiro == 2)
		{
			yield return new WaitForSeconds(delayTiro2);
			canShoot = true;
		}
		if (tipotiro == 3)
		{
			yield return new WaitForSeconds(delayTiro3);
			canShoot = true;
		}
		if (tipotiro == 4)
		{
			yield return new WaitForSeconds(delayTiro4);
			canShoot = true;
		}
		if (tipotiro == 5)
		{
			yield return new WaitForSeconds(delayTiro5);
			canShoot = true;
		}
		if (tipotiro == 6)
		{
			yield return new WaitForSeconds(delayTiro6);
			canShoot = true;
		}
	}
}
