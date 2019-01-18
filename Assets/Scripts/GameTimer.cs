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
                timeText.SetText("Time: " + Mathf.RoundToInt(timer));
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
            }
        }

        void DisplayWinner(string winner)
        {
            if (winner == "MLP")
            {
                mlpScore++;
            }
            if (winner == "IPP")
            {
                ippScore++;
            }
            print(winner + " is the winner!");
            winnerText.SetText(winner);
        }
    }
}
