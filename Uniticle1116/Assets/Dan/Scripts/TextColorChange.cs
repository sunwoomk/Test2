using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text button1; // 버튼의 텍스트 컴포넌트를 연결합니다.
    //public Text button2;
    private Color hoverColor = Color.yellow; // 마우스를 올렸을 때의 색상
    private Color originalColor1; // 원래의 색상
    //private Color originalColor2;

    private void Start()
    {
        if (/*button1 == null && button2 == null ||*/ button1 == null)
        {
            button1 = GetComponent<Text>();
            //button2 = GetComponent<Text>();
        }
        originalColor1 = button1.color; // 텍스트의 원래 색상을 저장
        //originalColor2 = button2.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button1.color = hoverColor; // 마우스를 올리면 색상 변경
        //button2.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button1.color = originalColor1; // 마우스가 버튼을 벗어나면 원래 색상으로 복구
        //button2.color = originalColor2;
    }
}
