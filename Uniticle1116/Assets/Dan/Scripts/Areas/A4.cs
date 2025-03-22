using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A4 : Areas
{
    string a4 = "area4";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a4);
        }
    }
}
