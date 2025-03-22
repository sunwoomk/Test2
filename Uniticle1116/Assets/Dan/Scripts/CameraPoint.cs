using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public GameObject Target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float distanceY; // Y축 회전 차이에 따른 임계값 (예: 10도 이상일 때만 적용)
    public float rotationSpeed; // B 오브젝트의 회전 속도

    private float previousRotationY;

    private void Start()
    {
        transform.position = new Vector3(Target.transform.position.x + offsetX, Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ);

        //// 처음 시작할 때 A의 Y축 회전 값을 저장
        //previousRotationY = Target.transform.rotation.eulerAngles.y;
    }

    private void FixedUpdate()
    {
        //// A와 B의 현재 Y축 회전 값
        //float rotationAY = Target.transform.rotation.eulerAngles.y;
        //float rotationBY = transform.rotation.eulerAngles.y;

        //// Y축 회전 값의 차이 계산
        //float deltaY = Mathf.Abs(rotationAY - rotationBY);

        //// 360도에서 0도로 넘어가는 경우 차이를 올바르게 계산
        //if (deltaY > 180)
        //{
        //    deltaY = 360 - deltaY;
        //}

        //// 차이가 임계값(threshold) 이상인 경우
        //if (deltaY > distanceY)
        //{
        //    // B의 오브젝트 회전 값 업데이트
        //    Vector3 newRotation = transform.rotation.eulerAngles;
        //    newRotation.y = rotationAY; // A의 Y축 회전 값을 적용
        //    transform.rotation = Quaternion.Euler(newRotation);
        //}

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y,
            Target.transform.position.z);
        // A와 B의 현재 Y축 회전 값
        float rotationAY = Target.transform.rotation.eulerAngles.y;
        float rotationBY = transform.rotation.eulerAngles.y;

        // Y축 회전 값의 차이 계산
        float deltaY = Mathf.Abs(rotationAY - rotationBY);

        // 360도에서 0도로 넘어가는 경우 차이를 올바르게 계산
        if (deltaY > 180)
        {
            deltaY = 360 - deltaY;
        }

        // 차이가 임계값(threshold) 이상인 경우
        if (deltaY > distanceY)
        {
            // B 오브젝트의 목표 회전 값 설정
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotationAY, transform.rotation.eulerAngles.z);

            // 부드럽게 회전
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


        //    // 현재 A의 Y축 회전 값
        //    float currentRotationY = Target.transform.rotation.eulerAngles.y;

        //    //// A의 이전 프레임과 현재 프레임 간의 Y축 회전 차이 계산
        //    //float deltaY = currentRotationY - previousRotationY;

        //    // A의 이전 Y축 회전 값과 현재 값의 차이 계산
        //    float deltaY = Mathf.Abs(currentRotationY - previousRotationY);

        //    // Y축 회전 값이 360도에서 0도로 또는 그 반대로 넘어가는 경우 처리
        //    if (deltaY > 180)
        //    {
        //        //deltaY -= 360;
        //        deltaY = 360 - deltaY;
        //    }
        //    //else if (deltaY < -180)
        //    //{
        //    //    deltaY += 360;
        //    //}

        //    //// B 오브젝트의 회전에 deltaY를 더해 Y축 회전시키기
        //    //transform.Rotate(0, deltaY, 0);

        //    //// 이전 Y축 회전 값 업데이트
        //    //previousRotationY = currentRotationY;

        //    if (deltaY > distanceY)
        //    {
        //        // B 오브젝트에 A의 Y축 회전 값 적용
        //        Vector3 newRotation = transform.rotation.eulerAngles;
        //        newRotation.y = currentRotationY; // A의 Y축 회전 값 적용
        //        transform.rotation = Quaternion.Euler(newRotation);

        //        // 이전 Y축 회전 값 업데이트
        //        previousRotationY = currentRotationY;
        //    }
    }
}
