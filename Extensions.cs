﻿using System;
using System.Text;

namespace ClangSharp
{
    public partial struct CXString
    {
        public override string ToString()
        {
            string retval = clang.getCString(this);
            //clang.disposeString(this);
            return retval;
        }
    }

    public partial struct CXType
    {
        public override string ToString()
        {
            return clang.getTypeSpelling(this).ToString();
        }
    }

    public partial struct CXCursor
    {
        public override string ToString()
        {
            var str = clang.getCursorSpelling(this);
			return str.ToString();
        }
    }

    public partial struct CXDiagnostic
    {
        public override string ToString()
        {
            return clang.getDiagnosticSpelling(this).ToString();
        }
    }
}