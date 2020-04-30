using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CenterTargetHit : MonoBehaviour
{
    public TextMeshPro scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        score = int.Parse(scoreText.text.ToString());
        Debug.Log(score);
        score += 50;
        scoreText.text = score.ToString();
    }
}
