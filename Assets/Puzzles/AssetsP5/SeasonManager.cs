using UnityEngine;
using System.Collections;

public enum SeasonType
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager Instance;

    public SeasonType currentSeason = SeasonType.Spring;

    public Transform springSpawn;
    public Transform summerSpawn;
    public Transform autumnSpawn;
    public Transform winterSpawn;

    public float seasonDuration = 300f; // 5 minutes

    PlayerInventory playerInventory;
    GameObject player;

    Coroutine seasonTimer;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();

        StartSeason(SeasonType.Spring);
    }

    void StartSeason(SeasonType season)
    {
        currentSeason = season;

        TeleportPlayerToSeason(season);

        if (seasonTimer != null)
            StopCoroutine(seasonTimer);

        seasonTimer = StartCoroutine(SeasonTimer());
    }

    IEnumerator SeasonTimer()
    {
        yield return new WaitForSeconds(seasonDuration);

        if (!playerInventory.HasDiamond)
        {
            GoToNextSeason();
        }
    }

    void GoToNextSeason()
    {
        if (currentSeason == SeasonType.Spring)
            StartSeason(SeasonType.Summer);
        else if (currentSeason == SeasonType.Summer)
            StartSeason(SeasonType.Autumn);
        else if (currentSeason == SeasonType.Autumn)
            StartSeason(SeasonType.Winter);
    }

    void TeleportPlayerToSeason(SeasonType season)
    {
        if (season == SeasonType.Spring)
            player.transform.position = springSpawn.position;
        else if (season == SeasonType.Summer)
            player.transform.position = summerSpawn.position;
        else if (season == SeasonType.Autumn)
            player.transform.position = autumnSpawn.position;
        else if (season == SeasonType.Winter)
            player.transform.position = winterSpawn.position;
    }

    public void TryFinishGame()
    {
        if (playerInventory.HasDiamond)
        {
            Debug.Log("GAME FINISHED");
            Time.timeScale = 0f; // موقتاً پایان بازی
        }
    }
}
