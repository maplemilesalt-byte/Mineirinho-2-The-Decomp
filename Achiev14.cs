using Steamworks;
using UnityEngine;

public class Achiev14 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		SteamUserStats.SetAchievement("ACH_14");
		SteamUserStats.StoreStats();
	}
}
