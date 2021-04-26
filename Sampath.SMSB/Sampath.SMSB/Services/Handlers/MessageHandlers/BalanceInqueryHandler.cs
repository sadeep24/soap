using Sampath.SMSB.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sampath.SMSB.Services.Handlers.MessageHandlers
{
    public class BalanceInqueryHandler : Handler<InQue>
    {
        public override void Handle(InQue user)
        {
            //if (user.Age < 18)
            //{
            //    throw new UserValidationException("You have to be 18 years or older");
            //}

            base.Handle(user);
        }
    }
}
