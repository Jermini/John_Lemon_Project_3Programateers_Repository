using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject checkpointPrefab;
    public AudioSource checkpointAudio;
    bool m_HasAudioPlayed;
    int score; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        m_HasAudioPlayed = false;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (!m_HasAudioPlayed)
            {
                checkpointAudio.Play();
                m_HasAudioPlayed = true;
            }

            AddScore(5);
            Destroy(this.gameObject);
        }
    }
}
