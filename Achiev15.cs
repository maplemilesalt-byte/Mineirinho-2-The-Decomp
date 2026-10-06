using Steamworks;
using UnityEngine;

public class Achiev15 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		SteamUserStats.SetAchievement("ACH_15");
		SteamUserStats.StoreStats();
	}
}
