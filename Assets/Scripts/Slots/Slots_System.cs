using UnityEngine;

public class Slots_System : MonoBehaviour
{
    [Header ("Keybindings")]
    public KeyCode btnInteract = KeyCode.Space;

    [Header ("Global Game Settings")]
    public float btnCooldown = 0.5f;
    public float finishingWaittime = 3;
}

public enum Slots_GameState {
    STARTING,
    SPINNING,
    STOPPED_SPIN_1,
    STOPPED_SPIN_2,
    FINISHING
}
