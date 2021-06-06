using Common;
using Newtonsoft.Json;
using Sampath.SMSB.Infrastructure.Models;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sampath.SMSB.ConsoleApp
{
    public class Startup
    {
        private readonly IInQueRepository _inQueRepository;
        public Startup(IInQueRepository inQueRepository)
        {
            _inQueRepository = inQueRepository;
        }

        // Application starting point
        public async Task Run()
        {
            while (true)
            {

                Console.Write("To Queue Messages press enter y\n");
                var choice = Console.ReadLine();
                if(choice.ToUpper()=="Y")
                using (StreamReader r = new StreamReader("C:\\Users\\sadeep\\Desktop\\SampathB\\SMSBankingTestENV\\file.json"))
                {
                    string json = r.ReadToEnd();
                    List<InQue> items = JsonConvert.DeserializeObject<List<InQue>>(json);
                    foreach (var item in items)
                    {
                        item.Inq_Inrec = gernerateMessage(item);
                        await _inQueRepository.InsertInqRecord(item);
                    }
                }
               

            }

        }
        //NB001 304786 9194750744772  160820190927 message
        //DDMMYYYYHH24MISS
        //160820190927 add 00 in the end when puting it to tran table.
        public string gernerateMessage(InQue inque)
        {
            var message = "NB0013047869194";
            var val1 = inque.Inq_Inrec;
            //var message = "NB0013047869194750744772  160820190927" + val1;
            var val2 = inque.Inq_Tel_Number;
            var date = DateTime.Now;
            string datetime = date.ToString("ddMMyyyyHHmm");
            message = message + val2 + "  " + datetime + val1;

           return SMSEncryptor.Encrypt(message);

        }

    }
}

