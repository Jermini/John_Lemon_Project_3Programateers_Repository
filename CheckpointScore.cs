using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointScore : MonoBehaviour
{
    public GameObject checkpointPrefab;
    public AudioSource checkpointAudio;
    private GameManager gameManager; 
    bool m_HasAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        m_HasAudioPlayed = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }   

    void OnTriggerEnter(Collider collision)
    {
        int collisionScore = 5;

        if (collision.tag == "Player")
        {
            if (!m_HasAudioPlayed)
            {
                checkpointAudio.Play();
                m_HasAudioPlayed = true;
            }

            gameManager.AddScore(collisionScore);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

    }
}
