using UnityEngine;

public class Explosion14 : MonoBehaviour
{
	public float radius = 0.5f;

	public float power = 5f;

	public GameObject exp1;

	public GameObject[] myObjects;

	private void Start()
	{
		Vector3 position = transform.position;
		Collider[] array = Physics.OverlapSphere(position, radius);
		for (int i = 0; i < array.Length; i++)
		{
			Rigidbody component = array[i].GetComponent<Rigidbody>();
			if (component != null)
			{
				component.AddExplosionForce(power, position, radius, 3f);
			}
		}
		Object.Destroy(exp1, 0.5f);
		int num = Random.Range(0, myObjects.Length);
		Object.Instantiate(myObjects[num], transform.position, transform.rotation);
	}
}
