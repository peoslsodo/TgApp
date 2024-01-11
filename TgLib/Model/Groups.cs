using System;
using System.Collections.Generic;
using System.Text;

namespace TgLib.Model
{
    public class Groups
    {
        public long Id { get; set; }

        public string Title { get; set; }


        /// <summary>
        /// True, if the chat is blocked by the current user and private messages from the chat can't be received
        /// </summary>
        public bool IsBlocked { get; set; }


        public bool IsSuper { get; set; }

        public bool IsChannel { get; set; }

        public long GroupId { get; set; }

    }
}
