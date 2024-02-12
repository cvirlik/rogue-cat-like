using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBechavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
