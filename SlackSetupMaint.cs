using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;

namespace AcumaticaHackathon
{
    public class SlackSetupMaint : PXGraph<SlackSetupMaint>
    {
        public PXSave<SlackSetup> Save;
        public PXCancel<SlackSetup> Cancel;

        public PXSelect<SlackSetup> SetupRecord;


        protected virtual void SlackSetup_RowSelected(PXCache cache, PXRowSelectedEventArgs e)
        {
            SlackSetup row = (SlackSetup)e.Row;
            if (row == null) return;
            PXUIFieldAttribute.SetEnabled<SlackSetup.cRCaseChannel>(SetupRecord.Cache, row, (bool)row.EnableCRCase);
        }

    }
}