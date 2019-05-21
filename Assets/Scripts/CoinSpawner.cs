using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public GameObject spawnPoint;


	private void Start(){
		//SpawnCoin();
	}
	public void SpawnCoin(){
		
		GameObject currentCoin = Instantiate(gameObject);
		currentCoin.transform.position = spawnPoint.transform.position;
	}
}
