using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Infrastructure.Repositories.Queries
{
    class CommandText:ICommandText
    {
        public string GetSMS => "SELECT i.*,to_char(sysdate,'YYYYMMDDHH24MISS') DATEOFDB from SMB_INQUE i where i.INQ_PROCESSED='N' and rownum<10 order by inq_date";
        public string GetProducts => "Select * from Product";
        public string GetProductById => "Select * from Product where Id= @Id";
        public string AddProduct => "Insert into  [Dapper].[dbo].[Product] ([Name], Cost, CreatedDate) values (@Name, @Cost, @CreatedDate)";
        public string UpdateProduct => "Update [Dapper].[dbo].[Product] set Name = @Name, Cost = @Cost, CreatedDate = GETDATE() where Id =@Id";
        public string RemoveProduct => "Delete from [Dapper].[dbo].[Product] where Id= @Id";
        public string GetProductByIdSp => "GetProductId";
    }
}
