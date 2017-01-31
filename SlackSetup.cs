using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PX.SM;
using PX.Data;
namespace AcumaticaHackathon
{
    [System.SerializableAttribute()]
    [PXPrimaryGraph(typeof(SlackSetupMaint))]
    public class SlackSetup : PX.Data.IBqlTable
    {

        #region SlackURL 
        public abstract class slackURL : IBqlField { }
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Slack URL")]
        public virtual string SlackURL { get; set; }
        #endregion

        #region AcumaticaURL 
        public abstract class acumaticaURL : IBqlField { }
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Acumatica URL")]
        public virtual string AcumaticaURL { get; set; }
        #endregion

        #region EnableCRCase
        public abstract class enableCRCase : IBqlField { }
        [PXDBBool()]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Enable Cases")]
        public virtual bool? EnableCRCase { get; set; }
        #endregion

        #region CRCaseChannel
        public abstract class cRCaseChannel : IBqlField { }
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Case Channel")]
        public virtual string CRCaseChannel { get; set; }
        #endregion


    }
}
