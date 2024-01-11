using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using TgApp.Model;

namespace TgApp.Util
{
    public class ResUtil
    {
        private static List<ResModel> _rList = new List<ResModel>();
        //private static CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
        private static CultureInfo _cultureInfo = CultureInfo.CreateSpecificCulture("en");
        public static ResourceManager Resource = new ResourceManager("TgApp.Resource.Res", typeof(FrmMain).Assembly);


        static ResUtil()
        {
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        ///   MissingManifestResourceException
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetName(string key)
        {
            return Resource.GetString(key, _cultureInfo);
        }

        public static List<ResModel> GetList()
        {

            _rList = _rList.Any() ? _rList : Resource
                .GetResourceSet(_cultureInfo, true, true)
                .Cast<DictionaryEntry>()
                .Where(x => x.Value is string)
                .Select(x => new ResModel { Key = x.Key.ToString(), Name = x.Value.ToString() })
                .ToList();
            return _rList;
        }

        public static void SwitchLanguage(string lang = default)
        {
            if (string.Compare(_cultureInfo.Name, lang, StringComparison.OrdinalIgnoreCase) == 0) return;
            _cultureInfo = string.IsNullOrEmpty(lang) ? CultureInfo.CurrentCulture : CultureInfo.CreateSpecificCulture(lang);
            CultureInfo.CurrentUICulture = _cultureInfo;

        }
    }
}
