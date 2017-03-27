using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SinoSZJS.Base.Misc
{
	/// <summary>
	/// Summary description for Win32API
	/// </summary>
	public class Win32API
	{
		//	BOOL Beep(DWORD dwFreq, DWORD dwDuration);
		[DllImport("Kernel32.dll", EntryPoint = "Beep")]
		public static extern int Beep(int freq, int duration);
		
		// UINT GetModuleFileName(HMODULE hModule, LPTSTR lpBuffer, UINT uSize)
		[ DllImport( "Kernel32.dll", CharSet=CharSet.Auto )]
		public static extern int GetModuleFileName(int hModule, StringBuilder sysDirBuffer, int size);

                [DllImport("shell32.dll")]
                public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

                [DllImport("user32.dll")]                
                public static extern int SetParent(int hWndChild, int hWndNewParent);

                [DllImport("user32.dll")]    
                public extern static int GetDoubleClickTime();
	}
}
