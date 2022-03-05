using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Path path;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentPath;
    // Start is called before the first frame update
    void Start()
    {
        currentPath = path.GetNextPath(currentPath);
        transform.position = currentPath.position;

        currentPath = path.GetNextPath(currentPath);
        transform.LookAt(currentPath);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPath.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPath.position) < distanceThreshold)
        {
            currentPath = path.GetNextPath(currentPath);
            transform.LookAt(currentPath);
        }
    }
}
