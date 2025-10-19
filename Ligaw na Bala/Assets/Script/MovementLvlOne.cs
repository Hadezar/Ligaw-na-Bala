using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLvlOne : MonoBehaviour
{
    [Tooltip("The speed at which the player moves.")]
    public float moveSpeed = 5f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        animator.SetBool("isWalking", Mathf.Abs(horizontalInput) > 0.01f);

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (horizontalInput > 0) // Moving Right (D key)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0) // Moving Left (A key)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}