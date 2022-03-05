using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach(Transform x in transform)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(x.position, 1f);
        }

        Gizmos.color = Color.green;
        for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0). position);
    }

    public Transform GetNextPath(Transform currentPath)
    {
        if(currentPath == null)
        {
            return transform.GetChild(0);
        }

        if(currentPath.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentPath.GetSiblingIndex() + 1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
}
