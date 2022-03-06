using UnityEngine;

public class Slots_Reel : MonoBehaviour
{    
    [Header ("Prefab References")]
    [SerializeField] private Slots_ReelCylinder cylinder;
    [SerializeField] private Slots_ReelChecker checker;


    //* link
    public Slots_Machine machine { get; private set; }

    //* private vars
    private float spinSpeed;
    private float targetAngle;


    public void Initialize(Slots_Machine machineRef, int reelIndex) 
    {
        // set link
        machine = machineRef;

        // prepare private variables
        spinSpeed = machine.stateControl.master.sys.reelSpinSpeed;
        targetAngle = machine.stateControl.master.sys.reelTargetAngle;

        // initialize checker
        cylinder.Initialize(spinSpeed, targetAngle);
        checker.Initialize(this, reelIndex);
    }


    public void startSpin() => cylinder.startSpin();
    public void stopSpin() => cylinder.stopSpin();
}
