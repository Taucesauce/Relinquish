using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperManager : MonoBehaviour {
    List<Helper> currentHelpers;
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
    }

    // Use this for initialization
    void Start () {
        Init();
        SpawnHelper();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnHelper() {
        GameObject newHelper = (GameObject)Instantiate(Resources.Load("Protector"), playerRef.transform.position, Quaternion.identity);
        Protector newProtector = newHelper.GetComponent<Protector>();
        newProtector.PlayerRef = playerRef;
        currentHelpers.Add(newProtector);

        GameObject newHelper2 = (GameObject)Instantiate(Resources.Load("Attacker"), playerRef.transform.position, Quaternion.identity);
        Attacker newAttacker = newHelper2.GetComponent<Attacker>();
        newAttacker.PlayerRef = playerRef;
        currentHelpers.Add(newAttacker);

    }
}
