﻿Imports System.Runtime.CompilerServices

Public Module RNG
    Private ReadOnly random As New Random
    Const Zero = 0
    Function FromGenerator(Of TGenerated)(table As IReadOnlyDictionary(Of TGenerated, Integer), Optional r As Random = Nothing) As TGenerated
        Dim generated = If(r, random).Next(table.Values.Sum)
        For Each entry In table
            generated -= entry.Value
            If generated < Zero Then
                Return entry.Key
            End If
        Next
        Throw New NotImplementedException()
    End Function
    Function FromGenerator(Of TGenerated)(hashSet As HashSet(Of TGenerated)) As TGenerated
        Dim table As New Dictionary(Of TGenerated, Integer)
        For Each item In hashSet
            table.Add(item, 1)
        Next
        Return FromGenerator(table)
    End Function
    Function GenerateBoolean(falseWeight As Integer, trueWeight As Integer) As Boolean
        Return FromGenerator(MakeBooleanGenerator(falseWeight, trueWeight))
    End Function
    Function MakeBooleanGenerator(falseWeight As Integer, trueWeight As Integer) As Dictionary(Of Boolean, Integer)
        Return New Dictionary(Of Boolean, Integer) From
            {
                {True, trueWeight},
                {False, falseWeight}
            }
    End Function
    Function FromRange(minimum As Integer, maximum As Integer) As Integer
        Return random.Next(maximum - minimum + 1) + minimum
    End Function
    Function RollXDY(dieCount As Integer, dieSize As Integer) As Integer
        Dim total = Zero
        While dieCount > Zero
            dieCount -= 1
            total += FromRange(1, dieSize)
        End While
        Return total
    End Function
    Function ValidateDice(diceText As String) As Boolean
        Try
            RollDice(diceText)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function RollDice(diceText As String) As Integer
        If String.IsNullOrWhiteSpace(diceText) Then
            Return Zero
        End If
        Dim diceSets = diceText.Split("+")
        Dim tally = Zero
        For Each diceSet In diceSets
            Dim multiplier = 1
            Dim divisor = 1
            If diceSet.Contains("*"c) Then
                Dim scaleTokens = diceSet.Split("*"c)
                multiplier = CInt(scaleTokens(1))
                diceSet = scaleTokens(Zero)
            ElseIf diceSet.Contains("/"c) Then
                Dim scaleTokens = diceSet.Split("/"c)
                divisor = CInt(scaleTokens(1))
                diceSet = scaleTokens(Zero)
            End If
            Dim tokens = diceSet.Split("d"c, "D"c)
            Dim dieCount = CInt(tokens(Zero))
            Dim dieSize = CInt(tokens(1))
            tally += (If(dieCount < Zero, -RollXDY(-dieCount, dieSize), RollXDY(dieCount, dieSize)) * multiplier) \ divisor
        Next
        Return tally
    End Function
    Public Function MaximumRoll(diceText As String) As Integer
        If String.IsNullOrWhiteSpace(diceText) Then
            Return Zero
        End If
        Dim diceSets = diceText.Split("+")
        Dim tally = Zero
        For Each diceSet In diceSets
            Dim multiplier = 1
            Dim divisor = 1
            If diceSet.Contains("*"c) Then
                Dim scaleTokens = diceSet.Split("*"c)
                multiplier = CInt(scaleTokens(1))
                diceSet = scaleTokens(Zero)
            ElseIf diceSet.Contains("/"c) Then
                Dim scaleTokens = diceSet.Split("/"c)
                divisor = CInt(scaleTokens(1))
                diceSet = scaleTokens(Zero)
            End If
            Dim tokens = diceSet.Split("d"c, "D"c)
            Dim dieCount = CInt(tokens(Zero))
            Dim dieSize = CInt(tokens(1))
            tally += (Math.Max(dieCount * dieSize, dieCount) * multiplier) \ divisor
        Next
        Return tally
    End Function
    Function FromList(Of TItem)(items As List(Of TItem)) As TItem
        Return items(FromRange(Zero, items.Count - 1))
    End Function
    Function FromEnumerable(Of TItem)(items As IEnumerable(Of TItem)) As TItem
        Return FromList(items.ToList)
    End Function
End Module
Public Module DictionaryExtensions
    <Extension()>
    Function CombineGenerator(first As Dictionary(Of Integer, Integer), second As Dictionary(Of Integer, Integer)) As Dictionary(Of Integer, Integer)
        Dim result As New Dictionary(Of Integer, Integer)
        For Each firstItem In first
            For Each secondItem In second
                Dim combinedKey = firstItem.Key + secondItem.Key
                Dim combinedValue = firstItem.Value * secondItem.Value
                If result.ContainsKey(combinedKey) Then
                    result(combinedKey) += combinedValue
                Else
                    result.Add(combinedKey, combinedValue)
                End If
            Next
        Next
        Return result
    End Function
End Module