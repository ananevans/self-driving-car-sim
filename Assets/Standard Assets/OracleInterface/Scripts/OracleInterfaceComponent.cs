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

        public void Awake()
        {
            this.filename = Environment.GetEnvironmentVariable("ORACLE_INTERFACE_FILE");
            if (this.filename == null)
            {
                Debug.Log("ORACLE_INTERFACE_FILE not set, using /home/nora/work/self-driving-car-sim/oracle-interface.json");
                this.filename = "/home/nora/work/self-driving-car-sim/oracle-interface.json";
            }

            messages = Queue.Synchronized(new Queue());
            threadWaitHandle = new ManualResetEvent(false);
            Interlocked.Exchange(ref stop, 0);
            thread = new Thread(run);
            thread.Start();
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

        public void Add(AccelerationMessage message)
        {
            Add(new Message(Message.acceleration,
                    JsonUtility.ToJson(message)));
        }


        public void Add(JerkMessage message)
        {
            Add(new Message(Message.jerk,
                    JsonUtility.ToJson(message)));
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
                        //Debug.Log("Empty queue: Waiting");
                        threadWaitHandle.WaitOne();
                        threadWaitHandle.Reset();
                        //Debug.Log("Empty queue: Woke Up");
                    }
                }
                // empty the queue just in case
                while (messages.Count > 0)
                {
                    // write messages in the file
                    Message msg = (Message)messages.Dequeue();
                    writer.WriteLine(JsonUtility.ToJson(msg));
                }
            }
        }
    }
}
