using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.Menu
{
    public class HelpMenu : _MenuState
    {
        public override void InitState(MenuController menuController)
        {
            base.InitState(menuController);

            state = MenuController.MenuState.Help;
        }
    }
}