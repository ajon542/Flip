using UnityEngine;
using System;
using System.Collections;

public class Card : MonoBehaviour
{
    public Texture2D face;
    public GameObject frontFace;

    private Animator animator;

    public bool IsMagic { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Set the face texture of the card.
    /// </summary>
    /// <param name="faceTex">The face texture.</param>
    public void SetFaceTexture(Texture2D faceTex)
    {
        frontFace.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", faceTex);
    }

    /// <summary>
    /// Reset the card to the initial state.
    /// </summary>
    public void ResetCard()
    {
        IsMagic = false;
        GetComponent<Magic>().Reset();

        if (animator != null)
        {
            animator.SetBool("Deal", false);
            animator.SetBool("Flip", false);
            animator.Play("Card_Reset");
        }
    }

    /// <summary>
    /// Deal the card to the player.
    /// </summary>
    public void DealCard()
    {
        if (animator != null)
        {
            animator.SetBool("Deal", true);
        }
    }

    /// <summary>
    /// Flip the card over to reveal the suit and rank.
    /// </summary>
    public void FlipCard()
    {
        if (animator != null)
        {
            animator.SetBool("Flip", true);
        }
    }

    /// <summary>
    /// Flip the card.
    /// </summary>
    private void Update()
    {
        if (animator == null)
        {
            return;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Card_Idle") &&
            Input.GetMouseButton(0))
        {
            FlipCard();
        }
    }

    /// <summary>
    /// Notification of flip complete.
    /// </summary>
    public void FlipComplete()
    {
        if (IsMagic)
        {
            GetComponent<Magic>().Play();
        }
    }
}
