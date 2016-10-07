using UnityEngine;
using System.Collections;

public class SoftwareAssert : MonoBehaviour
{
    public static void Confirm(bool value, string message, params object[] args)
    {
        // If false; error!
        if (!value)
        {
            string errorMessage = string.Format(message, args);
            Debug.LogError(errorMessage);

            // TODO: Possibly break here.
        }
    }
}
