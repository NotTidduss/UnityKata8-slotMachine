using System.Collections;
using UnityEngine;

public class Slots_Reel : MonoBehaviour
{    
    //* link
    public Slots_Machine machine { get; private set; }

    //* private vars
    private float spinSpeed;
    private float targetAngle;


    public void Initialize(Slots_Machine machineRef) 
    {
        // set link
        machine = machineRef;

        // prepare private variables
        spinSpeed = machine.stateControl.master.sys.reelSpinSpeed;
        targetAngle = machine.stateControl.master.sys.reelTargetAngle;
    }


    IEnumerator Spin() 
    {
        for(;;)
        {
            transform.Rotate(0,spinSpeed,0);

            yield return null;
        }
    }


    public void startSpin() => StartCoroutine(Spin());
    public void stopSpin() 
    {
        snap(transform.eulerAngles.x, targetAngle);
        Destroy(this);
    }
    

    /*
        Adjust the Reel's rotation so that its x angle fits a targetAngle.
        Calculates the difference between the angles and uses that to fit the current angle.
        In the end, current angle should be a multiple of targetAngle.

        @param currentAngleX: current x rotation in eulerAngles.
        @param targetAngle: the angle to adjust the rotation towards.
    */
    private void snap(float currentAngleX, float targetAngle) 
    {
        float reducedAngle = getReducedAngle(currentAngleX, targetAngle);
        float angleDifference = targetAngle - reducedAngle;

        float newAngleX = determineRoundtoCeiling(reducedAngle, targetAngle) ? transform.eulerAngles.x + angleDifference : transform.eulerAngles.x - reducedAngle;

        transform.eulerAngles = new Vector3(newAngleX, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    /*
        Compares two angles and determines if the first angle should be rounded to ceiling or not.

        @param angle: any given angle, smaller than targetAngle.
        @param targetAngle: the angle to compare the angle with.
        @return: true if angle is bigger than half of the targetAngle, false if not.
    */
    private bool determineRoundtoCeiling(float angle, float targetAngle) => angle > targetAngle / 2 ? true : false;

    /*
        Reduces given angle A until it is smaller than given angle B.

        @param a1: given angle A.
        @param a2: given angle B.
        @return: angle A as soon as it is smaller than angle B.
    */
    private float getReducedAngle(float a1, float a2) => a1 < a2 ? a1 : getReducedAngle(a1 - a2, a2);
}
