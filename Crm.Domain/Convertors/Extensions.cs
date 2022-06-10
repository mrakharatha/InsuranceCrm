namespace Crm.Domain.Convertors
{
  public static class Extensions
    {
        public static string PersianToEnglish(this string persianStr)
        {
            Dictionary<char, char> lettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            };
            foreach (var item in persianStr)
            {
                if (lettersDictionary.Any(c=> c.Key==item))
                    persianStr = persianStr.Replace(item, lettersDictionary[item]);
            }
            return persianStr;
        }
    }
}
