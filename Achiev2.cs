using Steamworks;
using UnityEngine;

public class Achiev2 : MonoBehaviour
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

	// Processa a entrada do objeto em um Collider configurado como trigger.

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player")
		{
			SteamUserStats.SetAchievement("ACH_2");
			SteamUserStats.StoreStats();
		}
		if (target.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_2");
			SteamUserStats.StoreStats();
		}
	}
}
