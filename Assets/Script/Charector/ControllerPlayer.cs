using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : MonoBehaviour
{
    //[SerializeField] private CharacterController characterController;
    //[SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    private PlayerStateManager playerStateManager;
    private Vector2 moveInput;
    public Vector2 MoveInput => moveInput;
    public Animator Animator => animator;
    public float Speed => speed;


    private void Start()
    {
        playerStateManager = new PlayerStateManager(this);
    }

    private void Update()
    {
        playerStateManager.Update();
    }

    private void FixedUpdate()
    {
        playerStateManager.FixedUpdate();
    }

    public void OnMove(InputAction.CallbackContext context) {
       moveInput = context.action.ReadValue<Vector2>();
    }

}
