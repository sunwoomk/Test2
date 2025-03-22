using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target; // 회전할 대상 오브젝트
    public float rotationSpeed = 50.0f; // 회전 속도

    void Update()
    {
        // 매 프레임마다 오브젝트를 중심으로 회전
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

        // 항상 대상 오브젝트를 바라보게 함
        transform.LookAt(target);
    }
}