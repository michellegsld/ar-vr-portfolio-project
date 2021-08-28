using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject brokenPrefab; // Prefab. Broken version of object

    // Called on when an object collides in order to "break" it
    void OnCollisionEnter(Collision col) {
        // Only "breaks" if hit hard enough
        if (col.relativeVelocity.magnitude > 3) {
            // Instantiate a version of brokenPrefab to spawn broken version
            GameObject brokenVersion = Instantiate(brokenPrefab, transform.position, transform.rotation) as GameObject;

            // Create an array composed of the Rigidbodies of each piece that makes up the broken version
            Component[] debris = brokenVersion.GetComponentsInChildren<Rigidbody>();

            // Breaks off each piece based on velocity of original object
            foreach (Rigidbody rb in debris){
                CopyVelocity(gameObject.GetComponent<Rigidbody>(), rb);
            }

            // Delete the original version as object is now "broken"
            Destroy(gameObject);
        }
    }

    // Copies the x-axis and z-axis velocity of one rigidbody onto another
    void CopyVelocity(Rigidbody original, Rigidbody broken)
     {
         Vector3 vOriginal = original.velocity;
         Vector3 vBroken = broken.velocity;

         vBroken.x = vOriginal.x;
         vBroken.z = vOriginal.z;
         // Not copying y-axis because then they keep moving even if realistically shouldn't
         // (as if floor is ice, keep going to edges and won't stop, knock desks over)

         broken.velocity = vBroken;
     }
}
