## VPN搭建


> 服务端

1、安装nodejs

2、NPM安装shadowsocks：https://www.npmjs.com/package/shadowsocks
    命令：npm i shadowsocks -g  (这里有-g)

3、修改config：
C:\Users\Administrator\AppData\Roaming\npm\node_modules\shadowsocks\config.json

    {
        "server":"server ip",
        "server_port":8388,
        "local_address":"127.0.0.1",
        "local_port":1080,
        "password":"password",
        "timeout":600,
        "method":"aes-256-cfb"
    }

4、在目录：C:\Users\Administrator\AppData\Roaming\npm\node_modules\shadowsocks\ 运行cmd：ssserver启动

5、创建 server.bat

6、设置目录C:\Users\Administrator\AppData\Roaming\npm\node_modules\shadowsocks\写入权限。

7、server.bat 必须以管理员身份运行，否则可能会连接不上。



> 客户端

6、下载客户端：https://github.com/shadowsocks/shadowsocks-windows/releases

7、安卓手机端：https://github.com/shadowsocks/shadowsocks-android