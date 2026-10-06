using System.Collections;
using UnityEngine;

public class scrENEMY9 : MonoBehaviour
{
	public Transform closest;

	public float distance;

	public float minDistance = 50f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy9Anime;

	private Animation anim;

	public int enemy9life = 20;

	public Rigidbody ExpINI9;

	public Transform atirador;

	public GameObject[] myObjects;

	private float delayTiro;

	public bool canShoot;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		canShoot = true;
		moveSpeed = Random.Range(3f, 5f);
		anim = enemy9Anime.GetComponent<Animation>();
		anim["ini9anime"].speed = Random.Range(0.8f, 1.8f);
		delayTiro = Random.Range(2f, 3.5f);
		transform.localScale = new Vector3(Random.Range(1f, 2.5f), Random.Range(1f, 2.5f), Random.Range(1f, 2.5f));
	}

	private void Update()
	{
		anim.Play("ini9anime");
		if (enemy9life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI9, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy9life = 0;
		}
	}

	private void FixedUpdate()
	{
		closest = getClosest();
		if (closest != null)
		{
			distance = Vector3.Distance(closest.position, transform.position);
			_ = closest.position;
			if (distance < minDistance && canShoot)
			{
				int num = Random.Range(0, myObjects.Length);
				Object.Instantiate(myObjects[num], atirador.position, atirador.rotation);
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
		}
	}

	public Transform getClosest()
	{
		Transform result = null;
		float num = 999999f;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Alvo");
		for (int i = 0; i < array.Length; i++)
		{
			float num2 = Vector3.Distance(transform.position, array[i].transform.position);
			if (num2 < num)
			{
				num = num2;
				result = array[i].transform;
			}
		}
		return result;
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Attack")
		{
			enemy9life--;
		}
	}

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}
}
