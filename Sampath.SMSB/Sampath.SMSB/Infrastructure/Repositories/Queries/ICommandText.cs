using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Infrastructure.Repositories.Queries
{
    public interface ICommandText
    {
        string GetSMS { get; }
        string GetProducts { get; }
        string GetProductById { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }
        string GetProductByIdSp { get; }
    }
}
