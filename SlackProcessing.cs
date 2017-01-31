using System;
using System.Collections;
using System.Collections.Generic;
using PX.SM;
using PX.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace AcumaticaHackathon
{
    public class SlackProcessing : PXGraph<SlackProcessing>
    {
        public SlackProcessing()
        {
            SlackSetup setup = Setup.Current;

            Messages.SetProcessDelegate(
                delegate (List<SlackMessage> list)
                {
                    Process(list, true);
                }
            );
        }

        public PXSetup<SlackSetup> Setup;

        public PXCancel<SlackMessage> Cancel;

        public override bool IsDirty
        {
            get
            {
                return false;
            }
        }

        [PXFilterable()]
        public PXProcessing<SlackMessage,
                 Where<SlackMessage.released, Equal<False>>> Messages;

        public static void Process(List<SlackMessage> list, bool isMassProcess)
        {
            string errorMessage = string.Empty;
            bool erroroccurred = false;
            SlackSetupMaint setupGraph = PXGraph.CreateInstance<SlackSetupMaint>();
            SlackMessageMaint graph = PXGraph.CreateInstance<SlackMessageMaint>();
            SlackSetup setup = setupGraph.SetupRecord.SelectSingle();
            foreach (SlackMessage message in list)
            {
                try
                {
                    if ((bool)message.IsSimple)
                    {
                        var msg = createSimpleMessage(message);
                        WebRequest.postRequest(setup.SlackURL, msg);
                    }
                    else
                    {
                      //var  msg = createDetailMessage(message);
                      var msg = createDetailMessageWithFields(setup.AcumaticaURL, message);
                        WebRequest.postRequest(setup.SlackURL, msg);
                    }
                    message.Released = true;
                    graph.Messages.Update(message);
                    graph.Save.Press();
                    PXProcessing<SlackMessage>.SetInfo(list.IndexOf(message), "Processed.");
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    erroroccurred = true;
                    PXProcessing<SlackMessage>.SetError(list.IndexOf(message), String.Format("{0}", ex.Message));
                }
            }
            if (erroroccurred && isMassProcess)
                throw new PXException("A least one Transaction hasn't been processed.");
            if (erroroccurred && !isMassProcess)
                throw new PXException(errorMessage);
        }


        public PXAction<SlackMessage> CreateMessage;
        [PXButton()]
        [PXUIField(DisplayName = "Create Message")]
        protected virtual IEnumerable createMessage(PXAdapter adapter)
        {
                SlackMessageMaint graph = PXGraph.CreateInstance<SlackMessageMaint>();
                SlackMessage msg = WebRequest.createTestSlackMessage();
                graph.Messages.Insert(msg);
                graph.Save.Press();
            return adapter.Get();
        }

        private static SimpleMessage createSimpleMessage(SlackMessage message)
        {
            SimpleMessage simpleMsg = new SimpleMessage()
            {
                Channel = message.Channel,
                Text = message.Pretext,
                Color = message.Color
            };
            return simpleMsg;
        }

        private static DetailMessage createDetailMessage(string AcumaticaURL, SlackMessage message)
        {
            DetailMessage detailMsg = new DetailMessage()
            {

                Channel = message.Channel,
                Attachments = new List<MessageAttachment>()
                {
                    new MessageAttachment()
                    {
                        Pretext = message.Pretext,
                        Username = message.Username,
                        Title = message.Title,
                        Text =  String.Format("<{0}{1}|{2}>", AcumaticaURL, message.ScreenURL, message.ScreenURLDescr), 
                        Color = message.Color,
                        Fallback = message.Fallback
                    }
                }    
            };
            return detailMsg;
        }

        private static DetailMessage createDetailMessageWithFields(string AcumaticaURL, SlackMessage message)
        {
            DetailMessage detailMsg = new DetailMessage()
            {

                Channel = message.Channel,
                Attachments = new List<MessageAttachment>()
                {
                    new MessageAttachment()
                    {
                        Pretext = message.Pretext,
                        Username = message.Username,
                        //Title = message.Title,
                        Text =  String.Format("<{0}{1}|{2}>", AcumaticaURL, message.ScreenURL, message.ScreenURLDescr),
                        Fields = new List<Field>() { new Field() { Short = message.FieldShort, Title = message.FieldTitle, Value = message.FieldValue } },
                        Color = message.Color,
                        Fallback = message.Fallback
                    }
                }
            };
            return detailMsg;
        }

        

    }
}
