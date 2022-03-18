using UnityEngine;

public class DiceGame : MonoBehaviour
{
    // We use two variables to keep track of the max. and current amount of rolls, so that 
    // we can reset the game without hardcoding the number 3 in the Update function
    int maxRolls = 3;
    int currentRolls;

    int playerResult = 0;

    void Start()
    {
        InitializeGame();
    }

    // This method resets the game. We use a separate method since it is called twice
    void InitializeGame()
    {
        currentRolls = 0;
        Debug.Log($"Roll with SPACE, keep with RETURN.");
        Debug.Log("========================");
    }

    void Update()
    {
        // Roll dice if the player presses SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If there are no rolls remaining, print an error message
            if (currentRolls >= maxRolls)
                Debug.LogError("No rolls remaining.");
            else
            {
                // Roll two six-sided dice and add one attempt
                playerResult = Random.Range(1, 7) + Random.Range(1, 7);
                currentRolls++;

                Debug.Log($"Player result: {playerResult} || Rolls remaining: {maxRolls - currentRolls}");
            }
        }

        // Keep the result, but only if the player has rolled at least once
        if (Input.GetKeyDown(KeyCode.Return) && currentRolls > 0)
        {
            // Roll two six-sided dice for the AI and compare results
            var aiResult = Random.Range(1, 7) + Random.Range(1, 7);
            Debug.Log($"Player - {playerResult} | AI - {aiResult}");

            if (playerResult > aiResult) // Player has higher number
                Debug.Log("You win!");
            else if (aiResult > playerResult) // AI has higher number
                Debug.Log("You lose.");
            else // Both numbers are the same
                Debug.Log("You tied, nobody wins.");
       
            // Reset the game
            InitializeGame();
        }
    }
}
