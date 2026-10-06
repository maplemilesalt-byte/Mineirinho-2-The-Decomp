using UnityEngine;

public class CarryRBrot : MonoBehaviour
{
	private Vector3 LastPosition;

	private Vector3 LastMove;

	private Vector3 LastEulerAngles;

	private Vector3 angularVelocity;

	private void FixedUpdate()
	{
		LastMove = transform.position - LastPosition;
		LastPosition = transform.position;
		angularVelocity = transform.rotation * LastEulerAngles;
		LastEulerAngles = transform.eulerAngles;
	}

	private void OnTriggerStay(Collider other)
	{
		if ((bool)other.attachedRigidbody)
		{
			other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + LastMove);
			Quaternion quaternion = Quaternion.Euler(angularVelocity / 2f * Time.fixedDeltaTime);
			other.attachedRigidbody.MoveRotation(other.attachedRigidbody.rotation * quaternion);
		}
	}
}
