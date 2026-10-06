using Steamworks;
using UnityEngine;

public class Achiev7 : MonoBehaviour
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
			SteamUserStats.SetAchievement("ACH_7");
			SteamUserStats.StoreStats();
		}
		if (col.gameObject.tag == "Player2")
		{
			SteamUserStats.SetAchievement("ACH_7");
			SteamUserStats.StoreStats();
		}
	}
}
