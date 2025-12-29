using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand_1;
    public Hand hand_2;
    public Hand hand_3;

    [SerializeField] private HandView handView_1;
    [SerializeField] private HandView handView_2;
    [SerializeField] private HandView handView_3;

    [SerializeField] private bool cardsVisible;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

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
}

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw normal inspector
        DrawDefaultInspector();

        Player script = (Player)target;

        GUILayout.Space(10);

        if (GUILayout.Button("them cards are going places"))
        {
            script.UpdateAllCardPositions();
        }
    }
}