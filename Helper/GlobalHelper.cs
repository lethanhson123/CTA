namespace Helper
{
    public class GlobalHelper
    {
        #region Initialization
        public static bool InitializationBool
        {
            get
            {
                return true;
            }
        }
        public static string InitializationString
        {
            get
            {
                return string.Empty;
            }
        }
        public static DateTime InitializationDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        public static DateTime DateTimeBegin
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            }
        }
        public static DateTime DateTimeEnd
        {
            get
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }
        }
        public static string InitializationGUICode
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        public static string InitializationDateTimeCode
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + DateTime.Now.Ticks.ToString();
            }
        }
        public static string InitializationDateTimeCode0001
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }
        public static int InitializationNumber
        {
            get
            {
                return 0;
            }
        }
        public static int InitializationSortOrder
        {
            get
            {
                return -1;
            }
        }
        #endregion
        #region AppSettings        
        public static string SQLServerConectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return builder.Build().GetSection("AppSettings").GetSection("SQLServerConectionString").Value;
            }
        }
        #endregion       
        #region Functions
       
        #endregion
    }
}
