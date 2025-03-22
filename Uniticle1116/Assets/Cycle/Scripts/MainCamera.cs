using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target; // ȸ���� ��� ������Ʈ
    public float rotationSpeed = 50.0f; // ȸ�� �ӵ�

    void Update()
    {
        // �� �����Ӹ��� ������Ʈ�� �߽����� ȸ��
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

        // �׻� ��� ������Ʈ�� �ٶ󺸰� ��
        transform.LookAt(target);
    }
}