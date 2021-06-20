using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slots_UI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slots_Machine slotMachine;
    [SerializeField] private GameObject resultsScreen;
    [SerializeField] private Text textResult;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textTotalScore;

    void Start() => resultsScreen.SetActive(false);

    /*
        public void finish
        
        Shows the result screen and sets its texts.
    */
    public void finish() {
        resultsScreen.SetActive(true);
        textResult.text = slotMachine.getResultText();
        textScore.text = "Score: " + slotMachine.getResultScore();
        textTotalScore.text = "Total Score: " + PlayerPrefs.GetInt("kata8_totalScore").ToString();
    }

    public void playAgain() => SceneManager.LoadScene("1_SlotMachine");
}
