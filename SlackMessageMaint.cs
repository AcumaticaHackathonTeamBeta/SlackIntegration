using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;

namespace AcumaticaHackathon
{
    public class SlackMessageMaint : PXGraph<SlackMessageMaint, SlackMessage>
    {
        public SlackMessageMaint() { }

        public PXSelect<SlackMessage> Messages;
    }
}

        
   