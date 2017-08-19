using System.Text;

namespace Lab06
{
    public class PhoneTranslator
    {
        string _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string _numbers = "22233344455566677778889999";

        public string ToNumber(string alfanumericPhoneNumber)
        {
            var numericPhoneNumber = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(alfanumericPhoneNumber))
            {
                alfanumericPhoneNumber = alfanumericPhoneNumber.ToUpper();

                foreach (var c in alfanumericPhoneNumber)
                {
                    if ("0123456789".IndexOf(c) >= 0)
                    {
                        numericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var index = _letters.IndexOf(c);

                        if (index >= 0)
                        {
                            numericPhoneNumber.Append(_numbers[index]);
                        }
                    }
                }
            }

            return numericPhoneNumber.ToString();
        }
    }
}