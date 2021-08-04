using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_NO8 : MonoBehaviour
{

    //正确动作排序
    public List<int> M_List = new List<int>();
    public int Zhuanzheindex = 0;

    //左手碰撞的路径
    [HideInInspector]
    public List<int> LeftAndright_List = new List<int>();

    bool isLeftAndrightIndex = false;


    public bool AddLeftAndRightList(int index)
    {
        if (isLeftAndrightIndex)
        {
            if (LeftAndright_List.Count == Zhuanzheindex)
            {
                LeftAndright_List.Add(index);
            }
            else
            {
                if (index != LeftAndright_List[LeftAndright_List.Count - 1])
                {
                    LeftAndright_List.Add(index);
                }
            }
        }
        else
        {
            if (LeftAndright_List.Count == 0)
            {
                if (index == 1)
                {
                    LeftAndright_List.Add(index);
                }
            }
            else
            {
                if (index != LeftAndright_List[LeftAndright_List.Count - 1])
                {
                    LeftAndright_List.Add(index);
                }
            }
        }

        if (LeftAndright_List.Count == Zhuanzheindex)
        {
            isLeftAndrightIndex = !isLeftAndrightIndex;
        }
        else if (LeftAndright_List.Count == M_List.Count)
        {
            //判断
            if (ListBijiao(LeftAndright_List, M_List) == false)
            {
                M_gamemanager._instance.Leftscore(false);
                M_gamemanager._instance.Rightscore(false);
            }

            string str = "";

            for (int i = 0; i < LeftAndright_List.Count; i++)
            {
                str += LeftAndright_List[i];
            }

            print(str);

            bool ison = ListBijiao(LeftAndright_List, M_List);
            LeftAndright_List.Clear();
            isLeftAndrightIndex = false;
            return ison;
        }

        return false;
    }


    public bool ListBijiao(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count) { return false; };
        bool Ison = false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                Ison = true;
                break;
            }
        }

        return !Ison;
    }
}
