using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Manager : NetworkManager {
	private List<GameObject> players = new List<GameObject>();
	public Transform respawnArea;
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		var player = (GameObject)GameObject.Instantiate(playerPrefab,startPositions[Random.Range(0,startPositions.Capacity)].position, Quaternion.identity);
		players.Add(player);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
