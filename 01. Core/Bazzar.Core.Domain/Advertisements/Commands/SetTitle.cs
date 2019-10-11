using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class SetTitle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
