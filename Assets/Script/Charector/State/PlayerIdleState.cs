using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    protected StateManager stateManager;
    protected IPlayerStateManager playerState;

    public PlayerIdleState(StateManager stateManager, IPlayerStateManager playerStateManager)
    {
        this.stateManager = stateManager;
        this.playerState = playerStateManager;
    }


    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void UpdateLogic()
    {
        if (playerState.Controller.MoveInput != Vector2.zero)
        {
            stateManager.ChangeState(playerState.MoveState);
            return;
        }
    }

    public void UpdatePhysics()
    {
    }


}
