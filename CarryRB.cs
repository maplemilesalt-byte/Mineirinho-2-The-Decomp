using UnityEngine;

public class CarryRB : MonoBehaviour
{
	// Componente de física/efeito recuperado da Assembly-CSharp; lógica original preservada.
	private Vector3 LastPosition;

	private Vector3 LastMove;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void FixedUpdate()
	{
		LastMove = transform.position - LastPosition;
		LastPosition = transform.position;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnTriggerStay(Collider other)
	{
		if ((bool)other.attachedRigidbody)
		{
			other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + LastMove);
		}
	}
}
