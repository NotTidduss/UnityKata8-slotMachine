using UnityEngine;
using UnityEngine.UI;

public class Slots_UI : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Slots_System sys;
    [SerializeField] private GameObject resultsScreen;
    [SerializeField] private Text textResult;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textTotalScore;


    //* links
    public Slots_Master master { get; private set; }

    //* private vars
    private int resultScore;


    public void Initialize(Slots_Master masterRef) 
    {
        // set master link
        master = masterRef;

        // prepare UI
        resultsScreen.SetActive(false);
    }

    public void Terminate() 
    {
        // set UI to final state
        resultsScreen.SetActive(true);

        // update score & score related UI elements
        switch ((Slots_Outcome)PlayerPrefs.GetInt("slots_outcome")) 
        {
            case Slots_Outcome.NOTHING:
                resultScore = -50;
                textResult.text = sys.messageNothing;
                textScore.text = "Score: " + sys.scoreNothing;
                break;
            case Slots_Outcome.MATCH:
                resultScore = 1000;
                textResult.text = sys.messageMatch;
                textScore.text = "Score: " + sys.scoreMatch;
                break;
        }
        PlayerPrefs.SetInt("slots_totalScore", PlayerPrefs.GetInt("slots_totalScore") + resultScore);
        textTotalScore.text = "Total Score: " + PlayerPrefs.GetInt("slots_totalScore").ToString();
    }

#region Button Functions
    public void playAgain() => Slots_SceneMaster.loadGameScene();
#endregion
}
