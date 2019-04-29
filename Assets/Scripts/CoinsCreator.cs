using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCreator : MonoBehaviour
{
	public GameObject coinPrefab;
	public GameObject trackedObj;


	public void SpawnCoin(){
		GameObject currentCoin = Instantiate(coinPrefab);
		//currentCoin.transform.parent = trackedObj.transform;
		currentCoin.transform.position = trackedObj.transform.position;
		//currentCoin.transform.parent = null;
	}
}
