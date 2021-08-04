using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttonsize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,IPointerUpHandler
{
    Vector3 MySize;
    bool isclick = false;

    private void Start()
    {
        MySize = this.transform.localScale;
    }


    //鼠标滑过
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(MySize.x+0.1f,MySize.y+0.1f,MySize.z+0.1f);
    }
    //鼠标滑出
    public void OnPointerExit(PointerEventData eventData)
    {
       // this.GetComponent<Image>().sprite = Mysprite;
        this.transform.localScale = MySize;
    }

    //鼠标抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        isclick = false;
    }
    //鼠标按下
    public void OnPointerDown(PointerEventData eventData)
    {
        isclick = true;
    }


   
}
