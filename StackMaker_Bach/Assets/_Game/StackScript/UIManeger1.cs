
using Assets.StackScript;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StackScript
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject mainMenuUI;
        public GameObject finishUI;
        public GameObject tobecontinueUI;

        public Text currentlevel;

        public void OpenMainMenuUI()
        {
            mainMenuUI.SetActive(true);
            finishUI.SetActive(false);
            tobecontinueUI.SetActive(false);

           // currentlevel.text = "Level " + LevelManager1.Ins.level.ToString();
        }

        public void OpenFinishUI()
        {
            mainMenuUI.SetActive(false);
            finishUI.SetActive(true);
            tobecontinueUI.SetActive(false);
        }

        public void OpenComingSoonUI()
        {
            mainMenuUI.SetActive(false);
            finishUI.SetActive(false);
            tobecontinueUI.SetActive(true);

        }

        public void PlayButton()
        {
            mainMenuUI.SetActive(false);
            LevelManager1.Ins.OnStart();
            Debug.Log("ui");
        }

        public void RetryButton()
        {
            LevelManager1.Ins.LoadLevel();
            GameManeger1.Ins.ChangeState(GameState.MainMenu);
            OpenMainMenuUI();
        }

        public void NextButton()
        {
            if (LevelManager1.Ins.CheckNextLevel())
            {
                LevelManager1.Ins.NextLevel();
                GameManeger1.Ins.ChangeState(GameState.MainMenu);
                OpenMainMenuUI();
            }
            else
            {
                GameManeger1.Ins.ChangeState(GameState.Finish);
                OpenComingSoonUI();
            }
        }
    }
}
