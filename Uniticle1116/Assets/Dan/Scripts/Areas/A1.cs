using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1 : Areas
{
    string a1 = "area1";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a1);
        }
    }
}
