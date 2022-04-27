using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.Menu
{
    public class _MenuState : MonoBehaviour
    {
       public MenuController.MenuState state { get; protected set; }

        protected MenuController menuController;


        public virtual void InitState(MenuController menuController)
        {
            this.menuController = menuController;
        }

        public void JumpBack()
        {
            menuController.JumpBack();
        }
    }
}