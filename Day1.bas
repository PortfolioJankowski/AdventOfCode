Attribute VB_Name = "Day_1"
Sub firstDay()
'Deklaracja
Dim wb As Workbook
Dim ws As Worksheet
Dim output As Long
Dim outputArr As Variant
Dim temp As Integer

Dim element As Variant
Dim arr As Variant

Set wb = ThisWorkbook
Set ws = wb.Sheets("Data")
arr = ws.Range("a1").CurrentRegion
temp = 0

output = 0

For Each element In arr
    'wywoluje funkcje z konwersja na string
    outputArr = getDigits(CStr(element))
    temp = outputArr(1) * 10 + outputArr(2)
    output = output + temp
Next element

Debug.Print output

End Sub

Function getDigits(inputString As String) As Variant
    Dim char As Variant
    Dim digitColl As Collection
    Dim resultArr(1 To 2) As Variant

    Dim output As Variant
    Dim i As Integer
    
    Set digitColl = New Collection
    Dim inputArr() As String
    
    'zamieniam stringa w tablice charów
    ReDim inputArr(Len(inputString) - 1)
    For i = 1 To Len(inputString)
        inputArr(i - 1) = Mid$(inputString, i, 1)
    Next
    
    i = 1
      
   ' Jezeli element jest numeryczny, dodaje go do kolekcji digitColl
   For Each char In inputArr
        If IsNumeric(char) Then
            digitColl.Add CInt(char)
        End If
    Next char
        
    'obliczam ile jest wartosci w tablicy
    Dim counter As Integer
    counter = 0
    For Each x In digitColl
        counter = counter + 1
    Next x
    
        'sprawdzam czy tablica nie zawiera 1 wartosci
        If counter = 1 Then
            digitColl.Add (digitColl(1))
        End If
     counter = 0
    
    'biore index ostatniej wartosci z tablicy
    Dim colLen As Integer
    colLen = digitColl.Count

    'tzw zwrot
    resultArr(1) = digitColl(1)
    resultArr(2) = digitColl(colLen)
    
    getDigits = resultArr
      
End Function
