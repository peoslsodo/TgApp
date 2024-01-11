using System;

namespace TgApp.Model
{
    public class Groups
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        public string Title { get; set; }


        /// <summary>
        /// True, if the chat is blocked by the current user and private messages from the chat can't be received
        /// </summary>
        public bool IsBlocked { get; set; }


        public bool IsSuper { get; set; }

        public bool IsChannel { get; set; }

        public long GroupId { get; set; }
        public DateTime Date { get; set; }


    }


    public class GroupView {
        public long Id { get; set; }

        public string Title { get; set; }

        public bool IsChannel { get; set; }

        public long GroupId { get; set; }

        public bool Choice { get; set; }

    }
}