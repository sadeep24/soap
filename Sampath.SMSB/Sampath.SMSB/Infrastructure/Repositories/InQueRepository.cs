using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Base;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Infrastructure.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    }
}
