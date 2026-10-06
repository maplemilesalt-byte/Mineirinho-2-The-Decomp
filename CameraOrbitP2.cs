using UnityEngine;

public class CameraOrbitP2 : MonoBehaviour
{
	// Controle de câmera recuperado da Assembly-CSharp; lógica original preservada.
	public float lookSensitivity;

	public float minXLook;

	public float maxXLook;

	public Transform camAnchor;

	public bool invertXRotation;

	private float curXRot;

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void LateUpdate()
	{
		if (!GameObject.Find("EventSystem").GetComponent<PauseMenu>().isPaused)
		{
			float axis = Input.GetAxis("Mouse X P2");
			float axis2 = Input.GetAxis("Mouse Y P2");
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

	// Rotina da câmera; comportamento preservado da decompilação original.

	private void Update()
	{
	}
}
