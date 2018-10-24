'Name:          Marcy's BOGOHO Calculate
'Purpose:       Calculate the prices of two items with one discounted
'
'
'Programmer:    Kyle Hotchkiss on 07/01/18

Option Explicit On
Option Infer On
Option Strict On

Public Class frmMain
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim dblItem1 As Double
        Dim dblItem2 As Double
        Dim dblItem1Discount As Double
        Dim dblItem2Discount As Double
        Dim dblTotalDue As Double

        Double.TryParse(txtItem1.Text, dblItem1)
        Double.TryParse(txtItem2.Text, dblItem2)

        If dblItem1 > dblItem2 Then
            dblItem2Discount = dblItem2 / 2
            dblTotalDue = dblItem2Discount + dblItem1
            MessageBox.Show("You saved " & Format(dblItem2Discount, "currency") & " dollars.",
                            "Marcy's Department Store", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            lblTotal.Text = dblTotalDue.ToString("c2")

        ElseIf dblItem2 > dblItem1 Then
            dblItem1Discount = dblItem1 / 2
            dblTotalDue = dblItem1Discount + dblItem2
            MessageBox.Show("You saved " & Format(dblItem1Discount, "currency") & " dollars.",
                            "Marcy's Department Store", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            lblTotal.Text = dblTotalDue.ToString("c2")
        Else
            dblTotalDue = dblItem1 + dblItem2
            MessageBox.Show("Sorry, no discount today!", "Marcy's Department Store",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblTotal.Text = dblTotalDue.ToString("c2")
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lblTotal.Text = ""
        txtItem1.Text = ""
        txtItem2.Text = ""
    End Sub

    Private Sub ClearLabels(sender As Object, e As EventArgs) Handles txtItem1.TextChanged, txtItem2.TextChanged, txtItem2.KeyPress, txtItem1.KeyPress
        lblTotal.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub ClearLabels(sender As Object, e As KeyPressEventArgs) Handles txtItem1.KeyPress, txtItem2.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso
            e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

    End Sub
End Class

