using Mono.Cecil.Cil;
using UnityEngine;

public class NetworkMessages { 
    public struct NetworkAction
    {
        public int source; // 0: server, 1-4: clients
        public string type;
        public string content;
    }

    public struct NetworkGameMessage
    {
        public string type;
        public string content;
    }
}
