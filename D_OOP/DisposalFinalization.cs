using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace D_OOP.Homeworks
{
    public class ResourceHolder : IDisposable {
        private readonly IntPtr unmanagedResource;
        private readonly SafeHandle managedResource;

        public ResourceHolder() {
            unmanagedResource = Marshal.AllocHGlobal(sizeof (int));
            managedResource = new SafeFileHandle(new IntPtr(), true);
        }

        /// <summary>
        /// tempral coupling between calls
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isManualDisposing) {
            ReleaseUnmanagedResourse(unmanagedResource);
            if (isManualDisposing) {
                ReleaseManagedResources(managedResource);
            }
        }

        private void ReleaseManagedResources(SafeHandle safeHandle) {
            safeHandle?.Dispose();
        }

        private void ReleaseUnmanagedResourse(IntPtr intPtr) {
            Marshal.FreeHGlobal(intPtr);
        }

        ~ResourceHolder() {
            Dispose(false);
        }
    }
}