using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


// This class is used to pick items up
// This script was found in this tutorial, around this time:
// https://youtu.be/MKOc8J877tI?t=210
public class SimpleAttach : MonoBehaviour
{
    // The item being grabbed
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    private void OnHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }

    private void OnHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        // Grab the object
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        // Release the object
        else if (isGrabEnding) {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
