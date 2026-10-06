using System.Collections;
using UnityEngine;

public class scrENEMY5 : MonoBehaviour
{
	// IA/comportamento de inimigo recuperado da Assembly-CSharp; lógica original preservada.
	public Transform closest;

	public float distance;

	public float minDistance = 100f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy5Anime;

	private Animation anim;

	public int enemy5life = 1;

	public Rigidbody ExpINI5;

	public Transform atirador;

	public Rigidbody shotINI5;

	public float delayTiro = 1f;

	public bool canShoot;

	public float Patrolradius = 10f;

	public float Patrolspeed = 1f;

	private Vector3 basestartpoint;

	private Vector3 destination;

	private Vector3 start;

	private float progress;

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		canShoot = true;
		transform.localRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
		moveSpeed = Random.Range(3f, 5f);
		anim = enemy5Anime.GetComponent<Animation>();
		anim["ini5anime"].speed = Random.Range(0.8f, 1.8f);
		start = transform.localPosition;
		basestartpoint = transform.localPosition;
		progress = 0f;
		PickNewRandomDestination();
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Update()
	{
		anim.Play("ini5anime");
		if (enemy5life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI5, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy5life = 0;
		}
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void FixedUpdate()
	{
		closest = getClosest();
		if (!(closest != null))
		{
			return;
		}
		distance = Vector3.Distance(closest.position, transform.position);
		Vector3 position = closest.position;
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
		if (distance < minDistance)
		{
			transform.LookAt(position);
			if (canShoot)
			{
				Object.Instantiate(shotINI5, atirador.position, atirador.rotation).velocity = transform.TransformDirection(new Vector3(0f, 0f, 20f));
				canShoot = false;
				StartCoroutine(ShotCooldown());
			}
		}
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

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

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Attack")
		{
			enemy5life--;
		}
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private IEnumerator ShotCooldown()
	{
		yield return new WaitForSeconds(delayTiro);
		canShoot = true;
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void PickNewRandomDestination()
	{
		destination = Random.insideUnitSphere * Patrolradius + basestartpoint;
	}
}
