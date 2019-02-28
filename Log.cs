using System;
using System.IO;
using System.Reflection;

public class LogAMG
{
    private string m_exePath = string.Empty;
    public LogAMG(string logMessage)
    {
        LogWrite(logMessage);
    }
    public void LogWrite(string logMessage)
    {
        m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        try
        {
            using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
            {
                Log(logMessage, w);
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.Write("\r\nAtualizador ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            txtWriter.WriteLine(" Mensagem :{0}", logMessage);
            txtWriter.WriteLine("----------------------------------------------------------------------------------------");
        }
        catch (Exception ex)
        {
        }
    }
}