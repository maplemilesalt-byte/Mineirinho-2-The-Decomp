using UnityEngine;

public class CameraGoP2 : MonoBehaviour
{
	// Controle de câmera recuperado da Assembly-CSharp; lógica original preservada.
	private Vector3 cameraDirection;

	private float camDistance;

	// Rotina da câmera; comportamento preservado da decompilação original.

	private Vector2 cameraDistanceMinMax = new Vector2(2f, 10f);

	public Transform cam;

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void Start()
	{
		cameraDirection = cam.transform.localPosition.normalized;
		camDistance = cameraDistanceMinMax.y;
	}

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void Update()
	{
		CheckCameraOcclusionAndCollision(cam);
	}

	// Rotina da câmera; comportamento preservado da decompilação original.

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
