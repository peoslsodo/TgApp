using System;

namespace TgApp.Model
{
    internal class SugarColumnAttribute : Attribute
    {
        public bool IsPrimaryKey { get; set; }
    }
}