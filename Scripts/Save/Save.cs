using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    private Player player;
    private Card card;

    private const string nameFileSettings = "/settings.json";
    private const string nameFileGame = "/main.json";
    private const string nameFileHistories = "/histories.json";

    public float terraform { get; private set; }
    public float mechanism { get; private set; }
    public float resource { get; private set; }
    public float energy { get; private set; }
    public int people { get; private set; }
    public string cardName { get; private set; }

    public int quality { get; private set; }
    public float volume { get; private set; }

    public bool[] isHistories { get; private set; }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        card = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>();
    }

    public void SaveSettings()
    {
        SaveManager.SaveDataSettings data = new();

        AudioSource audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        Transform graphicTogles = GameObject.FindGameObjectWithTag("GraphicTogles").transform;

        for (int i = 0; i < graphicTogles.childCount; i++)
        {
            if (graphicTogles.GetChild(i).GetComponent<Toggle>().isOn)
            {
                data.Quality = i * 2;
            }
        }

        data.Volume = audioSource.volume;

        SaveManager.Save<SaveManager.SaveDataSettings>(data, nameFileSettings);
    }

    public void LoadSettings()
    {
        SaveManager.SaveDataSettings data = SaveManager.Load<SaveManager.SaveDataSettings>(nameFileSettings);
        if (data is not null)
        {
            quality = data.Quality;
            volume = data.Volume;
        }
        else
        {
            quality = 4;
            volume = 0.5f;
        }
    }

    public bool LoadHistory()
    {
        SaveManager.SaveDataHistory data = SaveManager.Load<SaveManager.SaveDataHistory>(nameFileHistories);

        if (data is not null)
        {
            isHistories = data.isHistories;
            return true;
        }
        return false;
    }

    public void SaveHistory()
    {
        SaveManager.SaveDataHistory data = new();

        data.isHistories = card.allCards.isHistories;

        SaveManager.Save<SaveManager.SaveDataHistory>(data, nameFileHistories);
    }

    public void SaveGame()
    {
        SaveManager.SaveDataGame data = new();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        data.Terraform = player.terraform;
        data.Mechanism = player.mechanism;
        data.Resource = player.resource;
        data.Energy = player.energy;
        data.People = player.people;
        card = GameObject.FindGameObjectWithTag("Card").GetComponent<Card>();
        data.CardName = card.card.cardName;

        SaveManager.Save<SaveManager.SaveDataGame>(data, nameFileGame);
    }

    public bool LoadGame()
    {
        SaveManager.SaveDataGame data = SaveManager.Load<SaveManager.SaveDataGame>(nameFileGame);
        if (data is not null)
        {
            terraform = data.Terraform;
            mechanism = data.Mechanism;
            resource = data.Resource;
            energy = data.Energy;
            people = data.People;
            cardName = data.CardName;
            return true;
        }
        else
        {
            terraform = 0f;
            mechanism = 100f;
            resource = 100f;
            energy = 100f;
            people = 50;
            cardName = "";
            return false;
        }
    }

    public void SavesDestroy()
    {
        SaveManager.SaveDestroyManager(nameFileGame);
        SaveManager.SaveDestroyManager(nameFileSettings);
        SaveManager.SaveDestroyManager(nameFileHistories);
    }

    public bool IsSaveGame()
    {
        return SaveManager.IsSaveManager(nameFileGame);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        SaveHistory();
    }

    private void OnDisable()
    {
        SaveGame();
        SaveHistory();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveGame();
        SaveHistory();
    }
}