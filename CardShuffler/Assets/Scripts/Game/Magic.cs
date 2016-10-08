using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour
{
    public void Play()
    {
        // Change tint of card to red if magic.
        //// TODO: Very basic!!
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Front")
            {
                child.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 0, 0, 1));
            }
        }
    }
}
