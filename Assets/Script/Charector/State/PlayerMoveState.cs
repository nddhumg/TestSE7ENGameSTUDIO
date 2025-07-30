using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IState
{
    protected StateManager stateManager;
    protected IPlayerStateManager playerState;
    protected float speed = 30;
    public PlayerMoveState(StateManager stateManager, IPlayerStateManager playerStateManager)
    {
        this.stateManager = stateManager;
        this.playerState = playerStateManager;
        speed = playerStateManager.Controller.Speed;
    }


    public void Enter()
    {
        //speed = 10;
        playerState.Controller.Animator.SetFloat("Blend", 1);
    }

    public void Exit()
    {
        playerState.Controller.Animator.SetFloat("Blend", 0);
    }

    public void UpdateLogic()
    {
        if (playerState.Controller.MoveInput == Vector2.zero)
        {
            stateManager.ChangeState(playerState.IdleState);
            return;
        }
        Vector2 direction = (playerState.Controller.MoveInput).normalized;
        float angleLook = Vector2.Angle(direction, Vector2.up);
        Vector3 positionNew = playerState.Controller.transform.position + speed * Time.deltaTime * new Vector3(direction.x, 0, direction.y);
        playerState.Controller.transform.position = ClampInTouchLine(positionNew);
        playerState.Controller.transform.rotation = Quaternion.Euler(0, direction.x >= 0 ? angleLook : -angleLook, 0);
    }

    public void UpdatePhysics()
    {
    }

    private Vector3 ClampInTouchLine(Vector3 position)
    {
        return new Vector3(
            Mathf.Clamp(position.x, GameManager.instance.TouchLine.w, GameManager.instance.TouchLine.y)
            , position.y
            , Mathf.Clamp(position.z, GameManager.instance.TouchLine.z, GameManager.instance.TouchLine.x));

    }
}
