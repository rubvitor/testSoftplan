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
        /// <summary>
        /// O padrão do tempo é sempre em mês. Mas caso seja necessário a variável de tempo pode ser modificada
        /// para ano, dia, hora, minuto ou segundo sem necessidade de alterar o código (apenas no appsettings.json)
        /// Dependendo do tipo de configuração existe um fator de ajuste que multiplica o tipo de tempo escolhido para
        /// sempre adaptar para o padrão que é em mês. Caso não seja informada a variável ou esteja com "m"
        /// o fator de multiplicação será 1 e não modifica o resultado.
        /// </summary>
        public double TempoCalc
        {
            get
            {
                if (string.IsNullOrEmpty(Tempo))
                    return 1;

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
