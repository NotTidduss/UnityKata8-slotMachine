using UnityEngine;

public class Slots_System : MonoBehaviour
{
    [Header ("Global Game Settings")]
    public float interactionCooldown = 0.5f;
    public float finishingWaittime = 1.5f;


    [Header ("Keybindings")]
    public KeyCode btnInteract = KeyCode.Space;


    [Header ("Slot Machine Preferences")]
    public string messageMatch = "YOU WIN";
    public string messageNothing = "YOU LOSE";
    public float scoreMatch = 1000;
    public float scoreNothing = -50;
    

    [Header("Reel Preferences")]
    public float reelSpinSpeed = 0.5f;
    public float reelTargetAngle = 45;
}
