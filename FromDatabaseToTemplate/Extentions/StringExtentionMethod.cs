using FromDatabaseToTemplate.Entities;
using System.Reflection;
using System.Text;

namespace FromDatabaseToTemplate.Extention.cs
{
    public static class StringExtentionMethod
    {
        public static string FillDataInHtmlTemplateForMultipleUsers(this string source, IEnumerable<User> usersList)
        {

            string dynamicStr = "<tr>\r\n    <td>{{Name}}</td>\r\n    <td>{{PolicyNumber}}</td>\r\n    <td>{{Age}}</td>\r\n    <td>{{Salary}}</td>\r\n    <td>{{Occupation}}</td>\r\n    <td>{{ProductCode}}</td>\r\n    <td>{{Tenure}}</td>\r\n    <td>{{PolicyExpiryDate}}</td>\r\n  </tr>";

            string subStr = "";

            foreach (var user in usersList)
            {

                subStr = subStr + dynamicStr;
                foreach (PropertyInfo detail in user.GetType().GetProperties())
                {
                    string fieldName = "{{" + detail.Name + "}}";
                    string value = detail.GetValue(user, null).ToString();
                    subStr = subStr.Replace(fieldName, value);
                }
            }

            source = source.Replace(dynamicStr, subStr);
            Console.WriteLine(source);
            return source;
        }


        public static string FillDataInHtmlTemplateForOneUser(this string source, User user)
        {

            string dynamicStr = "<tr>\r\n    <td>{{Name}}</td>\r\n    <td>{{PolicyNumber}}</td>\r\n    <td>{{Age}}</td>\r\n    <td>{{Salary}}</td>\r\n    <td>{{Occupation}}</td>\r\n    <td>{{ProductCode}}</td>\r\n    <td>{{Tenure}}</td>\r\n    <td>{{PolicyExpiryDate}}</td>\r\n  </tr>";

            string subStr = "";
            subStr = subStr + dynamicStr;
            foreach (PropertyInfo detail in user.GetType().GetProperties())
            {
                string fieldName = "{{" + detail.Name + "}}";
                string value = detail.GetValue(user, null).ToString();
                subStr = subStr.Replace(fieldName, value);
            }

            

            source = source.Replace(dynamicStr, subStr);
            Console.WriteLine(source);
            return source;
        }
    }
}
