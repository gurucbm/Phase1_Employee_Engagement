using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MultivariateTesting.Helpers
{
    public static class SplitHelper {

        private const string SPLIT_HELPER_CACHE_KEY = "Split_Helper_Component_{0}";

        private static Dictionary<string, Random> _randomizers;
        private static Dictionary<string, Random> Randomizers
        {
            get
            {
                if(_randomizers != null)
                    return _randomizers;

                var channelconfigval = true; // Get from Database bool DBContext.Get(connection, query);

                if (channelconfigval)
                {
                    var cache = MCache.Cache(); //custom cache which inhertits from cache
                    _randomizers = cache.GetData(string.Format(SPLIT_HELPER_CACHE_KEY, ApplicationID)) as Dictionary<string, Random>;
                    if (_randomizers == null)
                    {
                        _randomizers = new Dictionary<string, Random>();
                        cache.AddOrUpdate(string.Format(SPLIT_HELPER_CACHE_KEY, ApplicationID), _randomizers);
                    }
                }
                else
                {
                    _randomizers = new Dictionary<string, Random>();
                }

                return _randomizers;
            }
        }

        private static Random GetRandomizer(string splitName)
        {
            var key = string.Format("{0}_{1}_{2}", ChannelID, ApplicationID, splitName);

            Random randomizer;
            if (!Randomizers.TryGetValue(key, out randomizer))
            {
                randomizer = new Random();
                Randomizers.Add(key, randomizer);
            }            
            return randomizer;  
        }

        public static List<Split> GetSplits()
        {
            var splitData = SplitDataProvider.GetAllSplitData(ChannelID, ApplicationID);
            return splitData.Splits;
        }

        public static Split GetSplit(string splitName)
        {
            var split = GetSplits().FirstOrDefault(a => a.Name == splitName);
            return split;
        }

        public static Experience GetExperience(string splitName)
        {
            var split = GetSplit(splitName);
            return GetExperience(split);
        }

        public static Experience GetExperience(Split split)
        {
            var queryNvc = HttpContext.Current.Request.QueryString;
            var splitGroup = 1;
            int? splitMode = SplitModeOverride(queryNvc, split.OverrideParams);
            if (splitMode != null)
            {
                if (splitGroup <= split.Experiences.Count()) // splitMode is ignored if the number beyond the total of split experiences
                {
                    splitGroup = splitMode.Value;
                    CreateCookie(split.CookieName, split.CookieVersion, splitMode.Value);
                    return split.Experiences.ElementAtOrDefault(splitGroup - 1);
                }
            }

            var cookie = HttpContext.Current.Request.Cookies[split.CookieName];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value) && cookie.Value.Contains("|"))
            {
                var csplit = cookie.Value.Split('|');
                if (csplit.Length == 2)
                {
                    int cversion = int.TryParse(csplit[0], out cversion) ? cversion : 0;

                    if (cversion == split.CookieVersion && int.TryParse(csplit[1], out splitGroup))
                    {
                        if (splitGroup <= split.Experiences.Count()) // splitMode is ignored if the number beyond the total of split experiences
                        {
                            return split.Experiences.ElementAtOrDefault(splitGroup - 1);
                        }
                    }
                }
            }

            var splitRatio = new int[split.Experiences.Count()];
            for (int i = 0; i < split.Experiences.Count(); i++)
            {
                splitRatio[i] = split.Experiences.ElementAt(i).Ratio;
            }

            splitGroup = AmILucky(splitRatio, split.Name);
            CreateCookie(split.CookieName, split.CookieVersion, splitGroup);
            return split.Experiences.ElementAtOrDefault(splitGroup - 1);
        }

        private static void CreateCookie(string cookieName, int cookieVersion, int cookieValue)
        {
            string cvalue = cookieVersion + "|" + cookieValue;
            var cookie = new HttpCookie(cookieName, cvalue);
            cookie.Domain = DomainHelper.GetDomainValue(ChannelID, ApplicationID);
            cookie.Expires = DateTime.Now.AddDays(30);
            cookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private static int? SplitModeOverride(NameValueCollection queryNvc, string[] splitModes)
        {
            if (!queryNvc.HasKeys())
            {
                return null;
            }

            string splitEnforcer = string.Empty;
            foreach (var splitMode in splitModes)
            {
                splitEnforcer = queryNvc.Get(splitMode);
                if (!string.IsNullOrEmpty(splitEnforcer))
                {
                    break; // break out of loop when the first param (splitmode) has value
                }
            }
            if (string.IsNullOrEmpty(splitEnforcer))
            {
                return null;
            }

            int enforcerValue;
            if (!int.TryParse(splitEnforcer, out enforcerValue))
            {
                return null;
            }

            if (enforcerValue > 0)
            {
                return enforcerValue;
            }
            else
            {
                return null;
            }
        }

        private static int AmILucky(int[] ratio, string splitName)
        {
            var total = 0;

            for (var i = 0; i < ratio.Count(); i++)
            {
                total += ratio.ElementAt(i);
            }

            var randomizer = GetRandomizer(splitName);
            var luckyNumber = randomizer.Next(1, total + 1);
            var currentRatioMax = 0;
            for (var i = 0; i < ratio.Count(); i++)
            {
                currentRatioMax += ratio[i];
                if (luckyNumber <= currentRatioMax)
                {
                    return i + 1;
                }
            }
            return 1;
        }
    }
}
