using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speedCamera;

    private void LateUpdate()
    {
        Vector3 directionMove = speedCamera * Time.deltaTime *(target.position - transform.position).normalized;
        directionMove.y = 0;
        transform.position += directionMove;
    }

    public void SetTarget(Transform targetNew)
    {
        this.target = targetNew;
    }
}
