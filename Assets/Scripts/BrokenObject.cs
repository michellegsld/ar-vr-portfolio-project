using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    public GameObject brokenPrefab; // drag the debris prefab here
     public float force = 500;
     public float radius = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.relativeVelocity.magnitude > 3) {
            GameObject brokenVersion = Instantiate(brokenPrefab, transform.position, transform.rotation) as GameObject;

            Vector3 pos = col.contacts[0].point;
            Component[] debris = brokenVersion.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in debris){
                rb.AddExplosionForce(force, pos, radius);
            }
            Destroy(gameObject);
        }
    }

}
