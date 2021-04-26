using Dapper;
using Microsoft.Extensions.Configuration;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Base;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Infrastructure.Repositories.Queries;
using Sampath.SMSB.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sampath.SMSB.Infrastructure.Repositories
{
    public class SMSMTNRepository : BaseRepository, ISMSMTNRepository
    {
        private readonly ICommandText _commandText;

        public SMSMTNRepository(IConfigurationRoot configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }

        public async Task<Smsmtn> GetTeleBankingDetails(Message message)
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Smsmtn>(_commandText.GetTeleBankingDetails, new { SmsPhoneno = message.TxnId });
                return query;
            });

        }
        public async Task<int> GetRetryCount(string teleBankingNo)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<int>(_commandText.GetRetryCount, new { TeleBankNo = teleBankingNo });
                return query;
            });
        }
        public async Task SetRetryCount(string teleBankingNo, int count)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.SetEncRec,
                    new { Count = count, TeleBankNo = teleBankingNo });
            });

        }

        public async Task SuspendTeleBanking(string teleBankingNo)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.SetEncRec,
                    new { TeleBankNo = teleBankingNo });
            });

        }
    }
}
