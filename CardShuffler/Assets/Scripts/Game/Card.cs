using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public Texture2D face;
    public GameObject frontFace;

    private void Start()
    {
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
        GetComponent<Animator>().SetBool("Deal", false);
        GetComponent<Animator>().SetBool("Flip", false);

        GetComponent<Animator>().Play("Card_Reset");
    }

    /// <summary>
    /// Deal the card to the player.
    /// </summary>
    public void DealCard()
    {
        GetComponent<Animator>().SetBool("Deal", true);
    }

    /// <summary>
    /// Flip the card over to reveal the suit and rank.
    /// </summary>
    public void FlipCard()
    {
        GetComponent<Animator>().SetBool("Flip", true);
    }

    private void Update()
    {
        // Flip the card.
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlipCard();
        }
    }
}
