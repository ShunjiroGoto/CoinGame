using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDelieter : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}