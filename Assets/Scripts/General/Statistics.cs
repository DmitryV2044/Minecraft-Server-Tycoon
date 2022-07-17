using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class Statistics : MonoBehaviour
    {
        public static Statistics Instance;

        [SerializeField] private float _onlinePlayersCountModifier;
        private int _onlinePlayers;
        private int _maxPlayers;

        public int Money;
        public int OnlinePlayers => _onlinePlayers;

        public int MaxPlayers {
            get { return _maxPlayers; }
            set { _maxPlayers = value; }
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}

