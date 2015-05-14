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
            Messenger.Instance.Broadcast(message);
        }
	}

    public KeyCode key;
    public string message;
     

}
