using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator anim;
    public bool a = true;
    public Rigidbody rigid;
    public float x = 0;
    public float z = 0;
    public Transform targetT;

    public Transform Camerapoint;
    public GameObject overUI;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("TestAnim");
    }

    private void Update()
    {

        x = rigid.transform.rotation.eulerAngles.x;
        z = rigid.transform.rotation.eulerAngles.z;

        // x 축 회전이 70도 이상 기울어진 경우
        if ((x > 80 && x < 290)) // 70 ~ 290도를 벗어난 경우 기울어진 상태로 간주
        {
            TriggerFall();
        }
        // z 축 회전이 70도 이상 기울어진 경우
        else if ((z > 80 && z < 290))
        {
            TriggerFall();
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("W", true);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("W_LeftA", true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("W_RightA", true);
            }
            else
            {
                anim.SetBool("W_LeftA", false);
                anim.SetBool("W_RightA", false);
            }
        }
        else
        {
            anim.SetBool("W", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("S", true);
        }
        else
        {
            anim.SetBool("S", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("UpA", true);
        }
        else
        {
            anim.SetBool("UpA", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("DownA", true);
        }
        else
        {
            anim.SetBool("DownA", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("LeftA", true);
        }
        else
        {
            anim.SetBool("LeftA", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("RightA", true);
        }
        else
        {
            anim.SetBool("RightA", false);
        }
    }

    private void TriggerFall()
    {
        if (!anim.GetBool("Fall")) // 이미 넘어짐 상태가 아닌 경우에만 실행
        {
            rigid.freezeRotation = true;              // 물리 회전 고정
            //targetT.eulerAngles = Vector3.zero;       // 회전 값 초기화
            targetT.eulerAngles = new Vector3(0f, Camerapoint.rotation.eulerAngles.y, 0f);
            anim.SetBool("Fall", true);               // 넘어지는 애니메이션 호출

            if (overUI.activeSelf == false)
            {
                overUI.SetActive(true);
            }
        }
    }
}
