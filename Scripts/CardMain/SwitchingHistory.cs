using UnityEngine;

public class SwitchingHistory : MonoBehaviour
{
    public Card cardMain;
    public AllCards cards;

    private void Start()
    {
        cardMain = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>();
        EventsManager.UseCard += Switching;
    }

    private void Switching(string choise)
    {
        cardMain = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>();

        if (cardMain.card != null && cardMain != null)
        {
            if (cardMain.card.cardType == CardType.End)
            {
                EventsManager.OnGameOverLose();
                cardMain.ResetCard();
                return;
            }
        }

        cardMain.StopTapingText();
        var card = cardMain.card;
        cardMain.ResetCard();
        

        if (choise == "Right" && card.cardCommonRight != null)
        {
            cardMain.card = card.cardCommonRight;
            cardMain.player.StatsDifferenceRight(card);
        }
        else if (choise == "Left" && card.cardCommonLeft != null)
        {
            cardMain.card = card.cardCommonLeft;
            cardMain.player.StatsDifferenceLeft(card);
        }
        else if (choise == "Right" && card.cardCommonRight == null)
        {
            cardMain.player.StatsDifferenceRight(card);
        }
        else if (choise == "Left" && card.cardCommonLeft == null)
        {
            cardMain.player.StatsDifferenceLeft(card);
        }

        if (card.cardCommonRight == null && card.cardCommonLeft == null)
        {
            cardMain.card = cards.GetRandomCard();
        }

        cardMain.UpdateCard();
        EventsManager.OnSwitchingDone();
    }
}
