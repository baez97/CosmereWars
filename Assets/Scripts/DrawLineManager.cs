using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class DrawLineManager : MonoBehaviour
{
    public GameObject tracked_obj;
    public Material mat;
    private LineRenderer currLine;
    private SteamVR_Input_Sources handType = SteamVR_Input_Sources.RightHand;
    // Start is called before the first frame update

    private int numClicks;
    private GameObject go;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SteamVR_Actions._default.GrabPinch.GetStateDown(handType) || Input.GetKeyDown(KeyCode.Space)) {

            go = new GameObject();

            currLine = go.AddComponent<LineRenderer>();
            currLine.startWidth = 0.1f;
            currLine.material = mat;

            numClicks = 0;

        } 

        else if (SteamVR_Actions._default.GrabPinch.GetState(handType) || Input.GetKey(KeyCode.Space)) {
            //Obsoleto
            //currLine.SetVertexCount(numClicks + 1);

            //Actualizado
            currLine.positionCount = numClicks + 1;

            currLine.SetPosition(numClicks,tracked_obj.transform.position);
            numClicks++;
        }
        else {
            Destroy (go);
            Debug.Log("Destroy");
        }
    }
}
