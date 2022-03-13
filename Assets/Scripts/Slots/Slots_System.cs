using UnityEngine;

public class Slots_System : MonoBehaviour
{
    [Header ("Global Game Settings")]
    public float interactionCooldown = 0.5f;
    public float finishingWaittime = 1.5f;


    [Header ("Keybindings")]
    public KeyCode btnInteract = KeyCode.Space;


    [Header ("Slot Machine Preferences")]
    public int reelCount = 3;
    public float reelDistance = 3;
    public string messageWin = "YOU WIN";
    public string messageLose = "YOU LOSE";
    public int scoreWinRow = 1000;
    public int scoreWinDiagonal = 1500;
    public int scoreWinCherry = 100;
    public int scoreLose = -50;
    

    [Header("Reel Preferences")]
    public float reelSpinSpeed = 0.5f;
    public float reelTargetAngle = 45;
}
