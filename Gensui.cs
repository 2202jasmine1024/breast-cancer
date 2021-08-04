using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gensui : MonoBehaviour
{
    public Transform target;
    public bool Ison;
    void Update()
    {
        transform.position = target.position;

        if (Ison==false)
        {
            transform.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y + 90, 0);
        }
    }
}
