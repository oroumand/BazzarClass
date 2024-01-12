using Bazzar.Core.Domain.Shared.ValueObjects;
using Bazzar.Core.Domain.UserProfiles.Events;
using Bazzar.Core.Domain.UserProfiles.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.UserProfiles.Entities
{
    public class UserProfile : BaseAggregateRoot<Guid>
    {
        #region Fields
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DisplayName DisplayName { get; private set; }
        public Email Email { get; private set; }
        #endregion

        #region Costructurs
        private UserProfile() { }

        public UserProfile(Guid id,
                          FirstName firstName,
                          LastName lastName,
                          DisplayName displayName)
        {
            HandleEvent(new UserRegistered
            {
                UserId = id,
                FirstName = firstName,
                LastName = lastName,
                DisplayName = displayName,
            });
        }
        #endregion

        public void UpdateName( FirstName firstName, LastName lastName)
        {
            HandleEvent(new UserNameUpdated
            {
                UserId = Id,
                FirstName = firstName,
                LastName = lastName
            });
        }

        public void UpdateDisplayName(DisplayName displayName)
        {
            HandleEvent(new UserDisplayNameUpdated
            {
                UserId = Id,
                DisplayName = displayName,
            });
        }

        public void UpdateEmail(Email email)
        {
            HandleEvent(new UserEmailUpdated
            {
                UserId = Id,
                Email = email,
            });
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case UserRegistered e:
                    Id = e.UserId;
                    FirstName = FirstName.FromString(e.FirstName);
                    LastName = LastName.FromString(e.LastName);
                    DisplayName = DisplayName.FromString(e.DisplayName);
                    break;
                case UserNameUpdated e:
                    FirstName = FirstName.FromString(e.FirstName);
                    LastName = LastName.FromString(e.LastName);
                    break;
                case UserEmailUpdated e:
                    Email = Email.FromString(e.Email);
                    break;
                case UserDisplayNameUpdated e:
                    DisplayName = DisplayName.FromString(e.DisplayName);
                    break;
                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        protected override void ValidateInvariants()
        {
            //Impliment invariants
        }
    }
}
