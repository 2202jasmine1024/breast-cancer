using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_NO3 : MonoBehaviour
{
    //正确动作排序
    public List<int> M_List = new List<int>();
    public int Zhuanzheindex = 0;

    //左手碰撞的路径
    [HideInInspector]
    public List<int> Left_List = new List<int>();

    //右手碰撞的路径
    [HideInInspector]
    public List<int> Right_List = new List<int>();

    bool isLeftIndex = false;
    bool isrightIndex = false;

    public bool AddLeftList(int index)
    {
        if (isLeftIndex)
        {
            if (Left_List.Count == Zhuanzheindex)
            {
                Left_List.Add(index);
            }
            else
            {
                if (index != Left_List[Left_List.Count - 1])
                {
                    Left_List.Add(index);
                }
            }
        }
        else
        {
            if (Left_List.Count==0)
            {
                if (index==1)
                {
                    Left_List.Add(index);
                }
            }
            else
            {
                if (index!= Left_List[Left_List.Count-1])
                {
                    Left_List.Add(index);
                }
            } 
        }

        if (Left_List.Count == Zhuanzheindex)
        {
            isLeftIndex = !isLeftIndex;
        }
        else if (Left_List.Count == M_List.Count)
        {
            //判断
            if (ListBijiao(Left_List, M_List)==false)
            {
                M_gamemanager._instance.Leftscore(false);
            }

            string str = "";

            for (int i = 0; i < Left_List.Count; i++)
            {
                str += Left_List[i];
            }
            print(str);


            bool ison = ListBijiao(Left_List, M_List);
            Left_List.Clear();
            isLeftIndex = false;
            return ison;
        }

        return false;
    }

    public bool AddRightList(int index)
    {
     //   print(Right_List.Count+"   "+ Zhuanzheindex);

        if (isrightIndex)
        {
            if (Right_List.Count == Zhuanzheindex)
            {
                Right_List.Add(index);
            }
            else
            {
                if (index != Right_List[Right_List.Count - 1])
                {
                    Right_List.Add(index);
                }
            }
        }
        else
        {
            if (Right_List.Count == 0)
            {
                if (index==1)
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
        }

        if (Right_List.Count == Zhuanzheindex)
        {
            isrightIndex = !isrightIndex;
        }
        else if (Right_List.Count == M_List.Count)
        {
            //判断
            if (ListBijiao(Right_List, M_List) == false)
            {
                M_gamemanager._instance.Rightscore(false);
            }

            bool ison = ListBijiao(Right_List, M_List);
            Right_List.Clear();
            isrightIndex = false;
            return ison;
        }

        return false;
    }

    public bool ListBijiao(List<int> list1,List<int> list2)
    {
        if (list1.Count != list2.Count) { return false; };
        bool Ison = false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i]!=list2[i])
            {
                Ison = true;
                break;
            }
        }

        return !Ison;
    }
}
