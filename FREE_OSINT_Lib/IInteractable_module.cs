using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FREE_OSINT_Lib
{
    public interface IInteractable_module
    {
        event EventHandler InteractEvent;

        void Interact(string query);

    }
}
