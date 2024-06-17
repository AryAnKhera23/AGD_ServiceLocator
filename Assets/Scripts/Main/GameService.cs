using ServiceLocator.Events;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{   
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;


    protected override void Awake()
    {
        eventService = new EventService();
        base.Awake();
        eventService.Awake();
    }
    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        
    }

    private void Update()
    {
        playerService.Update();
    }
}
