using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.Menu
{
    public class MenuController : MonoBehaviour
    {

        public _MenuState[] allMenus;

        public enum MenuState
        {
            Game, Main, Settings, Help
        }

        private Dictionary<MenuState, _MenuState> menuDictionary = new Dictionary<MenuState, _MenuState>();

        private _MenuState activeState;

        private Stack<MenuState> stateHistory = new Stack<MenuState>();

        void Start()
        {
            foreach (_MenuState menu in allMenus)
            {
                if (menu == null)
                {
                    continue;
                }

                menu.InitState(menuController: this);

                if (menuDictionary.ContainsKey(menu.state))
                {
                    Debug.LogWarning($"The key <b>{menu.state}</b> already exists in the menu dictionary!");

                    continue;
                }

                menuDictionary.Add(menu.state, menu);
            }

            foreach (MenuState state in menuDictionary.Keys)
            {
                menuDictionary[state].gameObject.SetActive(false);
            }

            SetActiveState(MenuState.Game);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                activeState.JumpBack();
            }
        }

        public void JumpBack()
        {
            if (stateHistory.Count <= 1)
            {
                SetActiveState(MenuState.Main);
            }
            else
            {
                stateHistory.Pop();

                SetActiveState(stateHistory.Peek(), isJumpingBack: true);
            }
        }

        public void SetActiveState(MenuState newState, bool isJumpingBack = false)
        {
            if (!menuDictionary.ContainsKey(newState))
            {
                Debug.LogWarning($"The key <b>{newState}</b> doesn't exist so you can't activate the menu!");

                return;
            }

            if (activeState != null)
            {
                activeState.gameObject.SetActive(false);
            }

            activeState = menuDictionary[newState];

            activeState.gameObject.SetActive(true);

            if (!isJumpingBack)
            {
                stateHistory.Push(newState);
            }
        }

        public void QuitGame()
        {
            Debug.Log("You quit game!");

            Application.Quit();
        }
    }
}