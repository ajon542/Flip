using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public Texture2D face;
    public GameObject frontFace;

    private void Start()
    {
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
            GetComponent<Animator>().SetBool("Flip", true);
        }
    }
}
