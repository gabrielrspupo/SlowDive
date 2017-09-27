using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandOnPlatform : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.parent = transform;
            //col.transform.GetComponent<Rigidbody2D> ().isKinematic = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            col.transform.parent = null;
            //col.transform.GetComponent<Rigidbody2D> ().isKinematic = false;
        }
    }
}
