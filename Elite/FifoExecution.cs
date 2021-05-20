using System.Collections.Generic;
using System.Threading;

namespace Elite
{
    //https://msdn.microsoft.com/en-us/magazine/dd419664.aspx
    /*
     example :

     public static FifoExecution reportjob = new FifoExecution(); // language is changed for thread

     reportjob.QueueUserWorkItem(SensorReportEmailCallback, sensorsiteparam);

	 private static void SensorReportEmailCallback(Object threadContext)
	 {
		SensorReportEmailCallbackParam param = (SensorReportEmailCallbackParam)threadContext;
	 }
    */
    internal class WorkItem
  {
    public WaitCallback Callback;
    public object State;
    public ExecutionContext Context;

    private static ContextCallback _contextCallback = s =>
    {
      var item = (WorkItem)s;
      item.Callback(item.State);
    };

    public void Execute()
    {
      if (Context != null)
        ExecutionContext.Run(Context, _contextCallback, this);
      else Callback(State);
    }
  }

  public class FifoExecution
  {
    private Queue<WorkItem> _workItems = new Queue<WorkItem>();
    private bool _delegateQueuedOrRunning = false;

    public void QueueUserWorkItem(WaitCallback callback, object state)
    {
      var item = new WorkItem
      {
        Callback = callback,
        State = state,
        Context = ExecutionContext.Capture()
      };
      lock (_workItems)
      {
        _workItems.Enqueue(item);
        if (!_delegateQueuedOrRunning)
        {
          _delegateQueuedOrRunning = true;
          ThreadPool.UnsafeQueueUserWorkItem(ProcessQueuedItems, null);
        }
      }
    }

    /*
    private void ProcessQueuedItems(object ignored) {
      while (true) {
        WorkItem item;
        lock (_workItems) {
          if (_workItems.Count == 0) {
            _delegateQueuedOrRunning = false;
            break;
          }
          item = _workItems.Dequeue();
        }
        try { item.Execute(); }
        catch {
          ThreadPool.UnsafeQueueUserWorkItem(ProcessQueuedItems,
            null);
          throw;
        }
      }
    }
    */

    private void ProcessQueuedItems(object ignored)
    {
      WorkItem item;
      lock (_workItems)
      {
        if (_workItems.Count == 0)
        {
          _delegateQueuedOrRunning = false;
          return;
        }
        item = _workItems.Dequeue();
      }
      try { item.Execute(); }
      finally
      {
        ThreadPool.UnsafeQueueUserWorkItem(ProcessQueuedItems,
          null);
      }
    }
  }
}