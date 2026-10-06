using UnityEngine;

public class CamDead : MonoBehaviour
{
	public Transform Ragdoll;

	private Vector3 camOffset;

	public float SmoothFactor = 0.5f;

	public Camera camDead;

	public AudioClip p1DIEsound;

	private void Start()
	{
		camOffset = transform.position - Ragdoll.position;
		GetComponent<AudioSource>().PlayOneShot(p1DIEsound);
	}

	private void Update()
	{
		if (GameManager.NumberPlayers == 1)
		{
			camDead.rect = new Rect(0f, 0f, 1f, 1f);
		}
		if (GameManager.NumberPlayers == 2)
		{
			camDead.rect = new Rect(0f, 0f, 0.5f, 1f);
		}
		if (GameManager.NumberPlayers == 1 && GameObject.Find("DeadMiner(Clone)") != null)
		{
			Object.FindObjectOfType<GameManager>().EndGame();
		}
		if (GameManager.NumberPlayers == 2 && GameObject.Find("DeadMinerP2(Clone)") != null)
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
