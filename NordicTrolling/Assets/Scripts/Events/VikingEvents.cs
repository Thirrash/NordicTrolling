using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events;

namespace Assets.Scripts.Events
{
    public class VikingRandomMoveEvent : GameEvent
    {
        public bool IsEnabled { get; set; }

        public VikingRandomMoveEvent(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
    }
}
