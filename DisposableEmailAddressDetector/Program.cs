using System;
using DisposableEmailAddressDetector.Lib;

namespace DisposableEmailAddressDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo: get your API key here: http://www.nameapi.org/en/register/
            var apiKey = "test test";
            var result = new DisposableEmails().IsDisposableEmailAddress("DaDiDoo@mailinator.com", apiKey);
            if (result)
            {
                Console.WriteLine("YES! It's Disposable!");
            }
        }
    }
}