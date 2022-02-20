using UnityEngine;

public class Slots_Machine : MonoBehaviour
{
    [Header("Reels")]
    [SerializeField] private Slots_Reel reel1;
    [SerializeField] private Slots_Reel reel2;
    [SerializeField] private Slots_Reel reel3;


    //* links
    public Slots_StateControl stateControl { get; private set; }

    //* private vars
    private string currentSymbolReel1;
    private string currentSymbolReel2;
    private string currentSymbolReel3;


    public void Initialize(Slots_StateControl stateControlRef) {
        // set link
        stateControl = stateControlRef;

        // initialize reels
        reel1.Initialize(this);
        reel1.toggleSpin();

        reel2.Initialize(this);
        reel2.toggleSpin();

        reel3.Initialize(this);
        reel3.toggleSpin();
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

    public void stopReel1() => reel1.toggleSpin();
    public void stopReel2() => reel2.toggleSpin();
    public void stopReel3() => reel3.toggleSpin();


    private void win() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.MATCH);
    private void lose() => PlayerPrefs.SetInt("slots_outcome", (int)Slots_Outcome.NOTHING);
}
