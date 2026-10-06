using UnityEngine;

public class scrEnemy8 : MonoBehaviour
{
	public int enemy8life = 1;

	public Rigidbody ExpINI8;

	private void Start()
	{
	}

	private void Update()
	{
		if (enemy8life <= 0)
		{
			Object.Destroy(gameObject);
			Object.Instantiate(ExpINI8, base.transform.position, base.transform.rotation);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			enemy8life = 0;
		}
	}
}
