using UnityEngine;

public class Explosion2 : MonoBehaviour
{
	public float radius = 1f;

	public float power = 8f;

	public GameObject exp2;

	private void Start()
	{
		Vector3 position = transform.position;
		Collider[] array = Physics.OverlapSphere(position, radius);
		for (int i = 0; i < array.Length; i++)
		{
			Rigidbody component = array[i].GetComponent<Rigidbody>();
			if (component != null)
			{
				component.AddExplosionForce(power, position, radius, 2f);
			}
		}
		Object.Destroy(exp2, 0.5f);
	}
}
