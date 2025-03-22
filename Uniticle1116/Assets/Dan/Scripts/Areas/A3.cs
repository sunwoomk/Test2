using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3 : Areas
{
    string a3 = "area3";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a3);
        }
    }
}
