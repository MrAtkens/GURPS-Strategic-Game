

namespace DefaultTemplate.Common.Extension
{
    public class ValidatorHelper
    {
        public static bool isNumeric(string val)
        {
            return int.TryParse(val, out int _);
        }
    }
}
