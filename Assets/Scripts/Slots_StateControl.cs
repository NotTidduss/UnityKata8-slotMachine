using UnityEngine;

public class Slots_StateControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slots_UI ui;
    [SerializeField] private Slots_Machine slotMachine;
    
    private Slots_GameState gameState;

    void Start() => gameState = Slots_GameState.STARTING;

    public Slots_GameState getGameState() => gameState;

    /*
        public void progress
        
        Perform an action based on the current gameState.
        Also, set next gameState.
    */
    public void progress() {
        switch (gameState) {
            case Slots_GameState.STARTING:
                slotMachine.startSpinning();
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
                slotMachine.finish();
                ui.finish();
                return;
        }
    }
}
