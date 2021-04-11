using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Constants
{
    public class ConfigurationConstants
    {
        public const string StorageAccountConnectionString = nameof(StorageAccountConnectionString);

        public const string ContainerName = nameof(ContainerName);

        public const string UserDataDbConnectionString = nameof(UserDataDbConnectionString);

        public const string GameLibServerUri = nameof(GameLibServerUri);

        public const string SendGridKey = nameof(SendGridKey);

        public const string OrganizationEmail = nameof(OrganizationEmail);

        public const string MicrosoftClientId = nameof(MicrosoftClientId);

        public const string MicrosoftClientSecret = nameof(MicrosoftClientSecret);
    }
}
