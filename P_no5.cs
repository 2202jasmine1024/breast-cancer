using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_no5 : MonoBehaviour
{

    float timer = 0;
    bool ison = false;

    float r_timer = 0;
    bool r_ison = false;
    private void Update()
    {
        if (ison)
        {
            timer += Time.deltaTime;
            if (timer>=2f)
            {
                timer = 0;
                ison = false;
            }
        }

        if (r_ison)
        {
            r_timer += Time.deltaTime;
            if (r_timer>=2f)
            {
                r_timer = 0;
                r_ison = false;
            }
        }
    }

    public bool Add_Punck(Type_name type_)
    {
            switch (type_)
            {
                case Type_name.left:
                if (ison==false)
                {
                    if (M_gamemanager._instance.IsLeftGebo && M_gamemanager._instance.IsRightGebo)
                    {
                        ison = true;
                        return true;
                    }
                   
                }
                 
                    return false;
                case Type_name.right:

                if (r_ison==false)
                {
                    if (M_gamemanager._instance.IsLeftGebo && M_gamemanager._instance.IsRightGebo)
                    {
                        r_ison = true;
                        return true;
                    }
                   
                }
                    
                    return false;
            }
        
        return false;
    }
}
