using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace PMMS.Forms.Utils
{
    static class I18NUtils
    {

        public static IEnumerable<SelectListItem> SelectList(Type enumType)
        {

            //IList<SelectListItem> result = new List<SelectListItem>();

            //string enumResourceKey = GetI18NBaseResourceKey(enumType, conflictPrefix);

            //ResourceManager manager = MvcEnvironment.EnumResourceManager;

            //foreach (Object obj in System.Enum.GetValues(enumType))
            //{
            //    var intValue = (int)obj;


            //    if (excludes != null && excludes.Any(exc => (int)exc == intValue))
            //    {
            //        continue;
            //    }

            //    string resourceStr = manager.GetString(enumResourceKey + obj);
            //    string text = String.IsNullOrEmpty(resourceStr)
            //                      ?
            //                          obj.ToString()
            //                      : resourceStr;

            //    bool selected = false;
            //    string value = (intValue).ToString();

            //    result.Add(new SelectListItem
            //    {
            //        Text = text,
            //        Value = value,
            //    });
            //}

            //return result;
            return null;
        }

        public static string Text(System.Enum em)
        {
            return Text(em, null);
        }

        public static string Text(System.Enum em, string conflictPrefix)
        {
            string baseKey = GetI18NBaseResourceKey(em.GetType(), conflictPrefix);

            ResourceManager manager = EnumResource.ResourceManager;

            string enumStr = em.ToString();
            string resourceStr = manager.GetString(baseKey + enumStr);

            return String.IsNullOrEmpty(resourceStr) ? enumStr : resourceStr;
        }

        public static string GetI18NBaseResourceKey(Type enumType, string conflictPrefix)
        {
            bool cpIsNullOrEmpty = String.IsNullOrEmpty(conflictPrefix);

            if (cpIsNullOrEmpty)
            {
                conflictPrefix = "";
            }

            return //"Enum_" +
                   (!String.IsNullOrEmpty(conflictPrefix) ? conflictPrefix + "_" : "") +
                   enumType.Name + "_";
        }
    }
}
