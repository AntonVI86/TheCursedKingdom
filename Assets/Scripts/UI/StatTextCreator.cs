using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTextCreator : MonoBehaviour
{
    public void DestroyAllChild()
    {
        if(transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
