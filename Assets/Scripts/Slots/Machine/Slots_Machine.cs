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
    private Slots_Symbol currentSymbolOfReel0, currentSymbolOfReel1, currentSymbolOfReel2;  
    private Slots_Symbol currentSymbolAbove0, currentSymbolAbove1, currentSymbolAbove2;
    private Slots_Symbol currentSymbolBelow0, currentSymbolBelow1, currentSymbolBelow2;


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

    // go over the current symbols and see if there is a win condition met. If not, lose.
    public void evaluateResult()
    {
        /*
        Debug.Log("0:0: " + currentSymbolAbove0.symbolType);
        Debug.Log("0:1: " + currentSymbolOfReel0.symbolType);
        Debug.Log("0:2: " + currentSymbolBelow0.symbolType);
        Debug.Log("1:0: " + currentSymbolAbove1.symbolType);
        Debug.Log("1:1: " + currentSymbolOfReel1.symbolType);
        Debug.Log("1:2: " + currentSymbolBelow1.symbolType);
        Debug.Log("2:0: " + currentSymbolAbove2.symbolType);
        Debug.Log("2:1: " + currentSymbolOfReel2.symbolType);
        Debug.Log("2:2: " + currentSymbolBelow2.symbolType);
        */

        if (isSameSymbolsInRow())
            winBySameSymbolsInRow();
        else if (isSameSymbolsInDiagonal())
            winBySameSymbolsInDiagonal();
        else if (isAnySymbolCherry())
            winByCherry();
        else
            lose();
    }

    /*
        When checkers determine a new symbol, update them here.

        @param id: identifies which checker wants to update.
        @param symbol: the current symbol on the reel.
    */
    public void setSymbolOfReel(int id, Slots_Symbol symbol) {
        switch (id) {
            case 0: setSymbolsBySymbol(out currentSymbolOfReel0, out currentSymbolAbove0, out currentSymbolBelow0, symbol); return;
            case 1: setSymbolsBySymbol(out currentSymbolOfReel1, out currentSymbolAbove1, out currentSymbolBelow1, symbol); return;
            case 2: setSymbolsBySymbol(out currentSymbolOfReel2, out currentSymbolAbove2, out currentSymbolBelow2, symbol); return;            
        }
    }

    public void startSpinning() => reelObjects.ForEach(reelObject => reelObject.GetComponent<Slots_Reel>().startSpin());
    public void stopCurrentReel() => reelObjects[currentReelIndex].GetComponent<Slots_Reel>().stopSpin();
    public void incrementReelIndex() => currentReelIndex += 1;


    private void winBySameSymbolsInRow() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.ROW_WIN);
    private void winBySameSymbolsInDiagonal() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.DIAGONAL_WIN);
    private void winByCherry() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.CHERRY_WIN);
    private void lose() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.NOTHING);

    // set current, above and below symbol variables based on given
    private void setSymbolsBySymbol(out Slots_Symbol centralSymbol, out Slots_Symbol aboveSymbol, out Slots_Symbol belowSymbol, Slots_Symbol symbol)
    {
        int symbolTypeIndex = (int)symbol.symbolType;

        // set current central symbol
        centralSymbol = symbol;

        //! hardcoded limit
        // set current above symbol
        if (symbolTypeIndex - 1 == -1)
            aboveSymbol = new Slots_Symbol((Slots_SymbolType)7);
        else 
            aboveSymbol = new Slots_Symbol((Slots_SymbolType)symbolTypeIndex - 1);

        //! hardcoded limit
        // set current below symbol
        if (symbolTypeIndex + 1 == 8)
            belowSymbol = new Slots_Symbol((Slots_SymbolType)0);
        else
            belowSymbol = new Slots_Symbol((Slots_SymbolType)symbolTypeIndex + 1);
    }

    private bool isSameSymbolsInRow() => 
        currentSymbolOfReel0.symbolType == currentSymbolOfReel1.symbolType 
            && currentSymbolOfReel0.symbolType == currentSymbolOfReel2.symbolType;
    private bool isSameSymbolsInDiagonal() => 
        (currentSymbolAbove0.symbolType == currentSymbolOfReel1.symbolType 
            && currentSymbolOfReel1.symbolType == currentSymbolBelow2.symbolType) 
        || (currentSymbolBelow0.symbolType == currentSymbolOfReel1.symbolType 
            && currentSymbolOfReel1.symbolType == currentSymbolAbove2.symbolType);
    private bool isAnySymbolCherry() => 
        currentSymbolOfReel0.symbolType == Slots_SymbolType.CHERRY 
        || currentSymbolOfReel1.symbolType == Slots_SymbolType.CHERRY 
        || currentSymbolOfReel2.symbolType == Slots_SymbolType.CHERRY;
}
