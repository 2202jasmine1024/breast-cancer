using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_No9 : MonoBehaviour
{
    public Type_name Hand_name = new Type_name();



    public bool Add_Punck(Type_name type_)
    {
        if (type_== Hand_name)
        {
            switch (Hand_name)
            {
                case Type_name.left:
                    if (M_gamemanager._instance.IsLeftGebo&&M_gamemanager._instance.IsRightGebo)
                    {
                        return true;
                    }
                    return false;
                case Type_name.right:
                    if (M_gamemanager._instance.IsLeftGebo && M_gamemanager._instance.IsRightGebo)
                    {
                        return true;
                    }
                    return false;
            }
        }
        return false;
    }
}
