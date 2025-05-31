using System;
using System.Management;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var trap = new SystemTrap())
            {
                trap.ProcessStarted += (s, e) =>
                    Console.WriteLine($"[Process Started] {e.ProcessName} (PID: {e.ProcessId})");
                trap.ProcessStopped += (s, e) =>
                    Console.WriteLine($"[Process Stopped] {e.ProcessName} (PID: {e.ProcessId})");
                trap.DeviceArrived += (s, e) =>
                    Console.WriteLine("[Device Arrived]");
                trap.DeviceRemoved += (s, e) =>
                    Console.WriteLine("[Device Removed]");

                Console.WriteLine("SystemTrap started. Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }

    public class SystemTrap : IDisposable
    {
        private ManagementEventWatcher procStartWatcher;
        private ManagementEventWatcher procStopWatcher;
        private ManagementEventWatcher devArrWatcher;
        private ManagementEventWatcher devRemWatcher;

        public event EventHandler<ProcessEventArgs> ProcessStarted;
        public event EventHandler<ProcessEventArgs> ProcessStopped;
        public event EventHandler<DeviceEventArgs> DeviceArrived;
        public event EventHandler<DeviceEventArgs> DeviceRemoved;

        public SystemTrap()
        {
            try
            {
                var procStartQuery = new WqlEventQuery("__InstanceCreationEvent", TimeSpan.FromSeconds(1),
                    "TargetInstance isa 'Win32_Process'");
                procStartWatcher = new ManagementEventWatcher(procStartQuery);
                procStartWatcher.EventArrived += ProcStart_EventArrived;
                procStartWatcher.Start();

                var procStopQuery = new WqlEventQuery("__InstanceDeletionEvent", TimeSpan.FromSeconds(1),
                    "TargetInstance isa 'Win32_Process'");
                procStopWatcher = new ManagementEventWatcher(procStopQuery);
                procStopWatcher.EventArrived += ProcStop_EventArrived;
                procStopWatcher.Start();

                var devArrQuery = new WqlEventQuery(
                    "SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
                devArrWatcher = new ManagementEventWatcher(devArrQuery);
                devArrWatcher.EventArrived += DevArr_EventArrived;
                devArrWatcher.Start();

                var devRemQuery = new WqlEventQuery(
                    "SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
                devRemWatcher = new ManagementEventWatcher(devRemQuery);
                devRemWatcher.EventArrived += DevRem_EventArrived;
                devRemWatcher.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing SystemTrap: " + ex.Message);
            }
        }

        private void ProcStart_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var inst = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            var name = (string)inst["Name"];
            var pid = (uint)inst["ProcessId"];
            ProcessStarted?.Invoke(this, new ProcessEventArgs(name, pid));
        }

        private void ProcStop_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var inst = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            var name = (string)inst["Name"];
            var pid = (uint)inst["ProcessId"];
            ProcessStopped?.Invoke(this, new ProcessEventArgs(name, pid));
        }

        private void DevArr_EventArrived(object sender, EventArrivedEventArgs e)
        {
            DeviceArrived?.Invoke(this, new DeviceEventArgs("Device connected"));
        }

        private void DevRem_EventArrived(object sender, EventArrivedEventArgs e)
        {
            DeviceRemoved?.Invoke(this, new DeviceEventArgs("Device disconnected"));
        }

        public void Dispose()
        {
            procStartWatcher?.Stop();
            procStartWatcher?.Dispose();
            procStopWatcher?.Stop();
            procStopWatcher?.Dispose();
            devArrWatcher?.Stop();
            devArrWatcher?.Dispose();
            devRemWatcher?.Stop();
            devRemWatcher?.Dispose();
        }
    }

    public class ProcessEventArgs : EventArgs
    {
        public string ProcessName { get; }
        public uint ProcessId { get; }
        public ProcessEventArgs(string name, uint pid)
        {
            ProcessName = name; ProcessId = pid;
        }
    }

    public class DeviceEventArgs : EventArgs
    {
        public string Message { get; }
        public DeviceEventArgs(string msg)
        {
            Message = msg;
        }
    }
}

