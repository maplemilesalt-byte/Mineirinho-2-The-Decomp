using System.Collections;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
	// Sistema da arma de gancho; comentários adicionados sem alterar a lógica original.
	public LineRenderer lr;

	public Vector3 grapplePoint;

	public LayerMask whatIsGrappleable;

	public LayerMask whatIsGrappleable2;

	public Transform gunTip;

	public Transform camera;

	public Transform player;

	private float maxDistance = 40f;

	private SpringJoint joint;

	public Rigidbody Goplayer;

	public AudioClip chiclesound;

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		lr.positionCount = 0;
		Object.Destroy(joint);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			StartGrapple();
		}
		else if (Input.GetButtonUp("Fire2"))
		{
			lr.positionCount = 0;
			Object.Destroy(joint);
			StopGrapple();
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void LateUpdate()
	{
		DrawRope();
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void StartGrapple()
	{
		if (Physics.Raycast(camera.position, camera.forward, out var hitInfo, maxDistance, whatIsGrappleable) && !joint)
		{
			grapplePoint = hitInfo.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = grapplePoint;
			float num = Vector3.Distance(player.position, grapplePoint);
			joint.maxDistance = num * 0.8f;
			joint.minDistance = num * 0.25f;
			joint.spring = 4.5f;
			joint.damper = 7f;
			joint.massScale = 4.5f;
			lr.positionCount = 2;
			GetComponent<AudioSource>().PlayOneShot(chiclesound);
		}
		if (Physics.Raycast(camera.position, camera.forward, out hitInfo, maxDistance, whatIsGrappleable2) && !joint)
		{
			grapplePoint = hitInfo.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = grapplePoint;
			float num2 = Vector3.Distance(player.position, grapplePoint);
			joint.maxDistance = num2 * 0.8f;
			joint.minDistance = num2 * 0.25f;
			joint.spring = 4.5f;
			joint.damper = 7f;
			joint.massScale = 4.5f;
			lr.positionCount = 2;
			if (Time.timeScale > 0f)
			{
				Goplayer.AddForce((grapplePoint - transform.position).normalized * 28f, ForceMode.Impulse);
				Goplayer.AddForce(Vector3.up * 19f, ForceMode.Acceleration);
				GetComponent<AudioSource>().PlayOneShot(chiclesound);
			}
			StartCoroutine(DelayDesconect());
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void DrawRope()
	{
		if ((bool)joint)
		{
			lr.SetPosition(0, gunTip.position);
			lr.SetPosition(1, grapplePoint);
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void StopGrapple()
	{
		lr.positionCount = 0;
		Object.Destroy(joint);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private IEnumerator DelayDesconect()
	{
		yield return new WaitForSeconds(0.3f);
		if ((bool)joint)
		{
			Goplayer.AddForce(0f, 0f, 0f);
			Object.Destroy(joint);
		}
	}
}
