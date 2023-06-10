using Newtonsoft.Json.Linq;
using NIPSearchWebApi.Contracts;
using System.Text.RegularExpressions;

namespace NIPSearchWebApi.Utils
{
    public static class NIPUtils
    {
        public static bool CheckNIPFormat(this string input)
        {
            if (!Regex.IsMatch(input, "^[0-9]+$", RegexOptions.Compiled)) return false;

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (input.Length == 10)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[^1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }

        public static async Task<EnterpreneurRequestContract> ParseEnterpreneurFromHttpContentAsync(HttpContent content)
        {
            var data = await content.ReadAsStringAsync();
            var enterpreneur = new EnterpreneurRequestContract();

            if (data != null)
            {
                var obj = JObject.Parse(data)["result"]?["subject"];
                enterpreneur = obj?.ToObject<EnterpreneurRequestContract>();
            }

            return enterpreneur!;
        }
    }
}