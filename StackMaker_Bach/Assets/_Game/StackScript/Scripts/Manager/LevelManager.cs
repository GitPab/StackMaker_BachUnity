using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackMaker
{
    public class LevelManager : Singleton<LevelManager>
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
            player.OnInit();
        }

        public void OnStart()
        {
            GameManager.Ins.ChangeState(GameState.GamePlay);
        }

        public void OnFinish()
        {
            UIManager.Ins.OpenFinishUI();
            GameManager.Ins.ChangeState(GameState.Finish);
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

