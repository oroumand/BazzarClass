using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublish>
    {
        private readonly IUnitOfWork unitOfWork;
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public RequestToPublishHandler(IUnitOfWork unitOfWork, IAdvertisementsRepository advertisementsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(RequestToPublish command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.RequestToPublish();
            unitOfWork.Commit();
        }
    }
}
