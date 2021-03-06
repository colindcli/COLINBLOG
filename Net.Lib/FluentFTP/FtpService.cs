using FluentFTP;
using System.Collections.Generic;
using System.Linq;
using Ourtm.Common;
using Ourtm.Entity.Models;

namespace Ourtm.Service
{
    public class FtpService
    {
        private static FtpClient GetClient()
        {
            var server = Config.FtpServer();
            var client = new FtpClient(server.Ip, server.Port, server.User, server.Pwd);
            if (Config.FtpServerMode)
            {
                //主动模式
                client.DataConnectionType = FtpDataConnectionType.AutoActive;
            }
            return client;
        }

        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="localPath"></param>
        /// <param name="remotePath"></param>
        /// <returns></returns>
        public static int UploadFile(string localPath, string remotePath)
        {
            return UploadFiles(new List<FtpFileModel>()
            {
                new FtpFileModel()
                {
                    LocalPath = localPath,
                    RemotePath = remotePath
                }
            });
        }

        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static int UploadFiles(List<FtpFileModel> lists)
        {
            var client = GetClient();
            client.Connect();
            var rowcount = lists.Count(file => client.UploadFile(file.LocalPath, file.RemotePath, FtpExists.Overwrite, true));
            client.Disconnect();
            return rowcount;
        }
    }
}
