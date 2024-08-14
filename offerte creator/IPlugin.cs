using iTextSharp.text.log;
using System;

namespace offerte_creator
{
    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        void Execute();
        void Configure(Form_Main formMain);
        void LoadConfiguration(string configFilePath);
        void SaveConfiguration(string configFilePath);
        void SetLogger(ILogger logger);
        void RegisterServices(IServiceProvider serviceProvider);
        void Stop();
    }
}
