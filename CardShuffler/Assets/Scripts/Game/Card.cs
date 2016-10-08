using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public Texture2D face;
    public GameObject frontFace;

    private Animator animator;

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
        animator.SetBool("Deal", false);
        animator.SetBool("Flip", false);
        animator.Play("Card_Reset");
    }

    /// <summary>
    /// Deal the card to the player.
    /// </summary>
    public void DealCard()
    {
        animator.SetBool("Deal", true);
    }

    /// <summary>
    /// Flip the card over to reveal the suit and rank.
    /// </summary>
    public void FlipCard()
    {
        animator.SetBool("Flip", true);
    }

    /// <summary>
    /// Flip the card.
    /// </summary>
    private void Update()
    {
        //// TODO: There is a bug here, it flips automatically instead of waiting for user.
        if (Input.GetMouseButton(0))
        {
            FlipCard();
        }
    }
}
