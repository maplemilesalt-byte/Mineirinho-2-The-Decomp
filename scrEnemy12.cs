using UnityEngine;

public class scrEnemy12 : MonoBehaviour
{
	public Transform closest;

	public float distance;

	public float minDistance = 999999f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy2Anime;

	private Animation anim;

	public int enemy2life = 1;

	public Rigidbody ExpINI2;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		transform.localRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
		moveSpeed = Random.Range(5f, 7f);
		anim = enemy2Anime.GetComponent<Animation>();
		anim["ini2sempre"].speed = Random.Range(0.8f, 1.8f);
	}

	private void Update()
	{
		anim.Play("ini2sempre");
		if (enemy2life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI2, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy2life = 0;
		}
	}

	private void FixedUpdate()
	{
		closest = getClosest();
		if (closest != null)
		{
			distance = Vector3.Distance(closest.position, transform.position);
			Vector3 position = closest.position;
			if (distance < minDistance)
			{
				transform.LookAt(position);
				rb.AddForce(transform.forward.normalized * moveSpeed * 5f, ForceMode.Force);
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
			enemy2life--;
		}
	}
}
