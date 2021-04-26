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
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly ICommandText _commandText;

        public CustomerRepository(IConfigurationRoot configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }

        public async Task<Customer> GetCustomerDetails(string teleBankNo)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Customer>(_commandText.GetTeleBankingDetails, new { TeleBankNo = teleBankNo });
                return query;
            });

        }

    }
}
