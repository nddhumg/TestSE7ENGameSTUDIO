using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : StateManager, IPlayerStateManager
{
    protected IState idleState;
    protected IState moveState;
    ControllerPlayer controllerPlayer;

    public PlayerStateManager(ControllerPlayer controller)
    {
        controllerPlayer = controller;
        idleState = new PlayerIdleState(this, this);
        moveState = new PlayerMoveState(this, this);

        ChangeState(idleState);
    }
    public override void Update()
    {
        base.Update();
    }

    public IState IdleState => idleState;

    public IState MoveState => moveState;

    public ControllerPlayer Controller => controllerPlayer;



}
