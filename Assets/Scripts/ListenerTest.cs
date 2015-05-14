using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

public class ListenerTest : MonoBehaviour 
{
    [SerializeField]
    protected string condition;
    public EventDelegate del;
    private bool addedListener;


    private void Awake()
    {
        // print("addd listeners for " + name);
        if (!addedListener && del != null)
        {
            addedListener = true;
            AddListener();
        }
    }

    private void AddListener()
    {
        if (condition == "auto")
            Do();
        else
        {
            Messenger.Instance.AddListener(condition, del.target, del.methodName);
            
            
        }
    }

    public void Do()
    {
        del.oneShot = true;
        if (del.target != null)
        {
            del.Execute();
        }
        
    }

    protected void OnDestroy()
    {
        if (addedListener == true)
        {
            //Messenger.RemoveListener(condition, Do);
        }
    }


    
}
