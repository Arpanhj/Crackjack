using UnityEngine;
using Unity.Netcode;
using NUnit.Framework;
using System.Collections.Generic;

public class GameStateProvider : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class NetworkedGameState
{
    enum GameState { Pregame, Game, Postgame };
    GameState gameState = GameState.Pregame;
}
