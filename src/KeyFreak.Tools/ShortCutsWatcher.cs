using KeyFreak.Tools;
using KeyFreak.WinApi;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyFreak.UI
{
	public class ShortCutsWatcher
	{
		#region private fields

		private static readonly HookProc Proc = HookCallback;
		private static IntPtr hookId = IntPtr.Zero;

		private static readonly KeyCombinationHelper KeyCombinationHelper = new KeyCombinationHelper();

		#endregion private fields

		public static object keyDownMutex = new object();
		public static event KeyEventHandler KeyDown
		{
			add
			{
				lock (keyDownMutex)
				{
					KeyCombinationHelper.KeyDown += value;
				}
			}
			remove
			{
				lock (keyDownMutex)
				{
					KeyCombinationHelper.KeyDown -= value;
				}
			}
		}

		public static object keyUpMutex = new object();
		public static event KeyEventHandler KeyUp
		{
			add
			{
				lock (keyUpMutex)
				{
					KeyCombinationHelper.KeyUp += value;
				}
			}
			remove
			{
				lock (keyUpMutex)
				{
					KeyCombinationHelper.KeyUp -= value;
				}
			}
		}

		public static bool StartWatch()
		{
			hookId = SetHook(Proc);
			return hookId != IntPtr.Zero;
		}

		public static bool StopWatch()
		{
			return User32.UnhookWindowsHookEx(hookId);
		}

		#region private methods

		private static IntPtr SetHook(HookProc proc)
		{
			using (Process curProcess = Process.GetCurrentProcess())
			using (ProcessModule curModule = curProcess.MainModule)
			{
				return User32.SetWindowsHookEx(WH.WH_KEYBOARD_LL, proc,
				Kernel32.GetModuleHandle(curModule.ModuleName), 0);
			}
		}

		private static bool OnKeyDown(IntPtr lParam)
		{
			return KeyCombinationHelper.SetKeyDown((Keys)Marshal.ReadInt32(lParam));
		}

		private static bool OnKeyUp(IntPtr lParam)
		{
			return KeyCombinationHelper.SetKeyUp((Keys)Marshal.ReadInt32(lParam));
		}

		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			bool handled = false;
			if (nCode >= 0)
			{
				if (((wParam == (IntPtr)WM.WM_KEYDOWN) || (wParam == (IntPtr)WM.WM_SYSKEYDOWN)))
				{
					handled = OnKeyDown(lParam);
				}

				if (((wParam == (IntPtr)WM.WM_KEYUP) || (wParam == (IntPtr)WM.WM_SYSKEYUP)))
				{
					handled = OnKeyUp(lParam);
				}
			}

			if (!handled)
				return User32.CallNextHookEx(hookId, nCode, wParam, lParam);

			return IntPtr.Zero;
		}

		#endregion private methods

	}
}
