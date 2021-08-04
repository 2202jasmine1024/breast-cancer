using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class M_mune : MonoBehaviour
{

    public InputField Yanzhengma;
    public Toggle LeftHand;
    public Toggle RightHand;
    public Text TishiText;

    public void m_Loing()
    {
        if (!string.IsNullOrEmpty(Yanzhengma.text))
        {
            if (Yanzhengma.text=="0000")
            {
                if (LeftHand.isOn)
                {
                    User_.H_handtype = User_.Handtype.lefthand;
                }

                if (RightHand.isOn)
                {
                    User_.H_handtype = User_.Handtype.righthand;             
                }

                if (User_.H_handtype!= User_.Handtype.Null)
                {
                    SceneManager.LoadScene("01.kangfu");
                }
                else
                {
                    TishiText.text = "请选择患侧手";
                    Invoke("TEXTclear", 3);
                }
            }
            else
            {
                TishiText.text = "验证码输入错误";
                Invoke("TEXTclear", 3);
            }
        }
        else
        {
            TishiText.text = "请输入验证码";
            Invoke("TEXTclear", 3);
        }
    }

    public void TEXTclear()
    {
        TishiText.text = "";
    }
}
