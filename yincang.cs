using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yincang : MonoBehaviour
{

    public GameObject YincangObj;

    public void M_hide()
    {
        YincangObj.SetActive(false);
    }

    public void M_Show()
    {
        YincangObj.SetActive(true);
    }

}
