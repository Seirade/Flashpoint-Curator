Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging


Namespace ScreenShot
    '/ Provides functions to capture the entire screen, or a particular window, and save it to a file.
    Public Class ScreenCapture
        '/ Creates an Image object containing a screen shot of a specific window
        Public Function CaptureWindow(ByVal handle As IntPtr) As Image
            Dim SRCCOPY As Integer = &HCC0020
            ' get te hDC of the target window
            Dim hdcSrc As IntPtr = User32.GetWindowDC(handle)
            ' get the size
            Dim windowRect As New User32.RECT
            User32.GetWindowRect(handle, windowRect)
            Dim width As Integer = windowRect.right - windowRect.left
            Dim height As Integer = windowRect.bottom - windowRect.top
            ' create a device context we can copy to
            Dim hdcDest As IntPtr = GDI32.CreateCompatibleDC(hdcSrc)
            ' create a bitmap we can copy it to,
            ' using GetDeviceCaps to get the width/height
            Dim hBitmap As IntPtr = GDI32.CreateCompatibleBitmap(hdcSrc, width, height)
            ' select the bitmap object
            Dim hOld As IntPtr = GDI32.SelectObject(hdcDest, hBitmap)
            ' bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY)
            ' restore selection
            GDI32.SelectObject(hdcDest, hOld)
            ' clean up 
            GDI32.DeleteDC(hdcDest)
            User32.ReleaseDC(handle, hdcSrc)

            ' get a .NET image object for it
            Dim img As Image = Image.FromHbitmap(hBitmap)
            ' free up the Bitmap object
            GDI32.DeleteObject(hBitmap)

            Return img
        End Function 'CaptureWindow
        
        '/ Helper class containing Gdi32 API functions
        Private Class GDI32
            Public SRCCOPY As Integer = &HCC0020
            ' BitBlt dwRop parameter
            Declare Function BitBlt Lib "gdi32.dll" ( _
                ByVal hDestDC As IntPtr, _
                ByVal x As Int32, _
                ByVal y As Int32, _
                ByVal nWidth As Int32, _
                ByVal nHeight As Int32, _
                ByVal hSrcDC As IntPtr, _
                ByVal xSrc As Int32, _
                ByVal ySrc As Int32, _
                ByVal dwRop As Int32) As Int32

            Declare Function CreateCompatibleBitmap Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal nWidth As Int32, ByVal nHeight As Int32) As IntPtr
            Declare Function CreateCompatibleDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As IntPtr
            Declare Function DeleteDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As Int32
            Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As IntPtr) As Int32
            Declare Function SelectObject Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
        End Class 'GDI32
        '/ Helper class containing User32 API functions
        Public Class User32
            <StructLayout(LayoutKind.Sequential)> _
            Public Structure RECT
                Public left As Integer
                Public top As Integer
                Public right As Integer
                Public bottom As Integer
            End Structure 'RECT

            Declare Function GetDesktopWindow Lib "user32.dll" () As IntPtr
            Declare Function GetWindowDC Lib "user32.dll" (ByVal hwnd As IntPtr) As IntPtr
            Declare Function ReleaseDC Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal hdc As IntPtr) As Int32
            Declare Function GetWindowRect Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Int32

        End Class 'User32
    End Class 'ScreenCapture 
End Namespace 'ScreenShot