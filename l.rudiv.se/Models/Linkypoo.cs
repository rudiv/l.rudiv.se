using Chic.Constraints;
using System;

namespace l.rudiv.se.Pages
{
    public class Linkypoo : IKeyedEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}