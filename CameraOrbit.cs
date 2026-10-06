using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
	public float lookSensitivity;

	public float minXLook;

	public float maxXLook;

	public Transform camAnchor;

	public bool invertXRotation;

	private float curXRot;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}

	private void LateUpdate()
	{
		if (!GameObject.Find("EventSystem").GetComponent<PauseMenu>().isPaused)
		{
			float axis = Input.GetAxis("Mouse X");
			float axis2 = Input.GetAxis("Mouse Y");
			transform.eulerAngles += Vector3.up * axis * lookSensitivity;
			if (invertXRotation)
			{
				curXRot += axis2 * lookSensitivity;
			}
			else
			{
				curXRot -= axis2 * lookSensitivity;
			}
			curXRot = Mathf.Clamp(curXRot, minXLook, maxXLook);
			Vector3 eulerAngles = camAnchor.eulerAngles;
			eulerAngles.x = curXRot;
			camAnchor.eulerAngles = eulerAngles;
		}
	}

	private void Update()
	{
	}
}
