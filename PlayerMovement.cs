using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	// Altura usada nos testes de inclinação do chão.
	private float playerHeight = 2f;

	// Referência usada para transformar o input em movimento relativo à orientação do jogador.
	public Transform orientation;

	[Header("Movement")]
	public float moveSpeed = 10f;

	public float slideSpeed = 100f;

	public float airMultiplier = 0.35f;

	public float movementMultiplier = 3f;

	[Header("Sprinting")]
	public float walkSpeed = 8.5f;

	// Velocidade com que moveSpeed se aproxima de walkSpeed.
	[SerializeField]
	private float acceleration = 10f;

	[Header("Jumping")]
	public float jumpForce = 15f;

	// Permite um segundo salto enquanto o jogador está no ar.
	public bool canDoubleJump = true;

	[Header("Keybinds")]
	[Header("Drag")]
	public float groundDrag = 1.2f;

	public float airDrag = 0.07f;

	// Valores brutos dos eixos Horizontal e Vertical.
	private float horizontalMovement;

	private float verticalMovement;

	// Indica se o jogador está sobre uma superfície de slide.
	public bool onSlide;

	// Direção de movimento calculada a partir dos inputs.
	private Vector3 moveDirection;

	private Vector3 slopeMoveDirection;

	private Rigidbody rb;

	// Resultado do Raycast usado para detectar uma superfície inclinada.
	private RaycastHit slopeHit;

	public bool wallLeft;

	public bool wallRight;

	private RaycastHit leftWallHit;

	private RaycastHit rightWallHit;

	// Vida atual do jogador.
	public int currentHealth;

	public Text healthText;

	// Enquanto false, o jogador está temporariamente protegido contra dano.
	public bool canDamage = true;

	public bool dead;

	// Prefab do Rigidbody usado depois que o jogador morre.
	public Rigidbody DeadRagDoll;

	public GameObject charAnime;

	// Efeito de fumaça criado durante o slide.
	public Rigidbody smokefoot;

	// Prefab usado para criar o segundo jogador.
	public GameObject player2;

	public LayerMask GroundObject;

	public float slopeForceRayLength = 1.5f;

	public AudioClip jumpsound;

	public AudioClip damagesound;

	public float inputDeadZone;

	// Estado de chão, atualizado pelos Raycasts.
	public bool isGrounded { get; private set; }

	// Verifica se existe uma superfície inclinada abaixo do jogador.
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

	// Cópia funcionalmente idêntica de OnSlope presente na decompilação.
	private bool OnSlope2()
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

	private void Start()
	{
		// Obtém o Rigidbody e impede que a física gire o jogador.
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;

		// O jogador começa com 5 pontos de vida.
		currentHealth = 5;
		// No modo para dois jogadores, cria o segundo jogador ao lado do primeiro.
		if (GameManager.NumberPlayers == 2)
		{
			Object.Instantiate(player2, new Vector3(orientation.position.x + 1f, orientation.position.y, orientation.position.z), orientation.rotation);
		}
	}

	private void Update()
	{
		// Atualiza o texto da vida na interface.
		healthText.text = currentHealth.ToString();
		// Raycast de até 2 unidades para determinar se o jogador está no chão.
		Ray ray = new Ray(transform.position, Vector3.down);
		isGrounded = Physics.Raycast(ray, out var _, 2f);
		// A tag "Slide" abaixo do jogador ativa o estado de slide.
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
		// Ordem original do processamento principal do jogador.
		MyInput();
		ControlDrag();
		ControlSpeed();
		PlayerDead();
		Anime();
		// Salto normal: o jogador precisa estar no chão.
		if (Input.GetButtonDown("Jump") && isGrounded && isGrounded)
		{
			GetComponent<AudioSource>().PlayOneShot(jumpsound);
			canDoubleJump = true;
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
		// Segundo salto: permitido no ar enquanto canDoubleJump estiver ativo.
		if (Input.GetButtonDown("Jump") && !isGrounded && canDoubleJump)
		{
			GetComponent<AudioSource>().PlayOneShot(jumpsound);
			rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			canDoubleJump = false;
		}
	}

	// Lê os inputs brutos e converte-os para a direção da orientação do jogador.
	private void MyInput()
	{
		horizontalMovement = Input.GetAxisRaw("Horizontal");
		verticalMovement = Input.GetAxisRaw("Vertical");
		moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
	}

	// Aproxima gradualmente a velocidade atual da velocidade de caminhada.
	private void ControlSpeed()
	{
		moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
	}

	// Usa mais resistência no chão e menos resistência no ar.
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

	// Atualiza a física do jogador no ciclo de física do Unity.
	private void FixedUpdate()
	{
		MovePlayer();
		// Objetos com a tag "Box" também são tratados como superfície de chão.
		if (Physics.Raycast(new Ray(base.transform.position, Vector3.down), out var hitInfo, 2f) && hitInfo.transform.tag == "Box")
		{
			isGrounded = true;
			rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Force);
		}
		// Cair abaixo da altura do objeto "Water" zera a vida.
		Transform transform = GameObject.FindWithTag("Water").transform;
		if (base.transform.position.y < transform.position.y)
		{
			currentHealth = 0;
		}
		// Aplica as forças de movimento, incluindo chão, inclinação, ar e slide.
		void MovePlayer()
		{
			// Movimento normal no chão.
			if (isGrounded && !OnSlope() && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
			}
			// Movimento sobre uma superfície inclinada.
			else if (isGrounded && OnSlope() && !onSlide)
			{
				rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
				rb.AddForce(Vector3.up.normalized * moveSpeed * 3f, ForceMode.Acceleration);
			}
			// No ar, o movimento recebe apenas uma fração da força normal.
			else if (!isGrounded && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier / 2f, ForceMode.Acceleration);
			}
			// Durante o slide, empurra para frente, para baixo e cria o efeito de fumaça.
			if (onSlide)
			{
				rb.AddRelativeForce(Vector3.forward * moveSpeed, ForceMode.Force);
				rb.AddRelativeForce(Vector3.forward * moveSpeed * 3.3f, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * moveSpeed * 13f, ForceMode.Acceleration);
				Object.Instantiate(smokefoot, new Vector3(orientation.position.x, orientation.position.y - 1f, orientation.position.z), orientation.rotation);
			}
			// Ray criado mas não usado na decompilação original.
			new Ray(base.transform.position, Vector3.down);
			if (Physics.Raycast(base.transform.position, Vector3.down, out var _, (int)GroundObject) && !isGrounded && !onSlide)
			{
				rb.AddForce(moveDirection.normalized * 3.2f, ForceMode.Acceleration);
				rb.AddForce(Vector3.down * 2f, ForceMode.Acceleration);
			}
		}
	}

	// Trata dano e colisões fatais.
	private void OnCollisionEnter(Collision col)
	{
		// Colidir com "Damage" remove 1 de vida e inicia 1 segundo de invulnerabilidade.
		if (canDamage && col.gameObject.tag == "Damage")
		{
			GetComponent<AudioSource>().PlayOneShot(damagesound);
			currentHealth--;
			canDamage = false;
			GameObject.Find("GunTip").GetComponent<ShotBullets>().tipotiro = 1;
			StartCoroutine(DamageDelay());
		}
		// A tag "Dead" mata imediatamente.
		if (col.gameObject.tag == "Dead")
		{
			currentHealth = 0;
		}
	}

	// Triggers com a tag "Dead" também matam o jogador.
	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Dead")
		{
			currentHealth = 0;
		}
	}

	// Aguarda 1 segundo antes de permitir dano novamente.
	private IEnumerator DamageDelay()
	{
		yield return new WaitForSeconds(1f);
		canDamage = true;
	}

	// Converte a morte lógica em destruição do jogador e criação do ragdoll.
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

	// Escolhe a animação de acordo com movimento, salto, slide e estado de dano.
	private void Anime()
	{
		if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("parado");
		}
		if (Input.GetAxisRaw("Vertical") > 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("frente");
		}
		if (Input.GetAxisRaw("Vertical") < 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("tras");
		}
		if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") != 0f && isGrounded && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("lateral");
		}
		if (!isGrounded && canDoubleJump && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("jump");
		}
		if (!isGrounded && !canDoubleJump && rb.velocity.y > 0f && !onSlide && canDamage && GameObject.Find("GunPosition").GetComponent<GrapplingGun>().lr.positionCount == 0)
		{
			charAnime.GetComponent<Animation>().Play("jumpdouble1");
		}
		if (!isGrounded && !canDoubleJump && rb.velocity.y < 0f && !onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("jumpdesce");
		}
		if (onSlide && canDamage)
		{
			charAnime.GetComponent<Animation>().Play("slide1");
		}
		if (!canDamage)
		{
			charAnime.GetComponent<Animation>().Play("dano");
		}
	}
}
