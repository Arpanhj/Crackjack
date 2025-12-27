using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand hand_1;
    public Hand hand_2;
    public Hand hand_3;

    [SerializeField] private CardPositions cardPositions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardPositions = GameObject.Find("Main Camera/CardPositions").GetComponent<CardPositions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
