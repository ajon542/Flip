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

    private void Update()
    {
        // Example of swapping card face texture.
        if (Input.GetKeyDown(KeyCode.C))
        {
            frontFace.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", face);
        }

        // Flip the card.
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Flip", true);
        }
    }
}
