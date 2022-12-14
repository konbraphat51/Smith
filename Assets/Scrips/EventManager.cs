using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent<string>> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent<string>>();
        }
    }

    /// <summary>
    /// "listener" will call when "eventName" triggered.
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public static void StartListening(string eventName, UnityAction<string> listener)
    {
        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<string>();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StartListening(EventName eventName, UnityAction<string> listener)
    {
        StartListening(eventName.n, listener);
    }

    public static void StopListening(string eventName, UnityAction<string> listener)
    {
        if (eventManager == null) return;
        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void StopListening(EventName eventName, UnityAction<string> listener)
    {
        StopListening(eventName.n, listener);
    }

    /// <summary>
    /// Call every functions registered by StartListening()
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="str0">param gived to the function called</param>
    public static void TriggerEvent(string eventName, string str0)
    {
        Debug.Log("Triggered: " + eventName);

        UnityEvent<string> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(str0);
        }
    }

    public static void TriggerEvent(EventName eventName, string str0)
    {
        TriggerEvent(eventName.n, str0);
    }
}