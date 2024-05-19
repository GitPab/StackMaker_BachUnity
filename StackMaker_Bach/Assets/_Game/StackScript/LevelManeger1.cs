using Assets.StackScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.StackScript
{
    public class LevelManager1 : Singleton<LevelManager1>
    {
        public List<Level> levels = new List<Level>();
        public Player player;
        Level currentLevel;

        public int level = 1;

        private void Start()
        {

            UIManager.Ins.OpenMainMenuUI();
            LoadLevel();
        }

        public void LoadLevel()
        {
            LoadLevel(level);
            OnInit();
        }
        public void LoadLevel(int indexLevel)
        {
            if (currentLevel != null)
            {
                Destroy(currentLevel.gameObject);
            }

            currentLevel = Instantiate(levels[indexLevel - 1]);
        }

        public void NextLevel()
        {
            level++;
            LoadLevel();
        }

        public void OnInit()
        {
            player.transform.position = currentLevel.startPoint.position;
            Debug.Log(player.transform.position);
            player.OnInit();
        }

        public void OnStart()
        {
            GameManeger1.Ins.ChangeState(GameState.GamePlay);
        }

        public void OnFinish()
        {
            UIManager.Ins.OpenFinishUI();
            GameManeger1.Ins.ChangeState(GameState.Finish);
        }

        public bool CheckNextLevel()
        {
            if (level <= levels.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}