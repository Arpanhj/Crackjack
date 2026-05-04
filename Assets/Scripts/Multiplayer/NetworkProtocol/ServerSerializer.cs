using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEditor.VersionControl;
using UnityEngine;

public class ServerSerializer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(SerializeInitialCardDeal(GameObject.Find("Dealer").GetComponent<Dealer>().NetworkedInitialCardDeal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NetworkMessages.NetworkGameMessage SerializeStartRound()
    {
        NetworkMessages.NetworkGameMessage message = new NetworkMessages.NetworkGameMessage();
        message.type = "startround";
        message.content = "please uwu";
        return message;
    }

    public NetworkMessages.NetworkAction SerializeInitialCardDeal(Card[,] deal)
    {
        NetworkMessages.NetworkAction action = new NetworkMessages.NetworkAction();
        action.type = "carddeal";
        action.content = $"Hand_1:({deal[0, 0]},{deal[0, 1]}),Hand_2:({deal[1, 0]},{deal[1, 1]}),Hand_3:({deal[2, 0]},{deal[2, 1]})"; 
        return action;
    }
}
