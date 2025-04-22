using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject playerObject;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public CanvasGroup timeOutBackgroundImageCanvasGroup;
    public AudioSource timeOutAudio;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    float gameTime;
    public TextMeshProUGUI timerText;
    bool m_HasTimeRunOut;
    bool m_HasAudioPlayed;

    void Start()
    {
        gameTime = 180f;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == playerObject)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    IEnumerator StartGameTimer()
    {
        float timeIndex = 1f;

        yield return new WaitForSeconds(timeIndex);

        gameTime -= Time.deltaTime;
    }

    public void GameTime(float currentTime)
    {
        timerText.text = "Time Left: " + currentTime.ToString("N0") + " seconds";

        if (gameTime > 0)
        {
            StartCoroutine(StartGameTimer());
        }
        else
        {
            m_HasTimeRunOut = true;
        }
    }

    void Update()
    {
        if (!m_HasTimeRunOut)
        {
            GameTime(gameTime);
        }
        
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
        else if (m_HasTimeRunOut)
        {
            EndLevel(timeOutBackgroundImageCanvasGroup, true, timeOutAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else 
            {
                Application.Quit();
            }
        }
    }
}
