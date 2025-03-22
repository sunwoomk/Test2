using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour
{
    protected CameraSwiching cameraSwiching;

    protected virtual void Awake()
    {
        cameraSwiching = GameObject.FindWithTag("Areas").GetComponent<CameraSwiching>();
    }
}
