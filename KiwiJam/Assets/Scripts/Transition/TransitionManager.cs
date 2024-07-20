using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine.SceneManagement;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class TransitionManager : Singleton<TransitionManager>
{
    public string startScene;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    private bool isFade;
    private bool canTransition;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnEnable()
    {
        EventHandler.GameStateChangedEvent += OnGameStateChangedEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangedEvent -= OnGameStateChangedEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }
    private void OnGameStateChangedEvent(GameState gameState)
    {
        canTransition = gameState == GameState.Playing;
    }
    
    private void OnStartNewGameEvent(int gameWeek)
    {
        StartCoroutine(TransitionToScene("Menu", startScene));
    }

    public void Transition(string from, string to)
    {
        StartCoroutine(TransitionToScene(from, to));
    }
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);

        if (from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        // Activate the new scene
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));

        if (from == "Menu")
            EventHandler.CallMenuAfterSceneLoadedEvent();
        
        EventHandler.CallAfterSceneLoadEvent();
        yield return Fade(0);
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }

}
