using NiboChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace NiboChallenge.Helpers
{
    public class ConciliationHelper
    {
        public List<Transaction> Conciliation(string[] files)
        {
            DateFormatHelper dateformater = new DateFormatHelper();
            List<Transaction> list = new List<Transaction>();

            foreach (string file in files)
            {
                List<Transaction> newList = new List<Transaction>();

                string text = File.ReadAllText(file);

                MatchCollection transactions = Regex.Matches(text, @"<STMTTRN>(?s)(.+?)</STMTTRN>");

                foreach (var item in transactions)
                {
                    Transaction transaction = new Transaction();

                    transaction.Type = (Regex.Match(item.ToString(), @"<TRNTYPE>(?s)(.+?)<")).Groups[1].Value.Replace("\r\n", "");
                    transaction.Date = dateformater.FormatDate((Regex.Match(item.ToString(), @"<DTPOSTED>(?s)(.+?)<")).Groups[1].Value.Replace("\r\n", ""));
                    transaction.Value = Convert.ToDecimal((Regex.Match(item.ToString(), @"<TRNAMT>(?s)(.+?)<")).Groups[1].Value);
                    transaction.Memo = (Regex.Match(item.ToString(), @"<MEMO>(?s)(.+?)<")).Groups[1].Value.Replace("\r\n", ""); //Fix the final string from the regex

                    newList.Add(transaction);
                }

                var listAux = newList.Where(w => !list.Select(w1 => w1.Date).Contains(w.Date)).ToList();

                list.AddRange(listAux);
            }
            return list;
        }
    }
}
