using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private CameraFollow cameraFollow;

    public CameraFollow CameraFollow => cameraFollow;
    
}
