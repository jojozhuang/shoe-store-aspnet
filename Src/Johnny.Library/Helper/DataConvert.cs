using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Johnny.Library.Helper
{
    public class DataConvert
    {
        #region GetShortDateString(DateTime)
        public static string GetShortDateString(DateTime dtValue)
        {
            try
            {
                return dtValue.ToString("yyyy-MM-dd");
            }
            catch
            {
                return String.Empty;
            }
        }
        #endregion

        #region GetLongDateString(DateTime)
        public static string GetLongDateString(DateTime dtValue)
        {
            try
            {
                return dtValue.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return String.Empty;
            }
        }
        #endregion

        #region GetDigitLetter
        /// <summary>
        /// GetDigitLetter removes characters that are not number or letter from the input string.
        /// </summary>
        /// <param name="input">input string value. </param>
        /// <returns>a string value only contains numbers or letters (from 0 to 9 or a(A) to z(Z)). </returns>
        public static string GetDigitLetter(string input)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(input))
            {
                foreach (char c in input)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();
        }
        #endregion


        #region GetDateTime(object)
        /// <summary>
        /// 由object取日期时间(DateTime)
        /// </summary>
        /// <param name="oValue">指定的object值，一般是数据表的字段值</param>
        /// <returns>返回object的对应值</returns>
        public static DateTime GetDateTime(object oValue)
        {
            if (oValue == null || oValue == System.DBNull.Value)
                return DateTime.Now;
            return Convert.ToDateTime(oValue);
        }
        #endregion

        #region GetString(object)
        public static string GetString(object oValue)
        {
            if (oValue == null || oValue == System.DBNull.Value)
                return "";
            return oValue.ToString();
        }
        #endregion

        #region GetInt32(object)
        public static int GetInt32(object oValue)
        {
            if (oValue is Enum)
            {
                return Convert.ToInt32(oValue);
            }

            int result;
            if (Int32.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetInt64(object)
        public static long GetInt64(object oValue)
        {
            if (oValue is Enum)
            {
                return Convert.ToInt64(oValue);
            }

            long result;
            if (Int64.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetFloat(object)
        public static float GetFloat(object oValue)
        {
            float result;
            if (float.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetDouble(object)
        public static double GetDouble(object oValue)
        {
            double result;
            if (Double.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetDecimal(object)
        public static decimal GetDecimal(object oValue)
        {
            decimal result;
            if (Decimal.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetBool(object)
        public static bool GetBool(object oValue)
        {
            bool result;
            Boolean.TryParse(GetString(oValue), out result);
            return result;
        }
        #endregion

        //#region GetBool(object)
        //public static bool GetBool(int i)
        //{
        //    return (i == 1) ? true : false;
        //}
        //#endregion

        //#region GetEncodeData(string)
        //public static string GetEncodeData(string str)
        //{
        //    return HttpUtility.UrlEncode(str);
        //}
        //#endregion

        #region QuoteToDouble(string)
        public static string QuoteToDouble(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            return input.Replace("'", "''");
        }
        #endregion
    }

}
