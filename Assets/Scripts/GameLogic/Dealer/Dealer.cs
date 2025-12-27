using UnityEngine;
using UnityEditor;

public class Dealer : MonoBehaviour
{
    public Deck deck;

    [SerializeField] public Player[] players;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialCardDeal(Player player)
    {
        Debug.Log($"Initial Card Deal for player {player.name}");
        if (player.hand_1.cards[0] != null) { Debug.LogWarning("Confused Screaming: cards were dealt before the beginning of time."); return; }
        player.hand_1.cards[0] = deck.DrawCard();
        player.hand_1.cards[1] = deck.DrawCard();
        player.hand_2.cards[0] = deck.DrawCard();
        player.hand_2.cards[1] = deck.DrawCard();
        player.hand_3.cards[0] = deck.DrawCard();
        player.hand_3.cards[1] = deck.DrawCard();
    }
}


[CustomEditor(typeof(Dealer))]
public class DealerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw normal inspector
        DrawDefaultInspector();

        Dealer script = (Dealer)target;

        GUILayout.Space(10);

        if (GUILayout.Button(new GUIContent("Deal or no deal???", "Deal, obviously\nWhy the fuck would we have a no deal button?\nGo sit in the corner and think about how stupid you are.")))
        {
            script.InitialCardDeal(script.players[0]);
            script.InitialCardDeal(script.players[1]);
        }
    }
}