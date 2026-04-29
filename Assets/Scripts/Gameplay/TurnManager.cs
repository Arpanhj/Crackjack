using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Player[] players;

    private int currentPlayerIndex = 0;
    [SerializeField] RoundManager roundManager;

    public Player CurrentPlayer => players[currentPlayerIndex];

    public void NextPlayer()
    {
        currentPlayerIndex++;

        if (currentPlayerIndex >= players.Length)
        {
            Debug.Log("All players finished turns.");
            roundManager.ResolveRound();
            return;
        }

        Debug.Log($"Now it's {CurrentPlayer.name}'s turn");
    }

    public void StartTurns()
    {
        currentPlayerIndex = 0;
        Debug.Log($"Starting turns. First player: {CurrentPlayer.name}");
    }
}