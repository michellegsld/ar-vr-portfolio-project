using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To highlight breakable objects touched by weapons while held by Player
public class HighlightBreakable : MonoBehaviour
{
    public Material redHighlight;   // Breakable Highlight
    //public int flag = 0;            // To tell if hand is holding weapon

    private Material[] oldMats;     // Old materials of object
    private Material[] newMats;     // To replace the old materials

    Renderer breakable;              // Replace col.gameObject for readibility

    private int i = 0;              // Iterator for looping
    private int oldLen = 0;         // To assign to length of oldMats
    private int newLen = 0;         // To assign to length of newMats

    void OnCollisionEnter(Collision col) {
        // Check if the colliding object is a breakable
        if (col.gameObject.tag == "Breakable") {
            breakable = col.gameObject.GetComponent<Renderer>();
            oldMats = breakable.sharedMaterials;
            oldLen = oldMats.Length;
            newMats = new Material[oldLen + 1];
            for (i = 0; i < oldLen; i++) {
                newMats[i] = oldMats[i];
            }
            newMats[i] = redHighlight;
            breakable.sharedMaterials = newMats;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Breakable") {
            breakable = col.gameObject.GetComponent<Renderer>();
            oldMats = breakable.sharedMaterials;
            newLen = oldMats.Length - 1;
            newMats = new Material[newLen];
            for (i = 0; i < newLen; i++) {
                newMats[i] = oldMats[i];
            }
            breakable.sharedMaterials = newMats;
        }
    }
}
