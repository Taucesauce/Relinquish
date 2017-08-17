using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HelperType {
    Protector,
    Attacker,
    Shooter
}

public class HelperManager : MonoBehaviour {
    static List<Helper> currentHelpers;
    public static int helperCount { get { return currentHelpers.Count; } }
    int helperIterator = 0;
    [SerializeField]
    Player playerRef;

    //Singleton Pattern
    //Private instance of manager
    private static HelperManager helperManager;

    //Publicly accessible instance of manager
    //Gets the private instance or if the private instance doesn't exist yet, makes one.
    public static HelperManager instance {
        get {
            if (!helperManager) {
                helperManager = FindObjectOfType(typeof(HelperManager)) as HelperManager;

                if (!helperManager) {
                    Debug.LogError("No active EventManager script found.");
                }
                else {
                    helperManager.Init();
                }
            }

            return helperManager;
        }
    }

    void Init() {
        currentHelpers = new List<Helper>();
        EventManager.StartListeningTypeInt("Helper Hit", helperOnHit);
        EventManager.StartListening("Pickup Hit", PickupHit);
    }

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void PickupHit() {
        SpawnHelper((HelperType)Random.Range(0, 2));
    }
    //Factory Pattern Method
    void SpawnHelper(HelperType type) {
        string typeName = type.ToString();

        GameObject newHelper = (GameObject)Instantiate(Resources.Load(typeName), playerRef.transform.position, Quaternion.identity);
        switch (typeName) {
            case "Attacker":
                Attacker newAttacker = newHelper.GetComponent<Attacker>();
                newAttacker.ID = helperIterator;
                newAttacker.PlayerRef = playerRef;
                currentHelpers.Add(newAttacker);
                break;
            case "Protector":
                Protector newProtector = newHelper.GetComponent<Protector>();
                newProtector.ID = helperIterator;
                newProtector.PlayerRef = playerRef;
                currentHelpers.Add(newProtector);
                break;
            case "Shooter":
                Shooter newShooter = newHelper.GetComponent<Shooter>();
                newShooter.ID = helperIterator;
                newShooter.PlayerRef = playerRef;
                currentHelpers.Add(newShooter);
                break;
        }

        helperIterator++;
    }

    void helperOnHit(int helperID) {
        currentHelpers.Find(x => x.ID == helperID).HitEvent();
        EventManager.TriggerEvent("Helper Despawn");
        currentHelpers.Remove(currentHelpers.Find(x => x.ID == helperID));
    }
}
