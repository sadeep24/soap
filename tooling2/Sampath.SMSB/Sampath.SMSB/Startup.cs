using Common;
using Sampath.SMSB.Infrastructure.Repositories.Interfeaces;
using Sampath.SMSB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        public void Run()
        {
            while (true)
            {
                var message = "NB0013047869194";
                Console.Write("Message \n ");
                var val1 = Console.ReadLine();
                //var message = "NB0013047869194750744772  160820190927" + val1;
                Console.Write("Phone Number \n ");
                var val2 = Console.ReadLine();
                var date = DateTime.Now;
                string datetime = date.ToString("ddMMyyyyHHmm");
                message = message + val2 + "  " + datetime + val1;
                using (StreamWriter sw = File.AppendText("C:\\Users\\sadeep\\Desktop\\testdata\\data.txt"))
                {

                    sw.WriteLine(SMSEncryptor.Encrypt(message));
                }
            }
            // _inQueRepository.UpbateInqReq(val2, SMSEncryptor.Encrypt(message));
        }
            //NB001 304786 9194750744772  160820190927 message
            //DDMMYYYYHH24MISS
            //160820190927 add 00 in the end when puting it to tran table.

        }
    }

