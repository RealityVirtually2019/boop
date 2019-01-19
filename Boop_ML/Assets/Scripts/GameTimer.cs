using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro.Examples {

    public class GameTimer : MonoBehaviour
    {
        float timer = 0.0f;
        [SerializeField]
        float timeLimit = 5.0f;
        [SerializeField]
        private TextMeshPro timeText;
        [SerializeField]
        private TextMeshPro winnerText;
        [SerializeField]
        private TextMeshPro mlpText;
        [SerializeField]
        private TextMeshPro ippText;

        bool gameOver = false;

        int mlpScore = 0;
        int ippScore = 0;

        bool isPlaying = true;
        bool laughing = false;

        // Update is called once per frame
        void Update()
        {
            if (isPlaying)
            {
                timer += Time.deltaTime;
                print("Play mode");
                timeText.SetText(Mathf.RoundToInt(timer).ToString());
            }

            if (laughing || Input.GetKeyDown(KeyCode.L))
            {
                isPlaying = false;              
                DisplayWinner("MLP");
            }

            if (timer >= timeLimit)
            {
                isPlaying = false;
                DisplayWinner("IPP");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                timer = 0.0f;
                isPlaying = true;
                gameOver = false;
            }
        }

        void DisplayWinner(string winner)
        {
            if (winner == "MLP" && gameOver == false)
            {
                mlpScore++;
                mlpText.SetText("MLP: " + mlpScore);
            }
            if (winner == "IPP" && gameOver == false)
            {
                ippScore++;
                ippText.SetText("IPP: " + ippScore);
            }
            winnerText.SetText(winner + " is the winner!");
            gameOver = true;
        }
    }
}
