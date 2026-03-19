using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public int score = 0;

    public Hand hand_1;
    public Hand hand_2;
    public Hand hand_3;

    [SerializeField] private HandView handView_1;
    [SerializeField] private HandView handView_2;
    [SerializeField] private HandView handView_3;

    [SerializeField] private bool cardsVisible = true;

    public void UpdateAllCardPositions()
    {
        if (!cardsVisible)
        {
            SetHandBack(hand_1);
            SetHandBack(hand_2);
            SetHandBack(hand_3);
        }

        handView_1.Layout(hand_1.cards);
        handView_2.Layout(hand_2.cards);
        handView_3.Layout(hand_3.cards);
    }

    private void SetHandBack(Hand hand)
    {
        foreach (var card in hand.cards)
        {
            card.ReloadTexture("card_back");
        }
    }

    public void HitHand(int handIndex, Card newCard)
    {
        switch (handIndex)
        {
            case 1: hand_1.Hit(newCard); break;
            case 2: hand_2.Hit(newCard); break;
            case 3: hand_3.Hit(newCard); break;
            default: Debug.LogError("Invalid hand index"); break;
        }
        UpdateAllCardPositions();
    }

    public void StandHand(int handIndex)
    {
        switch (handIndex)
        {
            case 1: hand_1.Stand(); break;
            case 2: hand_2.Stand(); break;
            case 3: hand_3.Stand(); break;
            default: Debug.LogError("Invalid hand index"); break;
        }
        UpdateAllCardPositions();
    }
}
#if UNITY_EDITOR

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Player player = (Player)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Hit Hand 1 (test)"))
        {
            // Replace with actual card from your deck
            Card newCard = GameObject.Find("GameController/Dealer").GetComponent<Dealer>().deck.DrawCard();
            player.HitHand(1, newCard);
        }

        if (GUILayout.Button("Stand Hand 1 (test)"))
        {
            player.StandHand(1);
        }

        if (GUILayout.Button("Update Layout"))
        {
            player.UpdateAllCardPositions();
        }
    }
}

#endif