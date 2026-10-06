using UnityEngine;

public class CamDeadP2 : MonoBehaviour
{
	public Transform Ragdoll;

	private Vector3 camOffset;

	public float SmoothFactor = 0.5f;

	public Camera camDead;

	public AudioClip p2DIEsound;

	private void Start()
	{
		camOffset = transform.position - Ragdoll.position;
		GetComponent<AudioSource>().PlayOneShot(p2DIEsound);
	}

	private void Update()
	{
		if (GameObject.Find("DeadMiner(Clone)") != null)
		{
			Object.FindObjectOfType<GameManager>().EndGame();
		}
	}

	private void LateUpdate()
	{
		Vector3 b = Ragdoll.position + camOffset;
		transform.position = Vector3.Slerp(transform.position, b, SmoothFactor);
		transform.LookAt(Ragdoll);
	}
}
