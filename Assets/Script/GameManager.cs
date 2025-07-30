using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> goals;
    [SerializeField] private List<Ball> balls;
    [SerializeField] private float goalWidth;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float timeResetCamera = 2f;
    [SerializeField] private Vector4 touchline;
    public List<GameObject> Goals => goals;

    public List<Ball> Balls => balls;
    /// <summary>
    /// Represents the boundary of the soccer field.
    /// touchline.x => Top boundary (upper touchline)
    /// touchline.y => Right boundary (right touchline)
    /// touchline.z => Bottom boundary (lower touchline)
    /// touchline.w => Left boundary (left touchline)
    /// </summary>
    public Vector4 TouchLine => touchline;

    public float GoalWidth => goalWidth;

    public IEnumerator ResetCameraTarget()
    {
        yield return new WaitForSeconds(timeResetCamera);
        CameraManager.instance.CameraFollow.SetTarget(playerTransform);
    }
}
