using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setshou : MonoBehaviour
{
    public GameObject Lefthand;
    public GameObject Righthand;

    private void OnEnable()
    {
        switch (User_.H_handtype)
        {
            case User_.Handtype.lefthand:
                Lefthand.SetActive(true);
                Righthand.SetActive(false);
                break;
            case User_.Handtype.righthand:
                Righthand.SetActive(true);
                Lefthand.SetActive(false);
                break;
        }
    }

}
