using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A5 : Areas
{
    string a5 = "area5";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a5);
        }
    }
}
