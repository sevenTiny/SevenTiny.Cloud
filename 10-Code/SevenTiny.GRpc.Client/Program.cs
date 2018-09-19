using Grpc.Core;
using SevenTiny.GRpc.Protocol;
using SevenTiny.GRpc.Protocol.Model;
using System;

namespace SevenTiny.GRpc.Client
{
    class Program
    {
        private static Channel _channel;
        private static BusinessService.BusinessServiceClient _client;
        private static MsgService.MsgServiceClient _client2;

        static void Main(string[] args)
        {
            _channel = new Channel("127.0.0.1:40001", ChannelCredentials.Insecure);
            _client = new BusinessService.BusinessServiceClient(_channel);
            _client2 = new MsgService.MsgServiceClient(_channel);

            var rrr = _client2.GetSum(new GetMsgNumRequest
            {
                Num1 = 1,
                Num2 = 2
            });

            RequestArgs argg = new RequestArgs();
            argg.Arg1 = "7tiny";

            var result = _client.Test(argg);

            Console.WriteLine("grpc Client Call GetSum():" + result.Result);

            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}