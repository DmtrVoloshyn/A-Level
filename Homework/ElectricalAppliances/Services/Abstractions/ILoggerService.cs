using ElectricalAppliances.Enums;

namespace ElectricalAppliances.Services
{
    public interface ILoggerService
    {
        void Log(LogType logType, string massage);
    }
}

