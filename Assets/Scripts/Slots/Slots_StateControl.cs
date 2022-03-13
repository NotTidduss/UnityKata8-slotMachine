using UnityEngine;

public class Slots_StateControl : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Slots_Machine slotMachine;
    

    //* links
    public Slots_Master master { get; private set; }

    //* private vars
    public Slots_GameState gameState {get; private set;}


    public void Initialize(Slots_Master masterRef) 
    {
        // set link to master
        master = masterRef; 

        // set starting game state
        gameState = Slots_GameState.STARTING;

        // initialize machine
        slotMachine.Initialize(this);
    } 


    // Perform an action based on the current gameState and set next gameState.
    public void progress() {
        switch (gameState) {
            case Slots_GameState.STARTING:
                slotMachine.startSpinning();
                gameState = Slots_GameState.SPINNING;
                return;
            case Slots_GameState.SPINNING:
                progressReels();
                gameState = Slots_GameState.STOPPED_SPIN_1;
                return;
            case Slots_GameState.STOPPED_SPIN_1:
                progressReels();
                gameState = Slots_GameState.STOPPED_SPIN_2;
                return;
            case Slots_GameState.STOPPED_SPIN_2:
                progressReels();
                gameState = Slots_GameState.FINISHING;
                return;
            case Slots_GameState.FINISHING:
                slotMachine.evaluateResult();
                master.ui.Terminate();
                return;
        }
    }

    private void progressReels() {
        slotMachine.stopCurrentReel();
        slotMachine.incrementReelIndex();
    }
}
