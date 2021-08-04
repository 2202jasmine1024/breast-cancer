using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jianzhou : MonoBehaviour
{

    public Type_name Hand_name = new Type_name();

    bool Ison = false;
    float timeindex = 0;

    private void Update()
    {
        if (Ison)
        {
            timeindex += Time.deltaTime;
            if (timeindex >= 0.8f)
            {
                timeindex = 0;
                Ison = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (M_gamemanager._instance.levelIndex==8)
        {
            switch (Hand_name)
            {
                case Type_name.left:
                    if (User_.H_handtype== User_.Handtype.lefthand)
                    {
                        if (other.GetComponent<P_No9>() != null)
                        {
                            if (Ison == false)
                            {
                                if (other.GetComponent<P_No9>().Add_Punck(Hand_name))
                                {
                                    M_gamemanager._instance.Leftscore(true);
                                }
                            }
                        }
                    }
                 
                    break;
                case Type_name.right:
                    if (User_.H_handtype == User_.Handtype.righthand)
                    {
                        if (other.GetComponent<P_No9>() != null)
                        {
                            if (Ison == false)
                            {
                                if (other.GetComponent<P_No9>().Add_Punck(Hand_name))
                                {
                                    M_gamemanager._instance.Leftscore(true);
                                }
                            }
                        }
                    }
                    break;
            }
           
        }
        else if (M_gamemanager._instance.levelIndex == 4)
        {
            if (other.GetComponent<P_no5>() != null)
            {
                if (other.GetComponent<P_no5>().Add_Punck(Hand_name))
                {
                    switch (Hand_name)
                    {
                        case Type_name.left:
                            M_gamemanager._instance.Leftscore(true);
                            break;
                        case Type_name.right:
                            M_gamemanager._instance.Rightscore(true);
                            break;
                    }
                }
            }
        }  
    }

}
