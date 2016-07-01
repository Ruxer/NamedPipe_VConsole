using System;
using System.IO;
using System.IO.Pipes;

class PipeClient
{
    static void Main(string[] args){

        //创建客户端进程
        using(NamedPipeClientStream pipeClient = new NamedPipeClientStream(".","testpipe",PipeDirection.In))
        {
            //连接管道
            Console.Write("尝试连接管道>>>>");

            pipeClient.Connect();

            Console.WriteLine("连接管道成功");
            Console.WriteLine("当前正有{0}个管道打开"，pipeClient.NumberOfServerInstances);

            //读取管道发送过来的数据。
            using (StreamReader sr = new StreamReader(pipeClient)){

            	//将接受到的数据展示在命令行中。
            	string temp;

            	while ((temp = sr.ReadLine() ！= null)){

            		Console.WriteLine("接受到服务器的信息：{0}",temp);


            	}



            }




        }

        Console.Write("按任意键继续...");
        Console.ReadLine();

    }
}