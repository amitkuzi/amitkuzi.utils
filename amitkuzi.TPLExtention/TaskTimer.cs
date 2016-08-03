using System;
using System.Threading;
using System.Threading.Tasks;

namespace amitkuzi.TPLExtention
{
    public class TaskTimer
    {
        public static   CancellationTokenSource Run(Action action, double repeatWait , double? firstWait = null, double? timeout = null , Action<Task> onFinish = null)
        {
            return   TaskTimer.Run(action, (TimeSpan)TimeSpan.FromMilliseconds(repeatWait),
                firstWait.HasValue ? TimeSpan.FromMilliseconds(firstWait.Value) : (TimeSpan?) null,
                timeout.HasValue ? TimeSpan.FromMilliseconds(timeout.Value) : (TimeSpan?) null, onFinish);

            
        }


        public static CancellationTokenSource Run(Action action, TimeSpan  repeatWait  , TimeSpan? firstWait = null, TimeSpan? timeout = null, Action<Task> onFinish = null)
        {
          


            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeout ?? TimeSpan.Zero);
            Task task = null;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            task = Task.Run(async  () => {
                                             try
                                             {
                                                 if (firstWait.HasValue)
                                                 {
                                                     await
                                                         Task.Delay(firstWait ?? TimeSpan.FromTicks(1),
                                                             cancellationTokenSource.Token);
                                                 }

                                                 while (!cancellationTokenSource.IsCancellationRequested)
                                                 {
                                                     await Task.Run(action, cancellationTokenSource.Token);
                                                     await Task.Delay(repeatWait, cancellationTokenSource.Token);
                                                 }
                                             }
                                             finally
                                             {
                                                 onFinish?.Invoke(task);
                                             }



            }, cancellationTokenSource.Token);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            return cancellationTokenSource;
        }
    }
}