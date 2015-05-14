using UnityEngine;
using System.Collections;

public class DebugText : MonoBehaviour 
{
    public string Hallo = "asdasdasdasd";
    public void DisplayAsdText(string hallo)
    {
        Debug.Log(hallo);
    }
}
