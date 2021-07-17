using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public string lastPosition;

    private Animator animator;
    public bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D myRigidbody;

    private AudioManager audioManager;
    private DialogueManager dialogManager;

    private PlayerMove playerMove;
    public bool doingSomething;

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        dialogManager = FindObjectOfType<DialogueManager>();
        audioManager = GetComponent<AudioManager>();

        playerMove = new PlayerMove(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (dialogManager.dialogActive)
        {
            audioManager.Stop("Walking");
            playerMoving = false;
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        playerMove.Move(myRigidbody, audioManager, animator, moveSpeed);
    }
}