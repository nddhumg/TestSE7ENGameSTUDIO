using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateManager 
{
    IState IdleState { get; }
    IState MoveState { get; }
    ControllerPlayer Controller { get; }
}
