using System;
using System.IO;
using System.IO.Pipes;


class PipeServer
{
    static void Main(string[] args){

        //创建server实例
        using(NamedPipeServerStream pipeServer = new NamedPipeServerStream("testPipe",PipeDirection.Out))
        {
            
            Console.WriteLine("服务器创建成功！");

            //等待连接
            Console.WriteLine("等待连接客户端......");
            pipeServer.WaitForConnection();

            Console.WriteLine("客户端连接成功！");

            try
            {
                //获取数据并将数据发送到客户端进程
                using(StreamWrite sw = new StreamWrite(pipeServer))
                {
                    sw.AutoFlush = true;
                    Console.Write("请输入数据：");
                    sw.WriteLine(Console.ReadLine());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR:{0}",e.Message);
                //throw;
            }


        }


    }


}