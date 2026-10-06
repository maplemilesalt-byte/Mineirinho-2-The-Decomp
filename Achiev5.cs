using Steamworks;
using UnityEngine;

public class Achiev5 : MonoBehaviour
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
			SteamUserStats.SetAchievement("ACH_5");
			SteamUserStats.StoreStats();
		}
		if (target.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_5");
			SteamUserStats.StoreStats();
		}
	}
}
