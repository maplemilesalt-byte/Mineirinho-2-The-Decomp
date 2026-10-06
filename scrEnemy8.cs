using UnityEngine;

public class scrEnemy8 : MonoBehaviour
{
	// IA/comportamento de inimigo recuperado da Assembly-CSharp; lógica original preservada.
	public int enemy8life = 1;

	public Rigidbody ExpINI8;

	// Rotina do inimigo; comportamento preservado da decompilação original.

	private void Start()
	{
	}

	// Rotina do inimigo; comportamento preservado da decompilação original.

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
