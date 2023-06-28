Imports System.Security.Cryptography
Imports System.Text
Module MyMod
    Public api_folder As String = "apptoken"
    Public mahasiswa_api As String = "http://f0832008.xsph.ru/" & api_folder & "/mahasiswa_api.php"
    Public mahasiswa_baru As Boolean
    Public Token As String = GetToken()

    Public Function GetToken() As String
        Dim valid_token As String
        Dim kode As String = "UMC.AC.ID"
        Dim today As DateTime = DateTime.Today
        Dim formattedDate As String = today.ToString("yyyy-MM-dd")
        valid_token = GetMD5Hash(kode & formattedDate)
        Return valid_token
    End Function

    Public Function GetMD5Hash(ByVal input As String) As String
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a StringBuilder to collect the bytes and create the hash string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data and format each one as a hexadecimal string.
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next

        ' Return the hexadecimal string.
        Return sBuilder.ToString()
    End Function
End Module
