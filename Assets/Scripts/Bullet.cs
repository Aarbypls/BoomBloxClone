using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DestroyObject), 5f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
