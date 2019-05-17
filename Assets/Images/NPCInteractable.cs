//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class NPCInteractable : MonoBehaviour
    {

        private Interactable interactable;
        public GameObject dialog;

		//-------------------------------------------------
		void Awake()
		{
            interactable = this.GetComponent<Interactable>();
		}


		

		//-------------------------------------------------
		// Called every Update() while a Hand is hovering over this object
		//-------------------------------------------------
		private void HandHoverUpdate( Hand hand )
		{
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {

				dialog.SetActive(true);

            }

		}


    }		
}
