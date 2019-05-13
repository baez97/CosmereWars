using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCreator : MonoBehaviour
{
	public GameObject coinPrefab;


	public void SpawnCoin(){
		GameObject currentCoin = Instantiate(coinPrefab);
		//currentCoin.transform.parent = trackedObj.transform;
		currentCoin.transform.position = this.transform.position;
		//currentCoin.transform.parent = null;
	}
}
