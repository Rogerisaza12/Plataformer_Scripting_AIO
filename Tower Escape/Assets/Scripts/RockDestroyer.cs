using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroyer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
         if(other.gameObject.tag == "Roca")
        {
            Destroy(other.gameObject);
        }

    }
}
