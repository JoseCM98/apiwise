using apiwise.Enum;
using apiwise.Interface;
using System.Text;

namespace apiwise.Service
{
    public class ServicioLogger : ILoggerWise
    {
        public void LogError(string mensaje)
        {
            EscribirText(mensaje, TypeEnum.Error.ToString(), "Logs//Error");
        }

        public void LogInformation(string mensaje)
        {
            EscribirText(mensaje, TypeEnum.Infor.ToString(), "Logs//Info");
        }

        public void LogWarning(string mensaje)
        {
            EscribirText(mensaje, TypeEnum.Warng.ToString(), "Logs//Info");
        }
        public void LogHosted(string mensaje)
        {
            EscribirText(mensaje, TypeEnum.Warng.ToString(), "Logs//Hosted");
        }
        public void EscribirText(string msn, string tipo, string carpeta)
        {
            try
            {
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                string hora = DateTime.Now.ToString("HH:mm:ss");
                string filePath = $"Log {fecha}.log";
                string basePath = Environment.CurrentDirectory;
                string pathAgrabar = Path.Combine(basePath, carpeta, filePath);
                if (!File.Exists(pathAgrabar))
                {
                    var myFile = File.Create(pathAgrabar);
                    myFile.Close();
                }
                using FileStream fileStream = new(pathAgrabar, FileMode.Append);
                using StreamWriter log = new(fileStream, Encoding.UTF8);
                log.WriteLine($"[{fecha} {hora}] [{tipo}]: {msn}");
                log.Close();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message + ": " + (ex.InnerException != null ? ex.InnerException.Message : "");
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                string hora = DateTime.Now.ToString("HH:mm:ss");
                string filePath = $"Log {fecha}-Erro.log";
                string basePath = Environment.CurrentDirectory;
                string pathAgrabar = Path.Combine(basePath, carpeta, filePath);
                if (!File.Exists(pathAgrabar))
                {
                    var myFile = File.Create(pathAgrabar);
                    myFile.Close();
                }
                using FileStream fileStream = new(pathAgrabar, FileMode.Append);
                using StreamWriter log = new(fileStream, Encoding.UTF8);
                log.WriteLine($"[{fecha} {hora}] [{tipo}]: {mensaje}");
                log.Close();
            }
        }


    }
}
