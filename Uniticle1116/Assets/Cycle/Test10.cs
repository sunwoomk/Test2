using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test10 : MonoBehaviour
{
    public static Test10 Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void MoveUp()
    {
        Debug.Log("test");
        Vector3 currentPosition = transform.position;
        currentPosition.y += 0.05f;
        transform.position = currentPosition;
    }
}
