using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public Texture2D face;
    public GameObject frontFace;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("change");
            frontFace.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", face);
        }
    }
}
