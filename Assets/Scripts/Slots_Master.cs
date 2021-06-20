using System.Collections;
using UnityEngine;

public class Slots_Master : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private KeyCode btnInteract = KeyCode.Space;
    [SerializeField] private float btnCooldown = 0.5f;
    [SerializeField] private float finishingWaittime = 3;

    [Header("References")]
    public Slots_StateControl stateControl;

    void Start() {
        StartCoroutine("CheckForInput");
        StartCoroutine("CheckForFinish");
    }

    IEnumerator CheckForInput() {
        while (true) { 
            if (Input.GetKeyUp(btnInteract)) {
                stateControl.progress();
                yield return new WaitForSeconds(btnCooldown);
            }
            yield return null;
        }
    }

    IEnumerator CheckForFinish() {
        while (true) { 
            if (stateControl.getGameState() == Slots_GameState.FINISHING) {
                yield return new WaitForSeconds(finishingWaittime);
                stateControl.progress();
                Destroy(this);
            }
            yield return null;
        }
    }
}
