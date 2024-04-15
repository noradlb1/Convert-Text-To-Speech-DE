Imports System.IO
Imports System.Net
Public Class Form1
    Private Sub ConvertTextToSpeech(text As String)
        Try
            ' تحديد رابط طلب Google Text-to-Speech API
            Dim apiURL As String = "https://translate.google.com/translate_tts?ie=UTF-8&client=tw-ob&tl=de&q="

            ' تحويل النص إلى تنسيق URL متوافق
            Dim encodedText As String = WebUtility.UrlEncode(text)

            ' بناء الرابط النهائي للطلب
            Dim requestURL As String = apiURL & encodedText

            ' إرسال طلب HTTP GET إلى API
            Dim webClient As New WebClient()
            Dim responseBytes As Byte() = webClient.DownloadData(requestURL)

            ' حفظ النص الصوتي كملف MP3 محلياً
            File.WriteAllBytes("output.mp3", responseBytes)

            MessageBox.Show("تم تحويل النص إلى كلام بنجاح وحفظه كملف MP3!")
        Catch ex As Exception
            MessageBox.Show($"حدث خطأ أثناء تحويل النص إلى كلام: {ex.Message}")
        End Try
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Dim text As String = txtInput.Text.Trim()

        ' تحويل النص إلى كلام باستخدام Google Text-to-Speech API
        ConvertTextToSpeech(text)
    End Sub

End Class
