using Johnny.ShoeStore.WebUI.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    public static class MessageHelper
    {
        private static StringBuilder sbMessage = new StringBuilder();
        public static MessageModel BuildMessage(EnumSevereLevel level, string message)
        {
            MessageModel msg = new MessageModel();
            msg.Level = level;           
            msg.Title = Enum.GetName(typeof(EnumSevereLevel), msg.Level);
            msg.Message = message;
            msg.BoxStyle = GetBoxStyle(msg.Level);
            return msg;
        }

        public static MessageModel BuildMessage(EnumSevereLevel level, IdentityResult result)
        {
            string message = "";
            foreach (string error in result.Errors)
            {
                message = String.Concat(error, Environment.NewLine);
            }

            MessageModel msg = new MessageModel();
            msg.Level = level;
            msg.Title = Enum.GetName(typeof(EnumSevereLevel), msg.Level);
            msg.Message = message;
            msg.BoxStyle = GetBoxStyle(msg.Level);
            return msg;
        }       

        public static void AppendMessage(string message, bool refresh = false)
        {
            if (refresh == true)
                sbMessage.Clear();

            sbMessage.Append(message);
            sbMessage.Append(Environment.NewLine);
        }

        public static void AppendMessage(IdentityResult result, bool refresh = false)
        {
            if (refresh == true)
                sbMessage.Clear();

            foreach (string error in result.Errors)
            {
                sbMessage.Append(error);
                sbMessage.Append(Environment.NewLine);
            }            
        }

        public static void ClearMessage()
        {
            sbMessage.Clear();
        }

        public static MessageModel GetMessage(EnumSevereLevel level)
        {
            MessageModel msg = new MessageModel();
            msg.Level = level;
            msg.Title = Enum.GetName(typeof(EnumSevereLevel), msg.Level);
            msg.Message = sbMessage.ToString();
            msg.BoxStyle = GetBoxStyle(msg.Level);

            sbMessage.Clear();
            return msg;
        }

        private static string GetBoxStyle(EnumSevereLevel level)
        {
            switch (level)
            {
                case EnumSevereLevel.Infomation:
                    return "btn-info";
                case EnumSevereLevel.Warning:
                    return "btn-warning";
                case EnumSevereLevel.Error:
                    return "btn-danger";
                case EnumSevereLevel.Success:
                    return "btn-success";
                default:
                    return "btn-info";
            }
        }
    }
}