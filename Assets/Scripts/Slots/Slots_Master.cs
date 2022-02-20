using System.Collections;
using UnityEngine;

public class Slots_Master : MonoBehaviour
{
    [Header("Scene Elements")]
    public Slots_System sys;
    public Slots_UI ui;
    public Slots_StateControl stateControl;


    void Start() 
    {
        // prepare PlayerPrefs
        Slots_PlayerPrefsMaster.initializePlayerPrefs();

        // prepare Scene
        ui.Initialize(this);
        stateControl.Initialize(this);

        // start coroutines
        StartCoroutine(CheckForInput());
        StartCoroutine(CheckForGameOver());
    }


    // Input management
    IEnumerator CheckForInput() {
        for(;;) 
        { 
            if (Input.GetKeyDown(sys.btnInteract)) 
            {
                stateControl.progress();
                yield return new WaitForSeconds(sys.interactionCooldown);
            }
            yield return null;
        }
    }

    // wait until all reels stopped and prepare for finishing the scene
    IEnumerator CheckForGameOver() {
        for(;;) 
        { 
            if (stateControl.gameState == Slots_GameState.FINISHING) 
            {
                yield return new WaitForSeconds(sys.finishingWaittime);
                stateControl.progress();
                Destroy(this);
            }
            yield return null;
        }
    }
}
