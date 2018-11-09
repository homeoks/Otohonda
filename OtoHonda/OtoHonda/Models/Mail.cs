using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OtoHonda.Models
{
    public class MailGrid
    {

        public void Main(string emailAddress, string apiKey, LaiThuModel model)
        {
            Execute(emailAddress, apiKey, model).Wait();
        }

        static async Task Execute(string emailAddress, string apiKey, LaiThuModel model)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailAddress, "Bitwin team");
            var subject = "Thong tin khach hang";
            var plainTextContent = "Bitwin";
            var htmlContent =$"Dong xe:{model.DongXe}, Ho ten:{model.HoTen},Email:{emailAddress}, Dien thoai:{model.DienThoai},Dia chi: {model.DiaChi}";
           
                try
                {
                    var to = new EmailAddress("homeoks@gmail.com", "homeoks@gmail.com");
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    var response = await client.SendEmailAsync(msg);
                    Logger.Log(htmlContent, "SendGrid");
                }
                catch (Exception e)
                {
                    Logger.Log(e, "SendGrid");
                }

            }
       

        
    }

    public static class Logger
    {
        public static void Log(string msg, string fileName)
        {
            try
            {
                var path = $@"{Directory.GetCurrentDirectory()}/{fileName}.txt";
                if (File.Exists(path) == false)
                {
                    var fs = File.Create(path);
                    fs.Close();
                }

                System.Console.WriteLine(msg);
                using (var file = File.AppendText(path))
                {
                    file.WriteLine(":--:" + DateTimeOffset.Now + ":--:" + msg);
                    System.Console.WriteLine(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Log(Exception ex, string fileName)
        {
            Log(
                $"-Log {DateTimeOffset.Now}: {ex.Message}.StackTrace: {ex.StackTrace}. InnerExceptionMessage: {ex.InnerException?.Message}.", "Exception" + fileName);
        }
    }
    public class LaiThuModel
    {
        public string DongXe { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi{ get; set; }
    }
}
