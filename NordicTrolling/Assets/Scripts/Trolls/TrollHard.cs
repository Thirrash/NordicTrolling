using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trolls
{
    public class TrollHard : TrollBase
    {
        protected override void Start( ) {
            base.Start( );
            FightTime = 7.0f;
        }
    }
}
