using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPersona : MonoBehaviour
{
    public int scoreValue;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }    
    }
}
