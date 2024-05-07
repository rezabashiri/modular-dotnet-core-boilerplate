// --------------------------------------------------------------------------------------------------
// <copyright file="TwilioSmsService.cs" company="">
// Copyright (c) . All rights reserved.
// The core team: Reza Bashiri.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Core.Interfaces.Services;
using Shared.Core.Settings;
using Shared.DTOs.Sms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Shared.Infrastructure.Services
{
    public class TwilioSmsService : ISmsService
    {
        private readonly SmsSettings _settings;
        private readonly ILogger<TwilioSmsService> _logger;

        public TwilioSmsService(IOptions<SmsSettings> settings, ILogger<TwilioSmsService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public Task SendAsync(SmsRequest request)
        {
            try
            {
                string accountSid = _settings.SmsAccountIdentification;
                string authToken = _settings.SmsAccountPassword;

                TwilioClient.Init(accountSid, authToken);

                return MessageResource.CreateAsync(
                    to: new PhoneNumber(request.Number),
                    @from: new PhoneNumber(_settings.SmsAccountFrom),
                    body: request.Message);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return Task.CompletedTask;
        }
    }
}