using UnityEngine;
using System.Collections;

public class DebugText : MonoBehaviour 
{
    [SerializeField]
    private string text;

    public void DisplayText()
    {
        Debug.Log(text);
    }
}
