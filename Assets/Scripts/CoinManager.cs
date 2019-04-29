using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject trackedObj;
    private GameObject currentCoin;
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
		AttachCoin();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AttachCoin(){
            currentCoin = Instantiate(coinPrefab);
            currentCoin.transform.parent = trackedObj.transform;
			currentCoin.transform.localPosition = new Vector3(0f, 0f, 0f);        
    }

	public void RemoveCoin(){
		currentCoin = null;
	}

}
