using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    private Rigidbody rb;
    private float timeElantris = 10;
    private float timeRoshar = 10;
    private float timeScadrial = 10;

    public static bool droppedElantris = false;
    public static bool droppedRoshar = false;
    public static bool droppedScadrial = false;

    private bool pr = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.name == "Elantris" && droppedElantris){
            timeElantris -= Time.deltaTime;
            if (timeElantris <= 0){
                rb.useGravity = false;
                this.transform.position = originalPosition;
                this.transform.rotation = originalRotation;
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                droppedElantris = false;
                timeElantris = 10;
            }
        }

        if (this.gameObject.name == "Roshar" && droppedRoshar){
            timeRoshar -= Time.deltaTime;
            if (timeRoshar <= 0){
                rb.useGravity = false;
                this.transform.position = originalPosition;
                this.transform.rotation = originalRotation;
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                droppedRoshar = false;
                timeRoshar = 10;
            }
        }

        if (this.gameObject.name == "Scadrial" && droppedScadrial){
            timeScadrial -= Time.deltaTime;
            if (timeScadrial <= 0){
                rb.useGravity = false;
                this.transform.position = originalPosition;
                this.transform.rotation = originalRotation;
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                droppedScadrial = false;
                timeScadrial = 10;
            }
        }
    }
}
