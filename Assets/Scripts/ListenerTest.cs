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

    [SerializeField]
    private ListenerType returnType;

    [SerializeField]
    private ListenerType argumentOne;

    [SerializeField]
    private ListenerType argumentTwo;

    [SerializeField]
    private ListenerType argumentThree;

    private void Awake()
    {
        Type ret;

        Type argOne;

        Type argTwo;

        Type argThree;
        
        switch(returnType)
        {
            case ListenerType.None:
                ret = typeof(void);
                break;
            case ListenerType.Int:
                ret = typeof(int);
                break;
            case ListenerType.Float:
                ret = typeof(float);
                break;
            case ListenerType.GameObject:
                ret = typeof(GameObject);
                break;
            default:
                ret = null;
                break;
        }

        switch (argumentOne)
        {
            case ListenerType.None:
                argOne = null;
                break;
            case ListenerType.Int:
                argOne = typeof(int);
                break;
            case ListenerType.Float:
                argOne = typeof(float);
                break;
            case ListenerType.GameObject:
                argOne = typeof(GameObject);
                break;
            default:
                argOne = null;
                break;
        }

        switch (argumentTwo)
        {
            case ListenerType.None:
                argTwo = null;
                break;
            case ListenerType.Int:
                argTwo = typeof(int);
                break;
            case ListenerType.Float:
                argTwo = typeof(float);
                break;
            case ListenerType.GameObject:
                argTwo = typeof(GameObject);
                break;
            default:
                argTwo = null;
                break;
        }

        switch (argumentThree)
        {
            case ListenerType.None:
                argThree = null;
                break;
            case ListenerType.Int:
                argThree = typeof(int);
                break;
            case ListenerType.Float:
                argThree = typeof(float);
                break;
            case ListenerType.GameObject:
                argThree = typeof(GameObject);
                break;
            default:
                argThree = null;
                break;
        }





        // print("addd listeners for " + name);
        if (!addedListener && del != null)
        {
            addedListener = true;
            AddListener(ret, argOne, argTwo, argThree);
        }
    }

    private void AddListener(Type retType, Type argOne, Type argTwo, Type argThree)
    {
        if (condition == "auto")
            Do();
        else
        {
            // print(name + " is listening for " + condition);

                //var test = retType.GetType();
                //Messenger.AddListener(condition, Do);

           // Messenger.AddListener(Do, condition);
            
            //Messenger.AddListener<

            //Messenger.MakePermanent(condition);

            var methodInfo = typeof(ListenerTest).GetMethod("Do");

            if(returnType == ListenerType.None)
            {
                //Messenger.AddListener(retType, condition, methodInfo);
                string methodName = "Do";
                MethodInfo mtd = GetType().GetMethod(methodName,
                                   System.Reflection.BindingFlags.Instance
                                 | System.Reflection.BindingFlags.Public
                                 | System.Reflection.BindingFlags.NonPublic
                                 | System.Reflection.BindingFlags.InvokeMethod);

                Messenger.AddListener(gameObject, condition, mtd);
            }

            else
            {
                
            }
            
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
