using Steamworks;
using UnityEngine;

public class Achiev4 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player")
		{
			SteamUserStats.SetAchievement("ACH_4");
			SteamUserStats.StoreStats();
		}
		if (target.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_4");
			SteamUserStats.StoreStats();
		}
	}
}
