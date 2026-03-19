using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RoundManager : MonoBehaviour
{
    [Tooltip("Round sequencing setup")]
    [SerializeField] private bool startRoundUponSceneEntry = false;

    public Player[] players;
    [SerializeField] private Dealer dealer;

    public void StartRound()
    {
        Debug.Log("Starting round according to startup sequence.");

        // InitialCardDeal for each player in list "players"
        for (int i = 0; i < players.Length; i++)
        {
            dealer.InitialCardDeal(players[i]);
            players[i].UpdateAllCardPositions();
        }
    }

    public void Start()
    {
        if (startRoundUponSceneEntry)
        {
            StartRound();
        }
    }
        

    public void ResolveRound()
    {
        Debug.Log("Resolving round...");

        for (int i = 0; i < players.Length; i++)
        {
            for (int j = i + 1; j < players.Length; j++)
            {
                ComparePlayers(players[i], players[j]);
            }
        }

        PrintScores();
    }

    void ComparePlayers(Player a, Player b)
    {
        Hand[] aHands = { a.hand_1, a.hand_2, a.hand_3 };
        Hand[] bHands = { b.hand_1, b.hand_2, b.hand_3 };

        foreach (Hand handA in aHands)
        {
            foreach (Hand handB in bHands)
            {
                CompareHands(a, handA, b, handB);
            }
        }
    }

    void CompareHands(Player playerA, Hand handA, Player playerB, Hand handB)
    {
        int valueA = handA.CalculateHandValue();
        int valueB = handB.CalculateHandValue();

        bool bustA = valueA > 21;
        bool bustB = valueB > 21;

        if (bustA && bustB)
            return;

        if (bustA)
        {
            playerB.score++;
            return;
        }

        if (bustB)
        {
            playerA.score++;
            return;
        }

        if (valueA > valueB)
        {
            playerA.score++;
        }
        else if (valueB > valueA)
        {
            playerB.score++;
        }
    }

    void PrintScores()
    {
        Debug.Log("Round finished. Scores:");

        foreach (Player p in players)
        {
            Debug.Log($"{p.name}: {p.score}");
        }
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(RoundManager))]
public class RoundManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoundManager rm = (RoundManager)target;

        if (GUILayout.Button("Resolve Round"))
        {
            rm.ResolveRound();
        }
        if (GUILayout.Button("StartRound"))
        {
            rm.StartRound();
        }
    }
}
#endif