using System.Collections;
using UnityEngine;

public class scrENEMY10 : MonoBehaviour
{
	public Transform closest;

	public float distance;

	public float minDistance = 70f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy10Anime;

	private Animation anim;

	public int enemy10life = 20;

	public Rigidbody ExpINI10;

	public Transform atirador;

	public Rigidbody shotINI10;

	public float delayTiro = 0.5f;

	public bool canShoot;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		canShoot = true;
		moveSpeed = Random.Range(3f, 5f);
		anim = enemy10Anime.GetComponent<Animation>();
		anim["ini10anime"].speed = Random.Range(0.8f, 1.8f);
		transform.localScale = new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f));
	}

	private void Update()
	{
		anim.Play("ini10anime");
		if (enemy10life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI10, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy10life = 0;
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
				Object.Instantiate(shotINI10, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(Random.Range(-10f, 10f), Random.Range(5f, 20f), Random.Range(-10f, 10f)));
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
			enemy10life--;
		}
	}

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}
}
