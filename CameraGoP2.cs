using UnityEngine;

public class CameraGoP2 : MonoBehaviour
{
	private Vector3 cameraDirection;

	private float camDistance;

	private Vector2 cameraDistanceMinMax = new Vector2(2f, 10f);

	public Transform cam;

	private void Start()
	{
		cameraDirection = cam.transform.localPosition.normalized;
		camDistance = cameraDistanceMinMax.y;
	}

	private void Update()
	{
		CheckCameraOcclusionAndCollision(cam);
	}

	public void CheckCameraOcclusionAndCollision(Transform cam)
	{
		Vector3 end = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
		if (Physics.Linecast(transform.position, end, out var hitInfo))
		{
			camDistance = Mathf.Clamp(hitInfo.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
		}
		else
		{
			camDistance = cameraDistanceMinMax.y;
		}
		cam.localPosition = cameraDirection * camDistance;
	}
}
