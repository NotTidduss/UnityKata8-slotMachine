using UnityEngine;

public class Slots_PlayerPrefsMaster
{
    // Set PlayerPrefs to desired starting values.
    public static void initializePlayerPrefs() 
    {
        // INT slots_totalScore - value to keep track of the score
        if (PlayerPrefs.GetInt("slots_totalScore") == 0)
            PlayerPrefs.SetInt("slots_totalScore", 0);

        // INT slots_outcome - maps enum SLOTS_OUTCOME, used for fetching values in ui
        PlayerPrefs.SetInt("slots_outcome", 0);
    }

    // Reset all PlayerPrefs and re-initialize them
    public static void resetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        initializePlayerPrefs();
    }
}
