using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class SetTitleHandler : ICommandHandler<SetTitle>
    {
        private readonly IUnitOfWork unitOfWork;
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public SetTitleHandler(IUnitOfWork unitOfWork, IAdvertisementsRepository advertisementsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(SetTitle command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.SetTitle(AdvertismentTitle.FromString(command.Title));
            unitOfWork.Commit();
        }
    }
}
