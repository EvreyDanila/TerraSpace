using UnityEngine;

public class AllCards : MonoBehaviour
{
    public CardsItemScriptableObj[] cardsCommon;
    public CardsItemScriptableObj[] cardsHistory;
    public int maxChance = 10;
    public bool[] isHistories;
    public Save save;

    private CardsItemScriptableObj[] cards;

    private void Start()
    {
        isHistories = new bool[cardsHistory.Length];

        cards = new CardsItemScriptableObj[cardsCommon.Length + cardsHistory.Length];
        cardsCommon.CopyTo(cards, 0);
        cardsHistory.CopyTo(cards, cardsCommon.Length);

        bool isLoad = save.LoadHistory();

        if (isLoad)
        {
            isHistories = save.isHistories;
        }
    }

    public CardsItemScriptableObj GetRandomCard()
    {
        System.Random random = new();
        int chance = random.Next(0, maxChance);
        bool searchHistories = false;

        Debug.Log($"isHistories - {isHistories.GetType()}");

        foreach (var item in isHistories)
        {
            if(!item)
            {
                searchHistories = true;
            }
        }

        if (chance == 0 && searchHistories)
        {
            int index;
            do
            {
                index = random.Next(0, cardsHistory.Length - 1);
            }
            while (isHistories[index]);
            isHistories[index] = true;
            return cardsHistory[index];
        }
        else
        {
            return cardsCommon[random.Next(0, cardsCommon.Length - 1)];
        }
    }

    public CardsItemScriptableObj GetCardToName(string name)
    {
        foreach (var card in cards)
        {
            if (card.name == name)
            {
                return card;
            }
        }
        return GetRandomCard();
    }
}