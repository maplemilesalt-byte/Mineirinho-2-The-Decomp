using System.Collections;
using UnityEngine;

public class scrEnemy7 : MonoBehaviour
{
	public Transform closest;

	public float distance;

	public float minDistance = 100f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy7Anime;

	private Animation anim;

	public int enemy7life = 1;

	public Rigidbody ExpINI7;

	public Transform atirador;

	public Rigidbody shotINI7;

	public float delayTiro = 1f;

	public bool canShoot;

	public float Patrolradius = 10f;

	public float Patrolspeed = 1f;

	private Vector3 basestartpoint;

	private Vector3 destination;

	private Vector3 start;

	private float progress;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		canShoot = true;
		transform.localRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
		moveSpeed = Random.Range(3f, 5f);
		anim = enemy7Anime.GetComponent<Animation>();
		anim["ini7anime"].speed = Random.Range(0.8f, 1.8f);
		start = transform.localPosition;
		basestartpoint = transform.localPosition;
		progress = 0f;
		PickNewRandomDestination();
	}

	private void Update()
	{
		anim.Play("ini7anime");
		if (enemy7life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI7, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy7life = 0;
		}
	}

	private void FixedUpdate()
	{
		closest = getClosest();
		if (!(closest != null))
		{
			return;
		}
		distance = Vector3.Distance(closest.position, transform.position);
		Vector3 position = closest.position;
		if (distance < minDistance)
		{
			transform.LookAt(position);
			rb.AddForce(transform.forward.normalized * moveSpeed * 5f, ForceMode.Force);
			if (canShoot)
			{
				Object.Instantiate(shotINI7, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 20f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
			return;
		}
		bool flag = false;
		progress += Patrolspeed * Time.deltaTime;
		if (progress >= 1f)
		{
			progress = 1f;
			flag = true;
		}
		transform.localPosition = destination * progress + start * (1f - progress);
		if (flag)
		{
			start = destination;
			PickNewRandomDestination();
			progress = 0f;
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
			enemy7life--;
		}
	}

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}

	private void PickNewRandomDestination()
	{
		destination = Random.insideUnitSphere * Patrolradius + basestartpoint;
	}
}
