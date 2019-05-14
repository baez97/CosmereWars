using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCreator : MonoBehaviour
{
	public GameObject coinPrefab;
	public GameObject tracked_obj;


	
	private void Start(){
		GameObject currentCoin = Instantiate(coinPrefab);
		currentCoin.transform.parent = tracked_obj.transform;
		currentCoin.transform.localPosition = new Vector3(-0.1f,-0.1f,-0.1f);
		//currentCoin.transform.position = this.transform.position;
		//currentCoin.transform.parent = null;
	}
	public void SpawnCoin(){
		GameObject currentCoin = Instantiate(coinPrefab);
		currentCoin.transform.parent = tracked_obj.transform;
		currentCoin.transform.localPosition = new Vector3(-0.1f,-0.1f,-0.1f);

		//currentCoin.transform.position = this.transform.position;
		//currentCoin.transform.parent = null;
	}
}
