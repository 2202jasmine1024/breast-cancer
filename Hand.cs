using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 左、右手柄控制
/// </summary>
/// 
public enum Type_name
{
    left,
    right,
    Null
}

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Hand : MonoBehaviour
{
    SteamVR_TrackedObject trackedobj;//追踪的设备 就是我们的手柄 
    SteamVR_Controller.Device device;//获取手柄的输入
    public Type_name name_s = new Type_name();

    float timeindex = 0;
    bool Ison = false;

    void Start()
    {
        trackedobj = GetComponent<SteamVR_TrackedObject>();
    }

    private void Update()
    {
        if (Ison)
        {
            timeindex += Time.deltaTime;
            if (timeindex>=0.8f)
            {
                timeindex = 0;
                Ison = false;
            }
        }   
    }

    void LateUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedobj.index);

        switch (name_s)
        {
            case Type_name.left:
                //左手的方法
                OnLift_hand();
                break;
            case Type_name.right:
                //右手的方法
                OnRight_hand();
                break;
        }
    }

    //左手方法
    public void OnLift_hand()
    {
        switch (M_gamemanager._instance.levelIndex)
        {
            case 0:
                if (Ison==false)
                {
                    if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)&&User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                        Ison = true;
                    }
                }    
                break;
            case 1:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }
                break;
            case 2:
                if (go!=null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }       
                break;
            case 3:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }
                break;
            case 5:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }
                break;
            case 6:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }
                break;
            case 7:
                if (go != null)
                {
                    M_gamemanager._instance.IsLeftGebo = true;
                }
                break;
            case 9:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.lefthand)
                    {
                        M_gamemanager._instance.Leftscore(true);
                    }
                }
                break;
        }
    }

    //YOU手方法
    public void OnRight_hand()
    {
        switch (M_gamemanager._instance.levelIndex)
        {
            case 0:
                if (Ison==false)
                {
                    if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                        Ison = true;
                    }
                }      
                break;
            case 1:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {        
                        M_gamemanager._instance.Rightscore(true);
                    }
                }
                break;
            case 2:
                if (go!=null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                    }
                }         
                break;
            case 3:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                    }
                }
                break;
            case 5:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                    }
                }
                break;
            case 6:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                    }
                }
                break;
            case 7:
                if (go != null)
                {
                  //  M_gamemanager._instance.IsRightGebo = true;
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s))
                    {
                        //Debug.Log(Vector3.Distance(M_gamemanager._instance.leftHand.transform.position, M_gamemanager._instance.rightHand.transform.position) < 0.1f);
                        if (Vector3.Distance(M_gamemanager._instance.leftHand.transform.position, M_gamemanager._instance.rightHand.transform.position) < 0.15f)
                        {
                            switch (User_.H_handtype)
                            {
                                case User_.Handtype.lefthand:
                                    M_gamemanager._instance.Leftscore(true);
                                    break;
                                case User_.Handtype.righthand:
                                    M_gamemanager._instance.Rightscore(true);
                                    break;
                            }
                        }                                                 
                    }
                }
                break;
            case 9:
                if (go != null)
                {
                    if (go.GetComponent<Pengzhuang>().IsZhengque(name_s) && User_.H_handtype == User_.Handtype.righthand)
                    {
                        M_gamemanager._instance.Rightscore(true);
                    }
                }
                break;
        }
    }

    [HideInInspector]
    public GameObject go = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pengzhuang>() != null)
        {
            go = other.gameObject;
        }
        else if (other.tag == "leftGebo")
        {
            if (name_s == Type_name.right)
            {
                M_gamemanager._instance.IsLeftGebo = true;
                if (other.GetComponent<yincang>()!=null)
                {
                    other.GetComponent<yincang>().M_hide();
                }
            }
        }
        else if (other.tag == "rightGebo")
        {
            if (name_s== Type_name.left)
            {
                M_gamemanager._instance.IsRightGebo = true;
                if (other.GetComponent<yincang>() != null)
                {
                    if (other.GetComponent<yincang>() != null)
                    {
                        other.GetComponent<yincang>().M_hide();
            
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (go!=null)
        {
            go = null;

            if (M_gamemanager._instance.levelIndex==8)
            {
                if (name_s == Type_name.right)
                {
                    M_gamemanager._instance.IsRightGebo = false;
                }
                else if (name_s == Type_name.left)
                {
                    M_gamemanager._instance.IsLeftGebo = false;
                }
            }
        }

        if (other.tag == "leftGebo")
        {
            if (name_s == Type_name.right)
            {
                M_gamemanager._instance.IsLeftGebo = false;
                if (other.GetComponent<yincang>() != null)
                {
                    other.GetComponent<yincang>().M_Show();
                }
            }
        }
        else if (other.tag == "rightGebo")
        {
            if (name_s == Type_name.left)
            {
                M_gamemanager._instance.IsRightGebo = false;
                if (other.GetComponent<yincang>() != null)
                {
                    other.GetComponent<yincang>().M_Show();
                }
            }
        }
    }
}
