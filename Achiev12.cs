using Steamworks;
using UnityEngine;

public class Achiev12 : MonoBehaviour
{
	// Componente de conquista do jogo. A lógica abaixo foi recuperada da Assembly-CSharp.
	// Inicialização do componente pelo Unity.
	private void Start()
	{
	}

	// Executa a lógica principal deste componente a cada frame.

	private void Update()
	{
	}

	// Processa uma colisão recebida pelo objeto.

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			SteamUserStats.SetAchievement("ACH_12");
			SteamUserStats.StoreStats();
		}
		if (col.gameObject.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_12");
			SteamUserStats.StoreStats();
		}
	}
}
