using UnityEngine;

public enum CardType
{
    Common,
    End,
}
[CreateAssetMenu(fileName = "Cards", menuName = "Cards/New card")]
public class CardsItemScriptableObj : ScriptableObject
{
    [Header("Настройки карточки")]
    public CardType cardType;
    public string cardName;
    public Sprite cardSprite;
    [Header("Ответы и текст карточки")]
    public string rightResp;
    public string leftResp;
    [TextArea(25, 50)]
    public string cardDescription;
    [Header("Влияение ответа")]
    public StatsRespFloat terraformDif;
    public StatsRespFloat energyDif;
    public StatsRespFloat resourceDif;
    public StatsRespFloat mechanismDif;
    public StatsRespInt peopleDif;

    public CardsItemScriptableObj cardCommonRight, cardCommonLeft;
}