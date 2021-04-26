using Dapper;
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
    public class OutQueRepository : BaseRepository, IOutQueRepository
    {
        private readonly ICommandText _commandText;

        public OutQueRepository(IConfigurationRoot configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }

        public async Task InsertOutQue(OutQue outQue)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.InsertOutQue, outQue);
            });

        }
    }
}
