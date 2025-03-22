using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2 : Areas
{
    string a2 = "area2";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a2);
        }
    }
}
