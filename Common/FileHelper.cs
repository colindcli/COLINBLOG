using System;
using System.IO;

public class FileHelper
{
    public static Action<object, Exception> AddLog { get; set; }

    /// <summary>
    /// 创建文件夹
    /// </summary>
    /// <param name="directoryName"></param>
    public static void CreateDirectory(string directoryName)
    {
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="fileNames"></param>
    /// <returns></returns>
    public static bool DeleteFile(params string[] fileNames)
    {
        var i = 0;
        foreach (var fileName in fileNames)
        {
            if (DeleteFile(fileName))
            {
                i++;
            }
        }
        return fileNames.Length == i;
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private static bool DeleteFile(string fileName)
    {
        if (!File.Exists(fileName)) return true;
        try
        {
            File.Delete(fileName);
        }
        catch (Exception ex)
        {
            AddLog(ex.Message, ex);
        }
        return !File.Exists(fileName);
    }

    /// <summary>
    /// 读文件
    /// </summary>
    /// <param name="fileName">文件地址</param>
    /// <returns></returns>
    public static byte[] ReadFile(string fileName)
    {
        var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        var bytes = new byte[fileStream.Length];
        fileStream.Read(bytes, 0, bytes.Length);
        fileStream.Close();
        fileStream.Dispose();
        return bytes;
    }

    /// <summary>
    /// 写文件
    /// </summary>
    /// <param name="fileName">文件地址</param>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool WriteFile(string fileName, string str)
    {
        var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Write);
        var sr = new StreamWriter(fileStream);
        sr.WriteLine(str);
        sr.Close();
        sr.Dispose();
        fileStream.Close();
        fileStream.Dispose();
        return File.Exists(fileName);
    }
}
