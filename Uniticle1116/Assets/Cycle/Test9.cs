using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test9 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Test10.Instance.MoveUp();
    }
}
