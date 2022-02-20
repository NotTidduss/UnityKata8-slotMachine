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
    } 


    // Perform an action based on the current gameState and set next gameState.
    public void progress() {
        switch (gameState) {
            case Slots_GameState.STARTING:
                slotMachine.Initialize(this);
                gameState = Slots_GameState.SPINNING;
                return;
            case Slots_GameState.SPINNING:
                slotMachine.stopReel1();
                gameState = Slots_GameState.STOPPED_SPIN_1;
                return;
            case Slots_GameState.STOPPED_SPIN_1:
                slotMachine.stopReel2();
                gameState = Slots_GameState.STOPPED_SPIN_2;
                return;
            case Slots_GameState.STOPPED_SPIN_2:
                slotMachine.stopReel3();
                gameState = Slots_GameState.FINISHING;
                return;
            case Slots_GameState.FINISHING:
                slotMachine.Terminate();
                master.ui.Terminate();
                return;
        }
    }
}
