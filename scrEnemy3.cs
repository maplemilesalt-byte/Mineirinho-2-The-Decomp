using UnityEngine;

public class scrEnemy3 : MonoBehaviour
{
	// IA/comportamento de inimigo recuperado da Assembly-CSharp; lógica original preservada.
	public Transform closest;

	public float distance;

	public float minDistance = 20f;

	public float moveSpeed = 2f;

	private Rigidbody rb;

	public GameObject enemy3Anime;

	private Animation anim;

	public int enemy3life = 10;

	public Rigidbody ExpINI3;

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		closest = null;
		transform.localRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
		moveSpeed = Random.Range(5f, 7f);
		anim = enemy3Anime.GetComponent<Animation>();
		anim["ini3sempre"].speed = Random.Range(0.8f, 1.8f);
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Update()
	{
		anim.Play("ini3sempre");
		if (enemy3life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI3, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy3life = 0;
		}
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

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
				rb.AddForce(transform.forward.normalized * moveSpeed * 4f, ForceMode.Force);
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
			enemy3life--;
		}
	}
}
