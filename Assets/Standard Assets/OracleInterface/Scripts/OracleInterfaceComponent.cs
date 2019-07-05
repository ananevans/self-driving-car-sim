using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;

namespace OracleInterface
{
    public class OracleInterfaceComponent : MonoBehaviour
    {
        private string filename;

        private Thread thread;

        // thread-safe queue
        private Queue messages;

        // Used to stop the thread
        private int stop;

        // used to wait on empty queue and wake up the thread when an object is 
        // added to the queue
        private ManualResetEvent threadWaitHandle;

        public OracleInterfaceComponent(String outputFile)
        {
            this.filename = outputFile;
            messages = Queue.Synchronized(new Queue());
            threadWaitHandle = new ManualResetEvent(false);
        }

        public void Awake()
        {
            Interlocked.Exchange(ref stop, 0);
            thread = new Thread(run);
        }

        public void OnDestroy()
        {
            Interlocked.Increment(ref stop);
            // awake thread waiting on empty queue
            threadWaitHandle.Set(); 
        }

        public void Add(CollisionMessage collisionMessage)
        {
            Add( new Message(Message.collision,
                    JsonUtility.ToJson(collisionMessage)));
        }

        public void Add(UpdateMessage updateMessage)
        {
            Add(new Message(Message.update,
                    JsonUtility.ToJson(updateMessage)));
        }

        public void Add(TerminationMessage terminationMessage)
        {
            Add(new Message(Message.termination,
                    JsonUtility.ToJson(terminationMessage)));
        }

        private void Add(Message msg)
        {
            messages.Enqueue(msg);
            threadWaitHandle.Set();
        }

        private void run()
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // while thread not stopped
                while (Interlocked.CompareExchange(ref stop, 0, 0) == 0 )
                {
                    // empty queue
                    while (messages.Count > 0)
                    {
                        // write messages in the file
                        Message msg = (Message)messages.Dequeue();
                        writer.WriteLine(JsonUtility.ToJson(msg));
                    }
                    if (Interlocked.CompareExchange(ref stop, 0, 0) == 0)
                    {
                        Debug.Log("Empty queue: Waiting");
                        threadWaitHandle.WaitOne();
                        threadWaitHandle.Reset();
                        Debug.Log("Empty queue: Woke Up");
                    }
                }
            }
        }
    }
}
