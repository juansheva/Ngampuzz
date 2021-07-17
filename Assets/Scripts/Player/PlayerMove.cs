using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    private PlayerController playerController;

    private const string WALKING = "Walking";

    public PlayerMove(PlayerController _playerController)
    {
        playerController = _playerController;
    }

    public void Move(Rigidbody2D _myRigidbody, AudioManager _audioManager, Animator _animator, float _moveSpeed)
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        Vector2 movementInput = new Vector2(inputHorizontal, inputVertical);
        movementInput.Normalize();
        _myRigidbody.velocity = movementInput * _moveSpeed;

        if (playerController.doingSomething)
        {
            _audioManager.Stop(WALKING);
            playerController.playerMoving = false;
            _myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (movementInput.magnitude != 0)
        {
            playerController.playerMoving = true;
            playerController.lastMove = new Vector2(movementInput.x, movementInput.y);
            _audioManager.Play(WALKING);
        }
        else
        {
            playerController.playerMoving = false;
            _audioManager.Stop(WALKING);
        }
        _animator.SetFloat("MoveX", inputHorizontal);
        _animator.SetFloat("MoveY", inputVertical);
        _animator.SetBool("PlayerMoving", playerController.playerMoving);
        _animator.SetFloat("LastMoveX", playerController.lastMove.x);
        _animator.SetFloat("LastMoveY", playerController.lastMove.y);
    }
}