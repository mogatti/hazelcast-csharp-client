// Copyright (c) 2008-2020, Hazelcast, Inc. All Rights Reserved.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hazelcast.Client.Protocol;
using Hazelcast.Client.Spi;

namespace Hazelcast.Util
{
    internal static class ThreadUtil
    {
        public static IList<ClientMessage> GetResult(IEnumerable<IFuture<ClientMessage>> futures)
        {
            var tasks = futures.Select(future => future.ToTask()).ToArray();
            Task.WaitAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        public static ClientMessage GetResult(IFuture<ClientMessage> future)
        {
            return future.GetResult(Timeout.Infinite);
        }

        public static ClientMessage GetResult(IFuture<ClientMessage> future, int timeout)
        {
            return future.GetResult(timeout);
        }

        public static ClientMessage GetResult(IFuture<ClientMessage> future, TimeSpan timeout)
        {
            return future.GetResult((int) timeout.TotalMilliseconds);
        }

        public static ClientMessage GetResult(Task<ClientMessage> task)
        {
            return GetResult(task, Timeout.Infinite);
        }

        public static ClientMessage GetResult(Task<ClientMessage> task, int timeoutMillis)
        {
            try
            {
                var responseReady = task.Wait(timeoutMillis);
                if (!responseReady)
                {
                    throw new TimeoutException("Operation time-out! No response received from the server.");
                }
            }
            catch (AggregateException e)
            {
                throw ExceptionUtil.Rethrow(e);
            }
            return task.Result;
        }

        public static long GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}