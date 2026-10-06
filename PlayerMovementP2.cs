using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementP2 : MonoBehaviour
{
	// Código decompilado; comentários adicionados para documentar o comportamento original.
	private float playerHeight = 2f;

	public Transform orientation;

	[Header("Movement")]
	public float moveSpeed = 10f;

	public float slideSpeed = 100f;

	public float airMultiplier = 0.35f;

	public float movementMultiplier = 3f;

	[Header("Sprinting")]
	public float walkSpeed = 8.5f;

	[SerializeField]
	private float acceleration = 10f;

	[Header("Jumping")]
	public float jumpForce = 15f;

	public bool canDoubleJump = true;

	[Header("Keybinds")]
	[Header("Drag")]
	public float groundDrag = 1.2f;

	public float airDrag = 0.07f;

	private float horizontalMovement;

	private float verticalMovement;

	public bool onSlide;

	private Vector3 moveDirection;

	private Vector3 slopeMoveDirection;

	private Rigidbody rb;

	private RaycastHit slopeHit;

	public bool wallLeft;

	public bool wallRight;

	private RaycastHit leftWallHit;

	private RaycastHit rightWallHit;

	public int currentHealth;

	public Text healthText;

	public bool canDamage = true;

	public bool dead;

	public Rigidbody DeadRagDoll;

	public GameObject charAnime;

	public Rigidbody smokefoot;

	public float slopeForceRayLength = 1.5f;

	public LayerMask GroundObject;

	public AudioClip P2jumpsound;

	public AudioClip P2damagesound;

	public bool isGrounded { get; private set; }

	// Rotina do componente; comportamento preservado da decompilação original.

	private bool OnSlope()
	{
		if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2f * slopeForceRayLength))
		{
			if (slopeHit.normal != Vector3.up)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		currentHealth = 5;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Update()
	{
		healthText.text = currentHealth.ToString();
		Ray ray = new Ray(transform.position, Vector3.down);
		isGrounded = Physics.Raycast(ray, out var _, 2f);
		if (Physics.Raycast(new Ray(transform.position, Vector3.down), out var hitInfo2, 2f))
		{
			if (hitInfo2.transform.tag == "Slide")
			{
				onSlide = true;
			}
			else
			{
				onSlide = false;
			}
		}
		else
		{
			onSlide = false;
		}
		MyInput();
		ControlDrag();
		ControlSpeed();
		PlayerDead();
		Anime();
		if (Input.GetButtonDown("JumpP2") && isGrounded && isGrounded)
		{
			GetComponent<AudioSource>().PlayOneShot(P2jumpsound);
			canDoubleJump = true;
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
		if (Input.GetButtonDown("JumpP2") && !isGrounded && canDoubleJump)
		{
			GetComponent<AudioSource>().PlayOneShot(P2jumpsound);
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			canDoubleJump = false;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void MyInput()
	{
		horizontalMovement = Input.GetAxisRaw("HorizontalP2");
		verticalMovement = Input.GetAxisRaw("VerticalP2");
		moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void ControlSpeed()
	{
		moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void ControlDrag()
	{
		if (isGrounded)
		{
			rb.drag = groundDrag;
		}
		else
		{
			rb.drag = airDrag;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void FixedUpdate()
	{
		MovePlayer();
		if (Physics.Raycast(new Ray(base.transform.position, Vector3.down), out var hitInfo, 2f) && hitInfo.transform.tag == "Box")
		{
			isGrounded = true;
			rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Force);
		}
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			currentHealth = 0;
		}
		void MovePlayer()
		{
			if (isGrounded && !OnSlope() && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
			}
			else if (isGrounded && OnSlope() && !onSlide)
			{
				rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
				rb.AddForce(Vector3.up.normalized * moveSpeed * 3f, ForceMode.Acceleration);
			}
			else if (!isGrounded && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier / 2f, ForceMode.Acceleration);
			}
			if (onSlide)
			{
				rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
				rb.AddRelativeForce(Vector3.forward * moveSpeed * 3.3f, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * moveSpeed * 13f, ForceMode.Acceleration);
				Object.Instantiate(smokefoot, new Vector3(orientation.position.x, orientation.position.y - 1f, orientation.position.z), orientation.rotation);
			}
			new Ray(base.transform.position, Vector3.down);
			if (Physics.Raycast(base.transform.position, Vector3.down, out var _, (int)GroundObject) && !isGrounded && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * 3.2f, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * 2f, ForceMode.Acceleration);
			}
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnCollisionEnter(Collision col)
	{
		if (canDamage && col.gameObject.tag == "Damage")
		{
			GetComponent<AudioSource>().PlayOneShot(P2damagesound);
			currentHealth--;
			canDamage = false;
			GameObject.Find("GunTipP2").GetComponent<ShotBulletsP2>().tipotiro = 1;
			StartCoroutine(DamageDelay());
		}
		if (col.gameObject.tag == "Dead")
		{
			currentHealth = 0;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Dead")
		{
			currentHealth = 0;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private IEnumerator DamageDelay()
	{
		yield return new WaitForSeconds(1f);
		canDamage = true;
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void PlayerDead()
	{
		if (currentHealth <= 0)
		{
			dead = true;
			Object.Destroy(gameObject);
			Object.Instantiate(DeadRagDoll, orientation.position, orientation.rotation).velocity = transform.TransformDirection(new Vector3(0f, 100f, 100f));
		}
		else
		{
			dead = false;
		}
	}

	// Rotina do componente; comportamento preservado da decompilação original.

	private void Anime()
	{
		if (Input.GetAxisRaw("VerticalP2") == 0f && Input.GetAxisRaw("HorizontalP2") == 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("paradoP2");
		}
		if (Input.GetAxisRaw("VerticalP2") > 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("frenteP2");
		}
		if (Input.GetAxisRaw("VerticalP2") < 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("trasP2");
		}
		if (Input.GetAxisRaw("VerticalP2") == 0f && Input.GetAxisRaw("HorizontalP2") != 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("lateralP2");
		}
		if (!isGrounded && canDoubleJump && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("jumpP2");
		}
		if (!isGrounded && !canDoubleJump && rb.velocity.y > 0f && !onSlide && canDamage && GameObject.Find("GunPositionP2").GetComponent<GrapplingGunP2>().lr.positionCount == 0)
		{
			charAnime.GetComponent<Animation>().Play("jumpdoubleP2");
		}
		if (!isGrounded && !canDoubleJump && rb.velocity.y < 0f && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("jumpdesceP2");
		}
		if (onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("slideP2");
		}
		if (!canDamage)
		{
			charAnime.GetComponent<Animation>().Play("danoP2");
		}
	}
}
