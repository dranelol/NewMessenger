using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Messenger : MonoBehaviour 
{
    private Dictionary<string, EventDelegate> events = new Dictionary<string, EventDelegate>();
    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    private static Messenger _instance;

    public static Messenger Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<Messenger>();
            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }

    public void AddListener(string eventType, MonoBehaviour target, string methodName)
    {
        events[eventType] = new EventDelegate(target, methodName);
    }

    public void Broadcast(string eventType)
    {
        if (events.ContainsKey(eventType) == true)
        {
            events[eventType].Execute();
        }

        else
        {
            Debug.LogError("Messenger does not contain a listener for event type: " + eventType);
        }
    }
}
