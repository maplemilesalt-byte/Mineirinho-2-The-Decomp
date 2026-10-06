using UnityEngine;

public class Boia : MonoBehaviour
{
	public float depthBeforeSubmerged = 1f;

	public float cubeVolume = 3f;

	public int floaterCount = 1;

	public float waterDrag = 0.99f;

	public float waterAngularDrag = 0.5f;

	private PhysicWater physicWater;

	private Rigidbody m_Rigidbody;

	private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		physicWater = Object.FindObjectOfType<PhysicWater>();
	}

	private void FixedUpdate()
	{
		m_Rigidbody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
		float heightAtPosition = physicWater.getHeightAtPosition(transform.position);
		if (transform.position.y < heightAtPosition)
		{
			float num = Mathf.Clamp01((heightAtPosition - transform.position.y) / depthBeforeSubmerged) * cubeVolume;
			m_Rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * num, 0f), transform.position, ForceMode.Acceleration);
			m_Rigidbody.AddForce(num * -m_Rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
			m_Rigidbody.AddTorque(num * -m_Rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
		}
	}
}
