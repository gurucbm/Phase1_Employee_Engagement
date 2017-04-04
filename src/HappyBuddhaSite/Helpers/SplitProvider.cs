using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MultivariateTesting.Providers
{
    internal class SplitDataProvider
    {
        private const string SPLIT_DATA_CHANNEL_CACHE_KEY = "SPLIT_DATA_CHANNEL_{0}_{1}";

        public static SplitData GetAllSplitData(int channelid, string applicationid)
        {
            var cache = MCache.Cache(); //custom cache
            var splitData = cache.GetData(string.Format(SPLIT_DATA_CHANNEL_CACHE_KEY, channelid, applicationid)) as SplitData;
            if (splitData != null) return splitData;
            
            try
            {
                var messageId = DBContext.GetMessageId(); //726543
                var jsonStr = DBContext.GetMessage(channelid, messageId);
                splitData = JsonConvert.DeserializeObject<SplitData>(jsonStr);
            }
            catch (Exception ex)
            {
                splitData = new SplitData() { Splits = new List<Split>()};
                Diagnostics.EventLog.Standards.Publish(ex);
            }

            cache.AddOrUpdate(string.Format(SPLIT_DATA_CHANNEL_CACHE_KEY, channelid, applicationid), splitData);

            return splitData;
        }
    }

    public class SplitData
    {
        public List<Split> Splits { get; set; }
    }

    public class Split
    {
        public string Name { get; set; }
        public int CookieVersion { get; set; }
        public string CookieName { get; set; }
        public string[] OverrideParams { get; set; }
        public bool IsEnabled { get; set; }

        public bool IsSiteCatalystable { get; set; }
        public List<Experience> Experiences { get; set; }
        
        /// <summary>
        /// This method has to be used in apps only to check additonal parameters.
        /// </summary>
        /// <param name="isMobile">whether the device is mobile</param>
        /// <param name="isDynamic">whether its a static page or dynamic page</param>
        /// <returns></returns>
        public bool IsSplitEnabled(bool isMobile, bool isDynamic)
        {
            return IsEnabled;
        }
    }

    public class Experience
    {
        public string Name { get; set; }
        public int Ratio { get; set; }
        public string SiteCatEvent { get; set; }
        public string SiteCatEvar { get; set; }
    }
}
