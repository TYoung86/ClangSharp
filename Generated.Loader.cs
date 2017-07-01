using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ClangSharp {
	internal static class kernel32 {
		[DllImport("kernel32", SetLastError=true, CharSet = CharSet.Ansi)]
		internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);
	}

	partial class clang {
		static clang() {
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;
			var asmDir = Path.GetDirectoryName(new Uri(typeof(clang).GetTypeInfo().Assembly.CodeBase).LocalPath);
			var libDir = Path.Combine(asmDir, "lib", IntPtr.Size == 8 ? "x64" : "x86");
			kernel32.LoadLibrary(Path.Combine(libDir, "libclang.dll"));
			/*
			kernel32.LoadLibrary(Path.Combine(libDir, "libiomp5md.dll"));
			kernel32.LoadLibrary(Path.Combine(libDir, "libomp.dll"));
			kernel32.LoadLibrary(Path.Combine(libDir, "LTO.dll"));
			*/
		}
	}
}