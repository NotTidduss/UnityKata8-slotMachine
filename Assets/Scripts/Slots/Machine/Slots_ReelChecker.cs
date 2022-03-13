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
        if (other.gameObject.tag == "Symbol") {
            reel.machine.setSymbolOfReel(id, new Slots_Symbol(mapObjectNameToSymbolType(other.gameObject.name)));
        }
    }


    // get the last char of name, parse to int, convert to symbolType
    private Slots_SymbolType mapObjectNameToSymbolType(string symbolObjectName) => 
        (Slots_SymbolType)int.Parse(symbolObjectName.Substring(symbolObjectName.Length - 1));
}
