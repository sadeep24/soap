﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Base;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Infrastructure.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sampath.SMSB.Infrastructure.Repositories
{
    public class InQueRepository : BaseRepository, IInQueRepository
    {
        private readonly ICommandText _commandText;

        public InQueRepository(IConfigurationRoot configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }

        public async Task<IEnumerable<InQue>> GetAllProducts()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<InQue>(_commandText.GetSMS);
                return query;
            });

        }
        public async Task UpbateInqReq(string teliponde,string encmessage)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.SetEncRec,
                    new { Tele = teliponde, Enc = encmessage });
            });
        }
    }
}
