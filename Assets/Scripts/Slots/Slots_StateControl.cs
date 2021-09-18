using UnityEngine;

public class Slots_StateControl : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Slots_UI ui;
    [SerializeField] private Slots_Machine slotMachine;
    
    public Slots_GameState gameState {get; private set;}

    public void initialize() => gameState = Slots_GameState.STARTING;

    // Perform an action based on the current gameState and set next gameState.
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
