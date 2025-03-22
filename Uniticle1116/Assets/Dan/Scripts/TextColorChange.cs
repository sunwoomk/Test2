using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text button1; // ��ư�� �ؽ�Ʈ ������Ʈ�� �����մϴ�.
    //public Text button2;
    private Color hoverColor = Color.yellow; // ���콺�� �÷��� ���� ����
    private Color originalColor1; // ������ ����
    //private Color originalColor2;

    private void Start()
    {
        if (/*button1 == null && button2 == null ||*/ button1 == null)
        {
            button1 = GetComponent<Text>();
            //button2 = GetComponent<Text>();
        }
        originalColor1 = button1.color; // �ؽ�Ʈ�� ���� ������ ����
        //originalColor2 = button2.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button1.color = hoverColor; // ���콺�� �ø��� ���� ����
        //button2.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button1.color = originalColor1; // ���콺�� ��ư�� ����� ���� �������� ����
        //button2.color = originalColor2;
    }
}
