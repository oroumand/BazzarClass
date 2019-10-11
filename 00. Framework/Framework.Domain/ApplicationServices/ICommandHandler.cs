using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.ApplicationServices
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
