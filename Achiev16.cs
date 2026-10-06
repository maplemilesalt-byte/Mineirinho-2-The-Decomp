using Steamworks;
using UnityEngine;

public class Achiev16 : MonoBehaviour
{
	// Componente de conquista do jogo. A lógica abaixo foi recuperada da Assembly-CSharp.
	// Inicialização do componente pelo Unity.
	private void Start()
	{
	}

	// Executa a lógica principal deste componente a cada frame.

	private void Update()
	{
		SteamUserStats.SetAchievement("ACH_16");
		SteamUserStats.StoreStats();
	}
}
