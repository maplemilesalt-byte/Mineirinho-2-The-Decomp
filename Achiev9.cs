using Steamworks;
using UnityEngine;

public class Achiev9 : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			SteamUserStats.SetAchievement("ACH_9");
			SteamUserStats.StoreStats();
		}
		if (col.gameObject.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_9");
			SteamUserStats.StoreStats();
		}
	}
}
