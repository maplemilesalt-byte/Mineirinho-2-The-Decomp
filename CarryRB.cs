using UnityEngine;

public class CarryRB : MonoBehaviour
{
	private Vector3 LastPosition;

	private Vector3 LastMove;

	private void FixedUpdate()
	{
		LastMove = transform.position - LastPosition;
		LastPosition = transform.position;
	}

	private void OnTriggerStay(Collider other)
	{
		if ((bool)other.attachedRigidbody)
		{
			other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + LastMove);
		}
	}
}
