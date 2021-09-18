using System.Collections;
using UnityEngine;

public class Slots_Master : MonoBehaviour
{
    [Header("Scene References")]
    public Slots_System sys;
    public Slots_StateControl stateControl;

    void Start() {
        stateControl.initialize();

        StartCoroutine("CheckForInput");
        StartCoroutine("CheckForFinish");
    }

    IEnumerator CheckForInput() {
        while (true) { 
            if (Input.GetKeyUp(sys.btnInteract)) {
                stateControl.progress();
                yield return new WaitForSeconds(sys.btnCooldown);
            }
            yield return null;
        }
    }

    IEnumerator CheckForFinish() {
        while (true) { 
            if (stateControl.gameState == Slots_GameState.FINISHING) {
                yield return new WaitForSeconds(sys.finishingWaittime);
                stateControl.progress();
                Destroy(this);
            }
            yield return null;
        }
    }
}
