using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    public GameObject collectables;
    private int _totalCollectables;
    private int _pickedUp;

    private void Start()
    {
        _totalCollectables = collectables.transform.childCount;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Collectable")
        {
            return;
        }

        if (++_pickedUp == _totalCollectables)
        {
            Debug.Log("Game Over");
        }
    }
}
