using System;
using System.Dynamic;

namespace TesteSoftplan.Domain.Models
{
    public class AppSettingsConfig
    {
        public Logging Logging { get; set; }
        public JurosSet JurosSet { get; set; }
        public JurosFixo JurosFixo { get; set; }
        public Api Api { get; set; }
        public Github Github { get; set; }
    }

    public class Github
    {
        public string UrlProjeto { get; set; }
    }

    public class Logging
    {
        public string ApplicationName { get; set; }
        public int Version { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public Microsoft Lifetime { get; set; }
    }

    public class Microsoft
    { 
        public Hosting Hosting { get; set; }
    }

    public class Hosting
    {
        public string Lifetime { get; set; }
    }

    public class JurosFixo
    {
        public double Taxa { get; set; }
    }

    public class JurosSet
    {
        public string Formula { get; set; }
        public string Tempo { get; set; }
        public double TempoCalc
        {
            get
            {
                switch(Tempo.Trim().ToLower())
                {
                    case "d":
                        return 1.0 / 30.0;
                    case "a":
                        return 12;
                    case "h":
                        return 1.0 / 30.0 / 24.0;
                    case "mi":
                        return 1.0 / 30.0 / 24.0 / 60.0;
                    case "s":
                        return 1.0 / 30.0 / 24.0 / 60.0 / 60.0;
                    default:
                        return 1;
                }
            }
        }
    }

    public class Api
    {
        public string EnderecoApiOne { get; set; }
        public string EndpointJuros { get; set; }
        public string FullPathJuros
        {
            get
            {
                return $"{EnderecoApiOne}/{EndpointJuros}";
            }
        }
    }
}
