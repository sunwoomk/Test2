using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A6 : Areas
{
    string a6 = "area6";

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraSwiching.AreasReset();

            cameraSwiching.WeherColling(a6);
        }
    }
}
