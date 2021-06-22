using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace USB_Authentication
{
    class USBDevice
    {
        public string DeviceId { get; set; }
        public string PnpDeviceId { get; set; }
        
        public USBDevice() { }
        public USBDevice(string deviceId, string pnpDeviceId)
        {
            DeviceId = deviceId;
            PnpDeviceId = pnpDeviceId;
        }

        public override string ToString()
        {
            return (DeviceId + PnpDeviceId).HashSHA512();
        }

        public static List<USBDevice> GetUSBDevices()
        {
            List<USBDevice> devices = new List<USBDevice>();

            ManagementObjectCollection collection;
            using (var winApiSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_USBHub"))
                collection = winApiSearcher.Get();

            foreach(var device in collection)
                devices.Add(new USBDevice(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID")
                    ));

            collection.Dispose();
            return devices;
        }
    }
}
