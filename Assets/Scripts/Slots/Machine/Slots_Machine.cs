using System.Collections.Generic;
using UnityEngine;

public class Slots_Machine : MonoBehaviour
{
    [Header("Reel Prefab Reference")]
    [SerializeField] private GameObject reelPrefab;


    //* links
    public Slots_StateControl stateControl { get; private set; }

    //* private vars
    private int reelCount;                  // given by system
    private int currentReelIndex;           // points to reel in reel list that will be stopped next
    private float reelDistance;             // given by system
    private List<GameObject> reelObjects;   // holds all reels that are dynamically added to scene based on reelCount
    private string currentSymbolReel1;  
    private string currentSymbolReel2;
    private string currentSymbolReel3;


    public void Initialize(Slots_StateControl stateControlRef) {
        // set link
        stateControl = stateControlRef;

        // prepare private vars
        reelCount = stateControl.master.sys.reelCount;
        reelDistance = stateControl.master.sys.reelDistance;
        currentReelIndex = 0;

        // fill reelObjects list with clones of the prefab
        reelObjects = new List<GameObject>();
        for (int i = 0; i < reelCount; i++) {
            GameObject reelObject = Instantiate(reelPrefab, new Vector3(i * reelDistance, 0, 0), reelPrefab.transform.rotation, this.gameObject.transform);
            reelObjects.Add(reelObject);
            reelObject.GetComponent<Slots_Reel>().Initialize(this, i);
        }
    }

    public void Terminate() {
        Debug.Log(currentSymbolReel1 + " " + currentSymbolReel2 + " " + currentSymbolReel3);

        // determine outcome
        if (currentSymbolReel1 == currentSymbolReel2 && currentSymbolReel1 == currentSymbolReel3) 
            win();
        else 
            lose();
    }


    /*
        When checkers determine a new symbol, update them here.

        @param id: identifies which checker wants to update.
        @param symbol: the current symbol on the reel.
    */
    public void setSymbolReel(int id, string symbol) {
        switch (id) {
            case 1: currentSymbolReel1 = symbol; return;
            case 2: currentSymbolReel2 = symbol; return;
            case 3: currentSymbolReel3 = symbol; return;            
        }
    }

    public void startSpinning() => reelObjects.ForEach(reelObject => reelObject.GetComponent<Slots_Reel>().startSpin());
    public void stopCurrentReel() => reelObjects[currentReelIndex].GetComponent<Slots_Reel>().stopSpin();
    public void incrementReelIndex() => currentReelIndex += 1;

    private void win() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.MATCH);
    private void lose() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.NOTHING);
}
