using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public GameObject Target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float distanceY; // Y�� ȸ�� ���̿� ���� �Ӱ谪 (��: 10�� �̻��� ���� ����)
    public float rotationSpeed; // B ������Ʈ�� ȸ�� �ӵ�

    private float previousRotationY;

    private void Start()
    {
        transform.position = new Vector3(Target.transform.position.x + offsetX, Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ);

        //// ó�� ������ �� A�� Y�� ȸ�� ���� ����
        //previousRotationY = Target.transform.rotation.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        //// A�� B�� ���� Y�� ȸ�� ��
        //float rotationAY = Target.transform.rotation.eulerAngles.y;
        //float rotationBY = transform.rotation.eulerAngles.y;

        //// Y�� ȸ�� ���� ���� ���
        //float deltaY = Mathf.Abs(rotationAY - rotationBY);

        //// 360������ 0���� �Ѿ�� ��� ���̸� �ùٸ��� ���
        //if (deltaY > 180)
        //{
        //    deltaY = 360 - deltaY;
        //}

        //// ���̰� �Ӱ谪(threshold) �̻��� ���
        //if (deltaY > distanceY)
        //{
        //    // B�� ������Ʈ ȸ�� �� ������Ʈ
        //    Vector3 newRotation = transform.rotation.eulerAngles;
        //    newRotation.y = rotationAY; // A�� Y�� ȸ�� ���� ����
        //    transform.rotation = Quaternion.Euler(newRotation);
        //}

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y,
            Target.transform.position.z);
        // A�� B�� ���� Y�� ȸ�� ��
        float rotationAY = Target.transform.rotation.eulerAngles.y;
        float rotationBY = transform.rotation.eulerAngles.y;

        // Y�� ȸ�� ���� ���� ���
        float deltaY = Mathf.Abs(rotationAY - rotationBY);

        // 360������ 0���� �Ѿ�� ��� ���̸� �ùٸ��� ���
        if (deltaY > 180)
        {
            deltaY = 360 - deltaY;
        }

        // ���̰� �Ӱ谪(threshold) �̻��� ���
        if (deltaY > distanceY)
        {
            // B ������Ʈ�� ��ǥ ȸ�� �� ����
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotationAY, transform.rotation.eulerAngles.z);

            // �ε巴�� ȸ��
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


        //    // ���� A�� Y�� ȸ�� ��
        //    float currentRotationY = Target.transform.rotation.eulerAngles.y;

        //    //// A�� ���� �����Ӱ� ���� ������ ���� Y�� ȸ�� ���� ���
        //    //float deltaY = currentRotationY - previousRotationY;

        //    // A�� ���� Y�� ȸ�� ���� ���� ���� ���� ���
        //    float deltaY = Mathf.Abs(currentRotationY - previousRotationY);

        //    // Y�� ȸ�� ���� 360������ 0���� �Ǵ� �� �ݴ�� �Ѿ�� ��� ó��
        //    if (deltaY > 180)
        //    {
        //        //deltaY -= 360;
        //        deltaY = 360 - deltaY;
        //    }
        //    //else if (deltaY < -180)
        //    //{
        //    //    deltaY += 360;
        //    //}

        //    //// B ������Ʈ�� ȸ���� deltaY�� ���� Y�� ȸ����Ű��
        //    //transform.Rotate(0, deltaY, 0);

        //    //// ���� Y�� ȸ�� �� ������Ʈ
        //    //previousRotationY = currentRotationY;

        //    if (deltaY > distanceY)
        //    {
        //        // B ������Ʈ�� A�� Y�� ȸ�� �� ����
        //        Vector3 newRotation = transform.rotation.eulerAngles;
        //        newRotation.y = currentRotationY; // A�� Y�� ȸ�� �� ����
        //        transform.rotation = Quaternion.Euler(newRotation);

        //        // ���� Y�� ȸ�� �� ������Ʈ
        //        previousRotationY = currentRotationY;
        //    }
    }
}
