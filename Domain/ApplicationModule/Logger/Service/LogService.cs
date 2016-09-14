using System;

namespace Domain.ApplicationModule.Logger
{
    public static class LogService
    {
        public static LogItem LogFactory(string melding, string loginNaam)
        {
            return new LogItem(melding, loginNaam);
        }

        public static void LogEnSchrijf(ILogItemRepository repos, string melding, string loginNaam)
        {
            repos.AddNew(LogFactory(melding, loginNaam));
        }
    }
}
