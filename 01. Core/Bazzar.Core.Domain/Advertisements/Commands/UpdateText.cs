using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class UpdateText
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
