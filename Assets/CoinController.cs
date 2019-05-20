using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CoinController : MonoBehaviour {
  // Start is called before the first frame update
  public GameObject spawnPoint;
  public GameObject coin;
  public GameObject tracked_obj;
  private Rigidbody rb;


  void Start () {
  }

  // Update is called once per frame


  public void OnPickUp (GameObject gameObject) {
    SpawnCoin ();
    Debug.Log("Hola");
  }

  public  void OnDetach (GameObject gameObject) {
    gameObject.GetComponent<Rigidbody> ().useGravity = true;
    gameObject.GetComponent<Rigidbody>().isKinematic = false;
    gameObject.GetComponent<TrailRenderer>().enabled = true;
  }

  public void SpawnCoin () {
    Debug.Log("Spawn");
    GameObject currentCoin = Instantiate (coin);
		currentCoin.transform.parent = tracked_obj.transform;
		currentCoin.transform.localPosition = new Vector3(0,0,0);
    currentCoin.transform.rotation = Quaternion.identity;

    currentCoin.GetComponent<TrailRenderer>().enabled = false;
    rb = currentCoin.GetComponent<Rigidbody> ();
    rb.isKinematic = true;
  }
}