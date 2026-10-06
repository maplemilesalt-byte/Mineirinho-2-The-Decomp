using UnityEngine;

public class AutoMovRot : MonoBehaviour
{
	public float xSpeed;

	public float ySpeed;

	public float zSpeed;

	public Vector3[] points;

	public int point_number;

	private Vector3 current_target;

	public float tolerance;

	public float speed;

	public float delay_time;

	private float delay_start;

	public bool automatic;

	private void Start()
	{
		if (points.Length != 0)
		{
			current_target = points[0];
		}
		tolerance = speed * Time.deltaTime;
	}

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
		transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
	}

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

	private void UpdateTarget()
	{
		if (automatic && Time.time - delay_start > delay_time)
		{
			NextPlatform();
		}
	}

	public void NextPlatform()
	{
		point_number++;
		if (point_number >= points.Length)
		{
			point_number = 0;
		}
		current_target = points[point_number];
	}
}
