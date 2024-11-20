using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for text boxes
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //this is based off how i wrote my score counter in the apple picker game
    private TextMeshProUGUI uiText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}
