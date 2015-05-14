using UnityEngine;
using System.Collections;

public class BroadCastOnKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(key))
        {
            Messenger.Broadcast(message);
        }
	}

    public KeyCode key;
    public string message;
    public string param;
     

}
