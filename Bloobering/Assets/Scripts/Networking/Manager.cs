using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Manager : NetworkManager {
	private List<GameObject> players = new List<GameObject>();
	public Transform respawnArea;
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
        int index = Random.Range(0, startPositions.Count - 1);
        GameObject player = (GameObject)GameObject.Instantiate(playerPrefab,startPositions[index].position, Quaternion.identity);
        
		players.Add(player);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
   
}
