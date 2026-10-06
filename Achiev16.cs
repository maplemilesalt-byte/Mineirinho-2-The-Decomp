using Steamworks;
using UnityEngine;

public class Achiev16 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		SteamUserStats.SetAchievement("ACH_16");
		SteamUserStats.StoreStats();
	}
}
