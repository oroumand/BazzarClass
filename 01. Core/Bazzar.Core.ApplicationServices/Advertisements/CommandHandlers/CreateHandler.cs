using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class CreateHandler : ICommandHandler<Create>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAdvertisementsRepository advertisementsRepository;

        public CreateHandler(IUnitOfWork unitOfWork, IAdvertisementsRepository advertisementsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(Create command)
        {
            if (advertisementsRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

            var advertisement = new Advertisment(command.Id,
                new UserId(command.OwnerId)
            );
            advertisementsRepository.Add(advertisement);
            unitOfWork.Commit();
        }
    }
}
