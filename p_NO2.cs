using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class p_NO2 : MonoBehaviour
{
    //正确动作排序
    public List<int> M_List = new List<int>();

    //左手碰撞的路径
    [HideInInspector]
    public List<int> Left_List = new List<int>();

    //右手碰撞的路径
    [HideInInspector]
    public List<int> Right_List = new List<int>();


    public bool AddLeftList(int index)
    {
        if (Left_List.Count == 0)
        {
            if (index == 1)
            {
                Left_List.Add(index);
            }
        }
        else
        {
            if (index != Left_List[Left_List.Count - 1])
            {
                Left_List.Add(index);
            }
        }

        if (Left_List.Count == M_List.Count)
        {
            string str = "";
            for (int i = 0; i < Left_List.Count; i++)
            {
                str += Left_List[i];
            }

            print("left" + str);

            //判断
            if (ListBijiao(Left_List, M_List) == false)
            {
                M_gamemanager._instance.Leftscore(false);
            }

            bool ison = ListBijiao(Left_List, M_List);
            Left_List.Clear();
            return ison;
        }

        return false;
    }

    public bool AddRightList(int index)
    {
        if (Right_List.Count == 0)
        {
            if (index == 1)
            {
                Right_List.Add(index);
            }
        }
        else
        {
            if (index != Right_List[Right_List.Count - 1])
            {
                Right_List.Add(index);
            }
        }

        if (Right_List.Count == M_List.Count)
        {
            //判断
            if (ListBijiao(Right_List, M_List) == false)
            {
                M_gamemanager._instance.Rightscore(false);
            }

            bool ison = ListBijiao(Right_List, M_List);
            Right_List.Clear();
            return ison;
        }

        return false;
    }

    public bool ListBijiao(List<int> list1, List<int> list2)
    {
        List<int> Result = list1.Intersect(list2).ToList<int>();
        return (list2.Count - Result.Count <= 2);
    }
}
