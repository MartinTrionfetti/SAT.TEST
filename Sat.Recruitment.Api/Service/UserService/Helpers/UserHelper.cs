using System;

namespace Sat.Recruitment.Api.Service.UserService.Helpers
{
    public static class UserHelper
    {
        #region UserType validations
        public static decimal UserMoneyNormal(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                var gif = money * percentage;
                money += gif;
            }
            else if (money > 10)
            {
                var percentage = Convert.ToDecimal(0.8);
                var gif = money * percentage;
                money += gif;
            }

            return money;
        }

        public static decimal UserMoneyPremium(decimal money)
        {
            if (money > 100)
            {
                var gif = money * 2;
                money += gif;
            }

            return money;
        }

        public static decimal UserMoneySuperUser(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = money * percentage;
                money += gif;
            }

            return money;
        }
        #endregion
        public static string NormalizeEmail(string email)
        {
            var emailParts = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = emailParts[0].IndexOf("+", StringComparison.Ordinal);
            emailParts[0] = atIndex < 0 ? emailParts[0].Replace(".", "") : emailParts[0].Replace(".", "").Remove(atIndex);
            return string.Join("@", new string[] { emailParts[0], emailParts[1] });
        }
    }
}
