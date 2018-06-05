using System;
using System.Collections.Generic;
using System.Linq;
using CutieShop.Models.JSONEntities.FacebookRichMessages;

namespace CutieShop.Models.Utils
{
    public static class RespBuilderUtils
    {
        public enum RespType
        {
            Text,
            QuickReplies,
            Cards,
            Button
        }

        public static object RespObj(RespType type,
            string msg,
            string[] replyTitles = null,
            (string Title, string Subtitle, string PostBack, string CardImg, string BtnText)[] cards = null,
            string btnTitle = null, string btnPayload = null)
        {
            switch (type)
            {
                case RespType.Text:
                    return new
                    {
                        speech = msg
                    };
                case RespType.QuickReplies:
                    return new
                    {
                        speech = "",
                        messages = new[]
                        {
                        new {
                            type = 2,
                            platform = "facebook",
                            title = msg,
                            replies = replyTitles
                        }
                        }
                    };
                case RespType.Cards:
                    if (cards == null)
                        return null;
                    return new
                    {
                        speech = msg,
                        messages = cards.Select(card => new MessCard
                        {
                            type = 1,
                            platform = "facebook",
                            title = card.Title,
                            subtitle = card.Subtitle,
                            imageUrl = card.CardImg,
                            buttons = new[]
                            {
                                new Button
                                {
                                    text = card.BtnText,
                                    postback = card.PostBack
                                }
                            }
                        }).ToArray()
                    };
                case RespType.Button:
                    return new
                    {
                        speech = "",
                        messages = new[]
                        {
                            new
                            {
                                type = 4,
                                platform = "facebook",
                                title = (string) null,
                                replies = (string[]) null,
                                payload = new
                                {
                                    facebook = new
                                    {
                                        attachment = new
                                        {
                                            type = "template",
                                            payload = new
                                            {
                                                template_type = "button",
                                                text = msg,
                                                buttons = new[]
                                                {
                                                    new
                                                    {
                                                        type = "postback",
                                                        title = btnTitle,
                                                        payload = btnPayload
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// Reply 2 messages. The first one must be text type
        /// </summary>
        /// <param name="respObject"></param>
        /// <returns></returns>
        public static object MultiResp(params dynamic[] respObject)
        {
            var lstMsg = new List<dynamic>(new[] { new
            {
                type = 0,
                platform = "facebook",
                respObject[0].speech
            } });
            lstMsg.AddRange(respObject[1].messages);

            return new
            {
                messages = lstMsg.ToArray()
            };
        }
    }
}
