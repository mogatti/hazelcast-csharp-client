// Copyright (c) 2008, Hazelcast, Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Hazelcast.Client.Protocol.Util;
using Hazelcast.IO.Serialization;

namespace Hazelcast.Client.Protocol.Codec
{
    internal sealed class ListIndexOfCodec
    {
        public const int ResponseType = 102;
        public const bool Retryable = true;

        public static readonly ListMessageType RequestType = ListMessageType.ListIndexOf;

        public static ResponseParameters DecodeResponse(IClientMessage clientMessage)
        {
            var parameters = new ResponseParameters();
            int response;
            response = clientMessage.GetInt();
            parameters.response = response;
            return parameters;
        }

        public static ClientMessage EncodeRequest(string name, IData value)
        {
            var requiredDataSize = RequestParameters.CalculateDataSize(name, value);
            var clientMessage = ClientMessage.CreateForEncode(requiredDataSize);
            clientMessage.SetMessageType((int) RequestType);
            clientMessage.SetRetryable(Retryable);
            clientMessage.Set(name);
            clientMessage.Set(value);
            clientMessage.UpdateFrameLength();
            return clientMessage;
        }

        //************************ REQUEST *************************//

        public class RequestParameters
        {
            public static readonly ListMessageType TYPE = RequestType;
            public string name;
            public IData value;

            public static int CalculateDataSize(string name, IData value)
            {
                var dataSize = ClientMessage.HeaderSize;
                dataSize += ParameterUtil.CalculateDataSize(name);
                dataSize += ParameterUtil.CalculateDataSize(value);
                return dataSize;
            }
        }

        //************************ RESPONSE *************************//


        public class ResponseParameters
        {
            public int response;
        }
    }
}