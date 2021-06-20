using UnityEngine;

public class Slots_Machine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slots_Reel reel1;
    [SerializeField] private Slots_Reel reel2;
    [SerializeField] private Slots_Reel reel3;

    private string currentSymbolReel1;
    private string currentSymbolReel2;
    private string currentSymbolReel3;
    private string resultText;
    private int resultScore;

    /*
        public void setSymbolReel

        When checkers determine a new symbol, update them here.
        @param id: identifies which checker wants to update.
        @param symbol: the current symbol on the reel.
    */
    public void setSymbolReel(int id, string symbol) {
        switch (id) {
            case 1:
                currentSymbolReel1 = symbol;
                return;
            case 2:
                currentSymbolReel2 = symbol;
                return;
            case 3:
                currentSymbolReel3 = symbol;
                return;            
        }
    }

    public void startSpinning() {
        reel1.toggleSpin();
        reel2.toggleSpin();
        reel3.toggleSpin();
    }

    public void stopReel1() => reel1.toggleSpin();
    public void stopReel2() => reel2.toggleSpin();
    public void stopReel3() => reel3.toggleSpin();

    /*
        public void finish

        Called by StateControl, determines if player won or lost and sets texts accordingly.
        Also Update the total score based on result.
    */
    public void finish() {
        Debug.Log(currentSymbolReel1 + " " + currentSymbolReel2 + " " + currentSymbolReel3);

        if (currentSymbolReel1 == currentSymbolReel2 && currentSymbolReel1 == currentSymbolReel3) win();
        else lose();
        PlayerPrefs.SetInt("kata8_totalScore", PlayerPrefs.GetInt("kata8_totalScore") + resultScore);
    }

    public string getResultText() => resultText;
    public void setResultText(string s) => resultText = s;
    public int getResultScore() => resultScore;
    public void setResultScore(int i) => resultScore = i;

    private void win() {
        setResultText("YOU WIN");
        setResultScore(1000);
    }

    private void lose() {
        setResultText("YOU LOSE");
        setResultScore(-50);
    }
}
