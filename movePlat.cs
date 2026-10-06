using UnityEngine;

public class movePlat : MonoBehaviour
{
	// Componente de mundo recuperado da Assembly-CSharp; lógica original preservada.
	public Vector3[] points;

	public int point_number;

	private Vector3 current_target;

	public float tolerance;

	public float speed;

	public float delay_time;

	private float delay_start;

	public bool automatic;

	private Vector3 lastPosition;

	private Vector3 lastMove;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		if (points.Length != 0)
		{
			current_target = points[0];
		}
		tolerance = speed * Time.deltaTime;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (transform.position != current_target)
		{
			MovePlatform();
		}
		else
		{
			UpdateTarget();
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void MovePlatform()
	{
		Vector3 vector = current_target - transform.position;
		transform.position += vector / vector.magnitude * speed * Time.deltaTime;
		if (vector.magnitude < tolerance)
		{
			transform.position = current_target;
			delay_start = Time.time;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void UpdateTarget()
	{
		if (automatic && Time.time - delay_start > delay_time)
		{
			NextPlatform();
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	public void NextPlatform()
	{
		point_number++;
		if (point_number >= points.Length)
		{
			point_number = 0;
		}
		current_target = points[point_number];
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void FixedUpdate()
	{
		lastMove = transform.position - lastPosition;
		lastPosition = transform.position;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnTriggerStay(Collider other)
	{
		if ((bool)other.attachedRigidbody)
		{
			other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + lastMove);
		}
	}
}
