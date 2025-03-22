using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleController : MonoBehaviour
{
    public WheelCollider wheelCollider1;  // Wheel�� Wheel Collider
    public WheelCollider wheelCollider2;  // Wheel�� Wheel Collider
    public Rigidbody frameRigidbody;     // Frame�� Rigidbody
    public Transform frameTransform;     // Frame�� Transform
    public float motorTorque = 3f;     // ����/���� �� ������ ���� ��ũ
    public float turnSpeed = 0.3f;        // Y�� ���� ȸ�� �ӵ�
    public float balanceForce = 0.2f;      // ������ ��� ���� ��
    public float tiltForce = 0.2f;        // �¿� ����̱� ��
    public HingeJoint frameHingeJoint;
    public float maxTurnSpeed = 1f;

    private void FixedUpdate()
    {
        // W, S�� ���� ����
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
        // ȸ�� (A/D)
        float turnInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            turnInput = -1f; // ���� ȸ��
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnInput = 1f; // ������ ȸ��
        }

        if (turnInput != 0f)
        {
            // Y�� ȸ�� ����
            float turnTorque = turnInput * turnSpeed;
            frameRigidbody.AddTorque(Vector3.up * turnTorque);

            // ȸ�� �� �ӵ� ����
            Vector3 horizontalVelocity = new Vector3(frameRigidbody.velocity.x, 0, frameRigidbody.velocity.z);
            if (horizontalVelocity.magnitude > maxTurnSpeed)
            {
                Vector3 clampedVelocity = horizontalVelocity.normalized * maxTurnSpeed;
                frameRigidbody.velocity = new Vector3(clampedVelocity.x, frameRigidbody.velocity.y, clampedVelocity.z);
            }
        }

        /*
        // A, D�� �������� Y�� ���� ȸ��
        float turn = 0;
        
        // AD Ű �Է��� ����
        if (Input.GetKey(KeyCode.A))
        {
            turn = -turnSpeed;  // ��ȸ��
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turn = turnSpeed;   // ��ȸ��
        }
        // Y���� �������� ȸ���ϴ� ��ũ�� �߰�
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
