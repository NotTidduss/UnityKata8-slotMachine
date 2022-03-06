using UnityEngine;

public class Slots_ReelChecker : MonoBehaviour
{
    //* links
    public Slots_Reel reel { get; private set; }

    //* private vars
    private int id;


    public void Initialize(Slots_Reel reelRef, int reelIndex) 
    {
        // set link
        reel = reelRef;

        // set private vars
        id = reelIndex;
    }


    // When symbol changes, update the symbol reference of the slot machine
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Symbol") 
            reel.machine.setSymbolReel(id, other.gameObject.name);
    }
}
