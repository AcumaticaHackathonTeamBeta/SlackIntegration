using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using Newtonsoft.Json;

namespace AcumaticaHackathon
{
    [System.SerializableAttribute()]
    [PXCacheName("SlackMessage")]
    public class SlackMessage : IBqlTable
    {
        #region RequestID
        public abstract class requestID : IBqlField { }
        [PXUIField(Enabled = false)]
        [PXDBIdentity(IsKey = true)]
        public virtual int? RequestID { get; set; }
        #endregion
        #region Released
        public abstract class released : IBqlField { }
        [PXDBBool()]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Released")]
        public virtual bool? Released { get; set; }
        #endregion

        #region IsSimple
        public abstract class isSimple : IBqlField { }
        [PXDBBool()]
        [PXDefault(true)]
        [PXUIField(DisplayName = "Is Simple")]
        public virtual bool? IsSimple { get; set; }
        #endregion

        //Slack
        #region Channel
        public abstract class channel : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Channel")]
        public virtual string Channel { get; set; }
        #endregion

        #region Pretext
        public abstract class pretext : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Pretext")]
        public virtual string Pretext { get; set; }
        #endregion

        #region Username
        public abstract class username : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Username")]
        public virtual string Username { get; set; }
        #endregion

        #region Title
        public abstract class title : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Title")]
        public virtual string Title { get; set; }
        #endregion

        #region Fallback
        public abstract class fallback : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Fallback")]
        public virtual string Fallback { get; set; }
        #endregion

        #region Color
        public abstract class color : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Color")]
        public virtual string Color { get; set; }
        #endregion

        #region ScreenURL
        public abstract class screenURL : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "ScreenURLPrams")]
        public virtual string ScreenURL { get; set; }
        #endregion

        #region ScreenURLDescr
        public abstract class screenURLDescr : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "URL Description")]
        public virtual string ScreenURLDescr { get; set; }
        #endregion

        #region TextDetail
        public abstract class textDetail : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Detail")]
        public virtual string TextDetail { get; set; }
        #endregion

        #region FieldTitle
        public abstract class fieldTitle : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "FieldTitle")]
        public virtual string FieldTitle { get; set; }
        #endregion

        #region FieldValue
        public abstract class fieldValue : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "FieldValue")]
        public string FieldValue { get; set; }
        #endregion

        #region FieldShort
        public abstract class fieldShort : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "FieldShort")]
        public string FieldShort { get; set; }
        #endregion

        #region tstamp
        public abstract class Tstamp : IBqlField { }
        [PXDBTimestamp()]
        public virtual byte[] tstamp { get; set; }
        #endregion
        
        #region CreatedByID
        public abstract class createdByID : IBqlField { }
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        #endregion

        #region CreatedByScreenID
        public abstract class createdByScreenID : IBqlField { }
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        #endregion

        #region CreatedDateTime
        public abstract class createdDateTime : IBqlField { }
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        #endregion

        #region LastModifiedByID
        public abstract class lastModifiedByID : IBqlField { }
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }

        #endregion
        
        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : IBqlField { }
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        #endregion
        
        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : IBqlField { }
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        #endregion

        //Non-SQL Fields
        #region Selected
        public abstract class selected : IBqlField { }
        [PXBool()]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        #endregion
        
    }


    [System.SerializableAttribute()]
    public class SimpleMessage
    {
        #region Channel
        [JsonProperty("channel")]
        public virtual string Channel { get; set; }
        #endregion

        #region Pretext
        [JsonProperty("pretext")]
        public virtual string Pretext { get; set; }
        #endregion

        #region Text
        [JsonProperty("text")]
        public virtual string Text { get; set; }
        #endregion

   
        #region Color
        public abstract class color : IBqlField { }
        [PXDBString(200, IsUnicode = true)]
        [PXUIField(DisplayName = "Color")]
        [JsonProperty("color")]
        public virtual string Color { get; set; }
        #endregion

       

    }   

    [System.SerializableAttribute()]
    public class DetailMessage
    {
        #region Channel
        [JsonProperty("channel")]
        public virtual string Channel { get; set; }
        #endregion

        #region Attachments
        [JsonProperty("attachments")]
        public List<MessageAttachment> Attachments { get; set; }
        #endregion

    }

    [System.SerializableAttribute()]   
    public class MessageAttachment
    {
        #region Fallback
        [JsonProperty("fallback")]
        public virtual string Fallback { get; set; }
        #endregion

        #region Color
        [JsonProperty("color")]
        public virtual string Color { get; set; }
        #endregion

        #region Pretext
        [JsonProperty("pretext")]
        public virtual string Pretext { get; set; }
        #endregion

        #region Username
        [JsonProperty("author_name")]
        public virtual string Username { get; set; }
        #endregion

        #region Title
        [JsonProperty("title")]
        public virtual string Title { get; set; }
        #endregion

        #region Text
        [JsonProperty("text")]
        public virtual string Text { get; set; }
        #endregion

        #region TitleLink
        [JsonProperty("title_link")]
        public virtual string TitleLink { get; set; }
        #endregion

        #region Fields
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
        #endregion

    }

    [System.SerializableAttribute()]
    public class Field
    {
        #region
        [JsonProperty("title")]
        public string Title { get; set; }
        #endregion

        #region
        [JsonProperty("value")]
        public string Value { get; set; }
        #endregion

        #region
        [JsonProperty("short")]
        public string Short { get; set; }
        #endregion

    }


    /* "attachments": [
       {
           "fallback": "Required plain-text summary of the attachment.",
           "color": "#36a64f",
           "pretext": "Optional text that appears above the attachment block",
           "author_name": "Bobby Tables",
           "author_link": "http://flickr.com/bobby/",
           "author_icon": "http://flickr.com/icons/bobby.jpg",
           "title": "Slack API Documentation",
           "title_link": "https://api.slack.com/",
           "text": "Optional text that appears within the attachment",
           "fields": [
               {
                   "title": "Priority",
                   "value": "High",
                   "short": false
               }
           ],
           "image_url": "http://my-website.com/path/to/image.jpg",
           "thumb_url": "http://example.com/path/to/thumb.png",
           "footer": "Slack API",
           "footer_icon": "https://platform.slack-edge.com/img/default_application_icon.png",
           "ts": 123456789
       }
   ]*/
}
