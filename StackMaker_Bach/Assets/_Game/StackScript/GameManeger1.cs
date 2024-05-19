using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.StackScript
{
    public enum GameState { MainMenu, GamePlay, Finish }

    public class GameManeger1 : Singleton<GameManeger1>
    {

        private GameState state;

        private void Awake()
        {
            // Set up game
            // Set up data
            ChangeState(GameState.MainMenu);
        }

        public void ChangeState(GameState gameState)
        {
            state = gameState;
        }

        public bool IsState(GameState gameState)
        {
            return state == gameState;
        }

    }


}
