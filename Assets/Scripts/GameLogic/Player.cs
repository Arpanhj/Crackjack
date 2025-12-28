using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand_1;
    public Hand hand_2;
    public Hand hand_3;

    [SerializeField] private CardPositions cardPositions;
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
            hand_1.cards[0].ReloadTexture("card_back");
            hand_1.cards[1].ReloadTexture("card_back");
            hand_2.cards[0].ReloadTexture("card_back");
            hand_2.cards[1].ReloadTexture("card_back");
            hand_3.cards[0].ReloadTexture("card_back");
            hand_3.cards[1].ReloadTexture("card_back");
            hand_1.cards[0].ReloadTexture("card_back");
        }
        hand_1.cards[0].SetPosition(cardPositions.LeftFirst);
        hand_1.cards[1].SetPosition(cardPositions.LeftSecond);
        hand_2.cards[0].SetPosition(cardPositions.MiddleFirst);
        hand_2.cards[1].SetPosition(cardPositions.MiddleSecond);
        hand_3.cards[0].SetPosition(cardPositions.RightFirst);
        hand_3.cards[1].SetPosition(cardPositions.RightSecond);
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