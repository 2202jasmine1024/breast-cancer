using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengzhuang : MonoBehaviour
{
    public Type_name Hand_name = new Type_name();
    public int P_name = 0;

    public bool IsZhengque(Type_name type_)
    {

        if (Hand_name==type_)
        {
            switch (Hand_name)
            {
                case Type_name.left:
                    switch (M_gamemanager._instance.levelIndex)
                    {
                        case 1:
                            return transform.parent.GetComponent<p_NO2>().AddLeftList(P_name);
                        case 2:
                            return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                        case 3:
                            if (M_gamemanager._instance.IsLeftGebo)
                            {
                                return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                            }
                            return false;
                        case 4:
                            return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                        case 5:
                           // if (M_gamemanager._instance.IsLeftGebo)
                            //{
                                return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                            //}
                           // return false;
                        case 6:
                            //if (M_gamemanager._instance.IsLeftGebo)
                            //{
                                return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                           // }
                            //return false;
                        case 9:       
                            return transform.parent.GetComponent<P_NO3>().AddLeftList(P_name);
                    }
                    break;
                case Type_name.right:
                    switch (M_gamemanager._instance.levelIndex)
                    {
                        case 1:
                            return transform.parent.GetComponent<p_NO2>().AddRightList(P_name);
                        case 2:
                            print(transform.parent.GetComponent<P_NO3>());

                            return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                        case 3:
                            if (M_gamemanager._instance.IsRightGebo)
                            {
                                return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                            }
                            return false;
                        case 4:

                            return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                        case 5:
                            //if (M_gamemanager._instance.IsRightGebo)
                            //{
                                return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                           // }
                           // return false;
                        case 6:
                            //if (M_gamemanager._instance.IsRightGebo)
                            //{
                                return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                            //}
                          //  return false;
                        case 7:
                            //if (M_gamemanager._instance.IsRightGebo&&M_gamemanager._instance.IsLeftGebo)
                            //{
                                return transform.parent.GetComponent<P_NO8>().AddLeftAndRightList(P_name);
                           // }
                           //return false;
                        case 9:
                            return transform.parent.GetComponent<P_NO3>().AddRightList(P_name);
                    }
                    break;
            }
        }
 
        return false;
    }
}
