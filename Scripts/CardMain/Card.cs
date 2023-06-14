using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Card : MonoBehaviour
{
    public CardsItemScriptableObj card;
    public Player player;
    public AllCards allCards;
    public Sprite spriteBackCard;

    public TextMeshProUGUI textHistory;
    public TextMeshProUGUI textQuestionRight;
    public TextMeshProUGUI textQuestionLeft;
    public Animator anim;
    public Image image;
    public AudioSource audioSource;

    public Save save;

    private IEnumerator enumerator;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Card").GetComponent<Animator>();
        card = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>().card;

        if (Load())
        {
            textHistory.text = "";
            textQuestionRight.text = "";
            textQuestionLeft.text = "";
            image.sprite = null;
        }

        UpdateCard();
        SetImgCard();
        StartTapingText();

        EventsManager.UseCard += StartAnimAddCard;
    }

    private bool Load()
    {
        var isLoad = save.LoadGame();
        if (isLoad)
        {
            card = allCards.GetCardToName(save.cardName);
        }
        return isLoad;
    }

    public void StartAnimAddCard(string _)
    {
        anim = GameObject.FindGameObjectWithTag("Card").GetComponent<Animator>();
        anim.SetTrigger("CardAdd");
    }

    public void SetImgCard()
    {
        image.sprite = card.cardSprite;
    }

    public void UpdateCard()
    {
        textQuestionRight.text = card.rightResp;
        textQuestionLeft.text = card.leftResp;        
    }

    public void StartTapingText()
    {
        enumerator = TapingText(card.cardDescription);
        StartCoroutine(enumerator);
    }

    public void SetImgBackCard()
    {
        image.sprite = spriteBackCard;
    }

    public void StopTapingText()
    {
        if (enumerator != null)
        {
            card = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>().card;
            StopCoroutine(enumerator);
            textHistory.text = card.cardDescription;
        }
    }

    public void SkipTapingText()
    {
        StopTapingText();
        textHistory.text = card.cardDescription;
    }

    public void ResetCard()
    {
        textHistory.text = "";
        textQuestionRight.text = "";
        textQuestionLeft.text = "";
        card = null;
    }

    private IEnumerator TapingText(string text)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        foreach (var chr in text)
        {
            textHistory.text += chr;
            yield return wait;
        }
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
