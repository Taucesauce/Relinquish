﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Accessible UnityEvent classes to use in Dictionaries.
[System.Serializable]
public class UnityIntEvent : UnityEvent<int> { }

[System.Serializable]
public class UnityBoolEvent : UnityEvent<bool> { }

[System.Serializable]
public class UnityIntIntEvent : UnityEvent<int, int> { }

public class EventManager : MonoBehaviour {

    private Dictionary<string, UnityEvent> eventDictionary;
    private Dictionary<string, UnityIntEvent> intEventDictionary;
    private Dictionary<string, UnityIntIntEvent> intIntEventDictionary;
    private Dictionary<string, UnityBoolEvent> boolEventDictionary;

    //Singleton Pattern
    //Private instance of manager
    private static EventManager eventManager;

    //Publicly accessible instance of manager
    //Gets the private instance or if the private instance doesn't exist yet, makes one.
    public static EventManager instance {
        get {
            if (!eventManager) {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager) {
                    Debug.LogError("No active EventManager script found.");
                }
                else {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    //Sets the eventDictionary on creation of private eventManager instance.
    void Init() {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<string, UnityEvent>();
            intEventDictionary = new Dictionary<string, UnityIntEvent>();
        }
    }

    //Int based event setup
    public static void StartListeningTypeInt(string eventName, UnityAction<int> listener) {
        UnityIntEvent thisEvent = null;
        if (instance.intEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityIntEvent();
            thisEvent.AddListener(listener);
            instance.intEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListeningTypeInt(string eventName, UnityAction<int> listener) {
        if (eventManager == null) return;

        UnityIntEvent thisEvent = null;
        if (instance.intEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerIntEvent(string eventName, int input) {
        UnityIntEvent thisEvent = null;
        if (instance.intEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(input);
        }
    }
    //--End Int Event methods--

    //Int Int based event setup
    public static void StartListeningTypeIntInt(string eventName, UnityAction<int,int> listener) {
        UnityIntIntEvent thisEvent = null;
        if (instance.intIntEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityIntIntEvent();
            thisEvent.AddListener(listener);
            instance.intIntEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListeningTypeIntInt(string eventName, UnityAction<int,int> listener) {
        if (eventManager == null) return;

        UnityIntIntEvent thisEvent = null;
        if (instance.intIntEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerIntIntEvent(string eventName, int input1, int input2) {
        UnityIntIntEvent thisEvent = null;
        if (instance.intIntEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(input1, input2);
        }
    }
    //--End Int Int Event methods--

    //Bool based event setup (Ended up not using these for the time being)
    public static void StartListeningTypeBool(string eventName, UnityAction<bool> listener) {
        UnityBoolEvent thisEvent = null;
        if (instance.boolEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityBoolEvent();
            thisEvent.AddListener(listener);
            instance.boolEventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListeningTypeBool(string eventName, UnityAction<bool> listener) {
        if (eventManager == null) { return; }
        UnityBoolEvent thisEvent = null;
        if (instance.boolEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerBoolEvent(string eventName, bool input) {
        UnityBoolEvent thisEvent = null;
        if (instance.boolEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(input);
        }
    }
    //--End Bool Event methods--

    //Empty parameter event setup
    public static void StartListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener) {
        if (eventManager == null) return;

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName) {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke();
        }
    }
    //--End empty parameter event methods--
}