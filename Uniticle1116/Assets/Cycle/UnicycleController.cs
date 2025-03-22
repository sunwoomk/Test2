using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleController : MonoBehaviour
{
    public WheelCollider wheelCollider1;  // Wheel의 Wheel Collider
    public WheelCollider wheelCollider2;  // Wheel의 Wheel Collider
    public Rigidbody frameRigidbody;     // Frame의 Rigidbody
    public Transform frameTransform;     // Frame의 Transform
    public float motorTorque = 3f;     // 전진/후진 시 바퀴에 가할 토크
    public float turnSpeed = 0.3f;        // Y축 기준 회전 속도
    public float balanceForce = 0.2f;      // 균형을 잡기 위한 힘
    public float tiltForce = 0.2f;        // 좌우 기울이기 힘
    public HingeJoint frameHingeJoint;
    public float maxTurnSpeed = 1f;

    private void FixedUpdate()
    {
        // W, S로 전진 후진
        if (Input.GetKey(KeyCode.W))
        {
            wheelCollider1.motorTorque = motorTorque;
            wheelCollider2.motorTorque = motorTorque;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            wheelCollider1.motorTorque = -motorTorque;
            wheelCollider2.motorTorque = -motorTorque;
        }

        /*
        else if (Input.GetKey(KeyCode.A))
        {
            wheelCollider1.motorTorque = motorTorque + turnSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            wheelCollider2.motorTorque = motorTorque + turnSpeed;
        }
        */
        else
        {
            wheelCollider1.motorTorque = 0;
            wheelCollider2.motorTorque = 0;
        }
        // 회전 (A/D)
        float turnInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            turnInput = -1f; // 왼쪽 회전
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnInput = 1f; // 오른쪽 회전
        }

        if (turnInput != 0f)
        {
            // Y축 회전 적용
            float turnTorque = turnInput * turnSpeed;
            frameRigidbody.AddTorque(Vector3.up * turnTorque);

            // 회전 시 속도 제한
            Vector3 horizontalVelocity = new Vector3(frameRigidbody.velocity.x, 0, frameRigidbody.velocity.z);
            if (horizontalVelocity.magnitude > maxTurnSpeed)
            {
                Vector3 clampedVelocity = horizontalVelocity.normalized * maxTurnSpeed;
                frameRigidbody.velocity = new Vector3(clampedVelocity.x, frameRigidbody.velocity.y, clampedVelocity.z);
            }
        }

        /*
        // A, D로 프레임의 Y축 기준 회전
        float turn = 0;
        
        // AD 키 입력을 받음
        if (Input.GetKey(KeyCode.A))
        {
            turn = -turnSpeed;  // 좌회전
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turn = turnSpeed;   // 우회전
        }
        // Y축을 기준으로 회전하는 토크를 추가
        float rotation = turn * Time.deltaTime;
        //Vector3 torque = new Vector3(0, turn, 0);
        //frameRigidbody.AddTorque(torque);
        frameRigidbody.transform.Rotate(0, rotation, 0);
        */

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 hingeAxisWorld = frameHingeJoint.transform.TransformDirection(frameHingeJoint.axis);
            frameRigidbody.angularVelocity = hingeAxisWorld * balanceForce;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 hingeAxisWorld = frameHingeJoint.transform.TransformDirection(frameHingeJoint.axis);
            frameRigidbody.angularVelocity = -hingeAxisWorld * balanceForce;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            frameRigidbody.angularVelocity = frameRigidbody.transform.forward * tiltForce;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            frameRigidbody.angularVelocity = -frameRigidbody.transform.forward * tiltForce;
        }
    }
}
