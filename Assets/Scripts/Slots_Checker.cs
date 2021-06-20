using UnityEngine;

public class Slots_Checker : MonoBehaviour
{
    [Header("Helpers")]
    [SerializeField] private Slots_Machine slotMachine;
    [SerializeField] private int id;

    /*
        OnTriggerEnter
        
        When symbol changes, update the symbol reference of the slot machine
    */
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Symbol") slotMachine.setSymbolReel(id, other.gameObject.name);
    }
}
