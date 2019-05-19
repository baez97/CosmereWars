using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
  // Start is called before the first frame update
  public GameObject spawnPoint;
  public GameObject coin;
  void Start () {
  }

  // Update is called once per frame
  void Update () {

  }

  public void OnPickUp (GameObject gameObject) {
    SpawnCoin ();
  }

  public  void OnDetach (GameObject gameObject) {
    gameObject.GetComponent<Rigidbody> ().useGravity = true;
    gameObject.GetComponent<Rigidbody>().isKinematic = false;
  }

  public void SpawnCoin () {

    GameObject currentCoin = Instantiate (coin);
    currentCoin.transform.position = spawnPoint.transform.position;
    currentCoin.GetComponent<Rigidbody> ().isKinematic = true;
  }
}