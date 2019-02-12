'Author: Arman Ghazanchyan
'Created date: 11/02/2006
'Last updated: 08/05/2008

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Runtime.InteropServices

''' <summary>
''' Provides shared methods for capturing images from the screen.
''' </summary>
<CLSCompliant(True)> _
Public NotInheritable Class SCapture

#Region " Methods "

    <DebuggerHidden()> _
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Captures the bitmap of the entire screen (all monitors).
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Shared Function FullScreen(ByVal includeCursor As Boolean) As Bitmap
        'Capture and return the full screen (all monitors) rectangle image.
        Return SCapture.ScreenRectangle(SystemInformation.VirtualScreen, includeCursor)
    End Function

    ''' <summary>
    ''' Captures the bitmap of the specified display device.
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="monitor">A diplay device.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Shared Function DisplayMonitor(ByVal monitor As System.Windows.Forms.Screen, ByVal includeCursor As Boolean) As Bitmap
        If monitor IsNot Nothing Then
            'Capture and return the display monitor rectangle bitmap.
            Return SCapture.ScreenRectangle(monitor.Bounds, includeCursor)
        Else
            'The screen object is nothing, throw an SCaptureException.
            Throw New SCaptureException("The monitor cannot be Null (Nothing in VB).")
        End If
    End Function

    ''' <summary>
    ''' Captures the bitmap of an active window from the screen. Returns 
    ''' a bitmap if the function succeeds, otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Shared Function ActiveWindow(ByVal includeCursor As Boolean) As Bitmap
        Dim hwnd As IntPtr
        'Get the handle of the active window on the desktop.
        hwnd = NativeMethods.GetForegroundWindow()
        If hwnd <> IntPtr.Zero Then
            'Capture and return the active window bitmap.
            Return SCapture.Control(hwnd, includeCursor)
        Else
            'The active window could not be found, throw an SCaptureException.
            Throw New SCaptureException("Could not find any active window.")
        End If
    End Function

    ''' <summary>
    ''' Captures the bitmap of a window from the screen. 
    ''' Returns a bitmap if the function succeeds, otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="p">A point within the window in the screen coordinates.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Window(ByVal p As Point, ByVal includeCursor As Boolean) As Bitmap
        'Get the handle of a window at the point.
        Dim hwnd As IntPtr = NativeMethods.WindowFromPoint(p)
        If hwnd <> IntPtr.Zero Then
            'Get the ancestor window of this window.
            Dim hpwnd As IntPtr = NativeMethods.GetAncestor(hwnd, NativeMethods.GA_ROOTOWNER)
            If hpwnd <> IntPtr.Zero Then
                'Capture and return the window bitmap.
                Return SCapture.Control(hpwnd, includeCursor)
            Else
                'There is no ancestor window or the window is the ancestor.
                'So return the existing window bitmap.
                Return SCapture.Control(hwnd, includeCursor)
            End If
        Else
            'There is no window at the specified point, throw an SCaptureException.
            Throw New SCaptureException("Could not find any window at the specified point.")
        End If
    End Function

    ''' <summary>
    ''' Captures the bitmap of a window from the screen specified by a handle. 
    ''' Returns a bitmap if the function succeeds, otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="hwnd">The handle to a window whose 
    ''' bitmap should be captured.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Window(ByVal hwnd As IntPtr, ByVal includeCursor As Boolean) As Bitmap
        If hwnd <> IntPtr.Zero Then
            'Capture and return the window bitmap.
            Return SCapture.Control(hwnd, includeCursor)
        Else
            'The window handle is invalid, throw an SCaptureException.
            Throw New SCaptureException("Invalid window handle.")
        End If
    End Function

    ''' <summary>
    ''' Captures the bitmap of a control. 
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="p">A point within the control in the screen coordinates.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Control(ByVal p As Point, ByVal includeCursor As Boolean) As Bitmap
        Dim hwnd As IntPtr
        'Get the handle of a window at the point.
        hwnd = NativeMethods.WindowFromPoint(p)
        If hwnd <> IntPtr.Zero Then
            'Capture and return the control bitmap.
            Return SCapture.Control(hwnd, includeCursor)
        Else
            'There is no window/control at the specified point, throw an SCaptureException.
            Throw New SCaptureException("Could not find any control at the specified point.")
        End If
    End Function

    ''' <summary>
    ''' Captures the bitmap of a control.
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="hwnd">The handle of a control whose 
    ''' bitmap should be captured.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function Control(ByVal hwnd As IntPtr, ByVal includeCursor As Boolean) As Bitmap
        Dim wRect As SCapture.Rect
        If hwnd <> IntPtr.Zero Then
            'Get the window rectangle.
            If Not NativeMethods.GetWindowRect(hwnd, wRect) Then
                Dim eCode As Integer = Marshal.GetLastWin32Error
                'The GetWindowRect Api method failed, throw an SCaptureException.
                Throw New SCaptureException(New Win32Exception(eCode).Message)
            Else
                'Capture and return the control rectangle bitmap.
                Return SCapture.ScreenRectangle(wRect.ToRectangle, includeCursor)
            End If
        Else
            'The control handle is invalid, throw an SCaptureException.
            Throw New SCaptureException("Invalid control handle.")
        End If
    End Function

    ''' <summary>
    ''' Captures the rectangle bitmap from the screen. 
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="rect">A rectangle within the screen 
    ''' coordinates whose bitmap should be captured.</param>
    ''' <param name="includeCursor">A value that specifies if the 
    ''' cursor should be included in the captured bitmap.</param>
    <DebuggerHidden()> _
    Public Shared Function ScreenRectangle(ByVal rect As Rectangle, ByVal includeCursor As Boolean) As Bitmap
        If Not rect.IsEmpty AndAlso rect.Width <> 0 AndAlso rect.Height <> 0 Then
            Dim bmp As Bitmap = SCapture.GetImage(rect)
            If includeCursor Then
                'Draw the cursor over the captured bitmap.
                SCapture.DrawCursor(rect, bmp)
            End If
            Return bmp
        Else
            'The rectangle is empty, throw an SCaptureException.
            Throw New SCaptureException("Empty rectangle.")
        End If
    End Function

    ''' <summary>
    ''' Gets the bitmap of a screen rectangle area.
    ''' Returns a bitmap if the function succeeds, 
    ''' otherwise throws a SCaptureException.
    ''' </summary>
    ''' <param name="rect">A rectangle within the screen 
    ''' coordinates whose bitmap should be captured.</param>
    <DebuggerHidden()> _
    Private Shared Function GetImage(ByVal rect As Rectangle) As Bitmap
        Dim wHdc As IntPtr = SCapture.GetDC
        'Create graphics object from bitmap.
        Dim g As Graphics
        Dim bmp As New Bitmap(rect.Width, rect.Height)
        g = Graphics.FromImage(bmp)
        'Get the handle of the bitmap graphics object.
        Dim gHdc As IntPtr = g.GetHdc()
        'Copy the screen rectangle to the bitmap.
        If Not NativeMethods.BitBlt(gHdc, 0, 0, rect.Width, rect.Height, _
        wHdc, rect.X, rect.Y, NativeMethods.SRCCOPY Or NativeMethods.CAPTUREBLT) Then
            Dim eCode As Integer = Marshal.GetLastWin32Error
            g.ReleaseHdc(gHdc)
            g.Dispose()
            'The BitBlt Api method failed, throw an SCaptureException.
            Throw New SCaptureException(New Win32Exception(eCode).Message)
        End If
        'Release the handles to device contexts.
        g.ReleaseHdc(gHdc)
        NativeMethods.ReleaseDC(IntPtr.Zero, wHdc)
        g.Dispose()
        'Return the captured bitmap.
        Return bmp
    End Function

    ''' <summary>
    ''' Get the handle device context for the entire screen.
    ''' </summary>
    <DebuggerHidden()> _
    Private Shared Function GetDC() As IntPtr
        'Get the handle of the desktop device context.
        Dim wHdc As IntPtr = NativeMethods.GetDC(IntPtr.Zero)
        If wHdc = IntPtr.Zero Then
            Dim eCode As Integer = Marshal.GetLastWin32Error
            'The GetDC Api method failed, throw an SCaptureException.
            Throw New SCaptureException(New Win32Exception(eCode).Message)
        Else
            Return wHdc
        End If
    End Function

    ''' <summary>
    ''' Draws the cursor onto the specified bitmap.
    ''' </summary>
    ''' <param name="rect">A rectangle within the screen 
    ''' coordinates whose bitmap is be captured.</param>
    ''' <param name="bmp">An bitmap on which the cursor should be drawn.</param>
    <DebuggerHidden()> _
    Private Shared Sub DrawCursor(ByVal rect As Rectangle, ByVal bmp As Bitmap)
        'Get the cursor information.
        Dim cInfo As SCapture.CursorInfo = SCapture.GetCursorInfo
        If cInfo.flags = NativeMethods.CURSOR_SHOWING AndAlso rect.Contains(cInfo.ptScreenPos) Then
            'Get the handle of the coursor icon.
            Dim hicon As IntPtr = SCapture.GetCursorIcon(cInfo.hCursor)
            'Get the coursor icon information.
            Dim iInfo As SCapture.IconInfo = SCapture.GetIconInfo(hicon)
            Dim g As Graphics = Graphics.FromImage(bmp)
            'Draw the coursor over the image.
            g.DrawIcon(Icon.FromHandle(hicon), cInfo.ptScreenPos.X - rect.X - iInfo.xHotspot, _
            cInfo.ptScreenPos.Y - rect.Y - iInfo.yHotspot)
            g.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Retrieves the cursor icon.
    ''' </summary>
    ''' <param name="hCursor">A cursor handle whose icon should be retrieved.</param>
    <DebuggerHidden()> _
    Private Shared Function GetCursorIcon(ByVal hCursor As IntPtr) As IntPtr
        'Get the handle of the coursor icon. 
        Dim hicon As IntPtr = NativeMethods.CopyIcon(hCursor)
        If hicon = IntPtr.Zero Then
            Dim eCode As Integer = Marshal.GetLastWin32Error
            'The CopyIcon Api method failed, throw an SCaptureException.
            Throw New SCaptureException(New Win32Exception(eCode).Message)
        Else
            'Return the handle of the cursor icon.
            Return hicon
        End If
    End Function

    ''' <summary>
    ''' Retrieves the cursor information.
    ''' </summary>
    <DebuggerHidden()> _
    Private Shared Function GetCursorInfo() As SCapture.CursorInfo
        Dim cInfo As New SCapture.CursorInfo
        cInfo.cbSize = Marshal.SizeOf(cInfo)
        'Get the coursor information.
        If Not NativeMethods.GetCursorInfo(cInfo) Then
            Dim eCode As Integer = Marshal.GetLastWin32Error
            'The GetCursorInfo Api method failed, throw an SCaptureException.
            Throw New SCaptureException(New Win32Exception(eCode).Message)
        Else
            'Return the coursor information.
            Return cInfo
        End If
    End Function

    ''' <summary>
    ''' Retrieves the cursor's icon information.
    ''' </summary>
    ''' <param name="hicon">An icon handle whose information should be retrieved.</param>
    <DebuggerHidden()> _
    Private Shared Function GetIconInfo(ByVal hicon As IntPtr) As SCapture.IconInfo
        Dim iInfo As New SCapture.IconInfo
        'Get the icon information.
        If Not NativeMethods.GetIconInfo(hicon, iInfo) Then
            Dim eCode As Integer = Marshal.GetLastWin32Error
            'The GetIconInfo Api method failed, throw an SCaptureException.
            Throw New SCaptureException(New Win32Exception(eCode).Message)
        Else
            'Return the icon information.
            Return iInfo
        End If
    End Function

#End Region

#Region " NativeMethods "

    ''' <summary>
    ''' Represents win32 Api shared methods, structures, and constants.
    ''' </summary>
    <CLSCompliant(True)> _
    Private NotInheritable Class NativeMethods

#Region " Constants "

        '============== GDI32 CONSTANTS ===============
        Public Const CAPTUREBLT As Int32 = &H40000000
        Public Const BLACKNESS As Int32 = &H42
        Public Const DSTINVERT As Int32 = &H550009
        Public Const MERGECOPY As Int32 = &HC000CA
        Public Const MERGEPAINT As Int32 = &HBB0226
        Public Const NOTSRCCOPY As Int32 = &H330008
        Public Const NOTSRCERASE As Int32 = &H1100A6
        Public Const PATCOPY As Int32 = &HF00021
        Public Const PATINVERT As Int32 = &H5A0049
        Public Const PATPAINT As Int32 = &HFB0A09
        Public Const SRCAND As Int32 = &H8800C6
        Public Const SRCCOPY As Int32 = &HCC0020
        Public Const SRCERASE As Int32 = &H440328
        Public Const SRCINVERT As Int32 = &H660046
        Public Const SRCPAINT As Int32 = &HEE0086
        Public Const WHITENESS As Int32 = &HFF0062

        Public Const HORZRES As Int32 = 8
        Public Const VERTRES As Int32 = 10
        '===========================================

        Public Const GA_PARENT As Int32 = 1
        Public Const GA_ROOT As Int32 = 2
        Public Const GA_ROOTOWNER As Int32 = 3

        ''' <summary>
        ''' Represents the cursor showing constant. Used with CURSORINFO structure.
        ''' </summary>
        Public Const CURSOR_SHOWING As Integer = &H1

#End Region

        <DebuggerHidden()> _
        Private Sub New()
        End Sub

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetWindowRect( _
        ByVal hWnd As IntPtr, _
        ByRef lpRect As Rect) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function ReleaseDC( _
        ByVal hWnd As IntPtr, _
        ByVal hdc As IntPtr) As Int32
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function WindowFromPoint( _
        ByVal pt As Point) As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetForegroundWindow() As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetAncestor( _
        ByVal hwnd As IntPtr, _
        ByVal gaFlags As Int32) As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetDC( _
        ByVal hwnd As IntPtr) As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function CopyIcon( _
        ByVal hIcon As IntPtr) As IntPtr
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetCursorInfo( _
        ByRef pci As CursorInfo) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32", SetLastError:=True)> _
        Public Shared Function GetIconInfo( _
        ByVal hIcon As IntPtr, _
        ByRef piconinfo As IconInfo) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("gdi32", SetLastError:=True)> _
        Public Shared Function BitBlt( _
        ByVal hdcDest As IntPtr, _
        ByVal nXDest As Int32, _
        ByVal nYDest As Int32, _
        ByVal nWidth As Int32, _
        ByVal nHeight As Int32, _
        ByVal hdcSrc As IntPtr, _
        ByVal nXSrc As Int32, _
        ByVal nYSrc As Int32, _
        ByVal dwRop As Int32) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

    End Class

#End Region

#Region " Structures "

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure Rect
        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32

        ''' <summary>
        ''' Converts the ICapture.Rect object to System.Drawing.Rectangle object.
        ''' </summary>
        <DebuggerHidden()> _
        Public Function ToRectangle() As Rectangle
            Return New Rectangle(Me.Left, Me.Top, Me.Right - Me.Left, Me.Bottom - Me.Top)
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CursorInfo
        Public cbSize As Int32
        Public flags As Int32
        Public hCursor As IntPtr
        Public ptScreenPos As Point
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure IconInfo
        Public fIcon As Boolean
        Public xHotspot As Int32
        Public yHotspot As Int32
        Public hbmMask As IntPtr
        Public hbmColor As IntPtr
    End Structure

#End Region

End Class

#Region " SCaptureException "

<Serializable(), CLSCompliant(True)> _
Public Class SCaptureException
    Inherits Exception

    <DebuggerHidden()> _
    Sub New()
    End Sub

    <DebuggerHidden()> _
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    <DebuggerHidden()> _
    Public Sub New(ByVal message As String, ByVal ex As Exception)
        MyBase.New(message, ex)
    End Sub

    <DebuggerHidden()> _
    Protected Sub New(ByVal info As Runtime.Serialization.SerializationInfo, ByVal context As Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
    End Sub

End Class

#End Region