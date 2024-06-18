Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json


Namespace SQLPROYECT
    Public Partial Class Form1
        Inherits Form
        Private sql As SqlConnection
        Public Sub New()
            InitializeComponent()
            InitializeDatabaseConnection()
        End Sub
        Private Sub InitializeDatabaseConnection()
            Dim connectionString = "Server=KEILA\SQLEXPRESS01;Database=SQLPROYECT;Integrated Security=True;"
            sql = New SqlConnection(connectionString)
        End Sub
        Private Sub btnOpen_Click(sender As Object, e As EventArgs)
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog With {
    .Filter = "CSV files (.csv)|.csv|XML files (.xml)|.xml|JSON files (.json)|.json"
}
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = openFileDialog.FileName
                Dim extension As String = Path.GetExtension(filePath).ToLower()
                Select Case extension
                    Case ".csv"
                        LoadCsv(filePath)
                    Case ".xml"
                        LoadXml(filePath)
                    Case ".json"
                        LoadJson(filePath)
                    Case Else
                        MessageBox.Show("Unsupported file format")
                End Select
            End If
        End Sub

        Private Sub SaveDataToDatabase()
            Try
                sql.Open()
                Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM STUDENTS", sql)
                Dim sqlCommandBuilder As SqlCommandBuilder = New SqlCommandBuilder(sqlDataAdapter)
                Dim dataTable = CType(DGV1.DataSource, DataTable)
                sqlDataAdapter.Update(dataTable)
            Catch ex As Exception
                MessageBox.Show("Error saving data: " & ex.Message)
            Finally
                sql.Close()
            End Try
        End Sub
        Private Sub btnSave_Click(sender As Object, e As EventArgs)
            SaveDataToDatabase()
        End Sub
        Private Sub LoadDataFromDatabase()
            Try
                sql.Open()
                Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM STUDENTS", sql)
                Dim dataTable As DataTable = New DataTable()
                sqlDataAdapter.Fill(dataTable)
                DGV1.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error loading data: " & ex.Message)
            Finally
                sql.Close()
            End Try
        End Sub
        Private Sub btnMost_Click(sender As Object, e As EventArgs)
            LoadDataFromDatabase()
        End Sub
        Private Sub LoadCsv(filePath As String)
            Try
                Dim dataTable As DataTable = New DataTable()
                Using sr As StreamReader = New StreamReader(filePath)
                    Dim headers As String() = sr.ReadLine().Split(","c)
                    For Each header In headers
                        dataTable.Columns.Add(header)
                    Next
                    While Not sr.EndOfStream
                        Dim rows As String() = sr.ReadLine().Split(","c)
                        Dim dataRow As DataRow = dataTable.NewRow()
                        For i = 0 To headers.Length - 1
                            dataRow(i) = rows(i)
                        Next
                        dataTable.Rows.Add(dataRow)
                    End While
                End Using
                DGV1.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error loading CSV: " & ex.Message)
            End Try
        End Sub
        Private Sub LoadXml(filePath As String)
            Try
                Dim dataSet As DataSet = New DataSet()
                dataSet.ReadXml(filePath)
                DGV1.DataSource = dataSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Error loading XML: " & ex.Message)
            End Try
        End Sub
        Private Sub LoadJson(filePath As String)
            Try
                Dim jsonData = File.ReadAllText(filePath)
                Dim dataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonData)
                DGV1.DataSource = dataTable
            Catch ex As Exception
                MessageBox.Show("Error loading JSON: " & ex.Message)
            End Try
        End Sub

        Private Sub SaveToXml(filePath As String)
            Try
                Dim dataTable = CType(DGV1.DataSource, DataTable)
                If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                    MessageBox.Show("No data to save!")
                    Return
                End If

                Dim dataSet As DataSet = New DataSet()
                dataSet.Tables.Add(dataTable.Copy())
                dataSet.WriteXml(filePath)

                MessageBox.Show("Data saved successfully to XML: " & filePath)
            Catch ex As Exception
                MessageBox.Show("Error saving to XML: " & ex.Message)
            End Try
        End Sub
        Private Sub SaveToCsv(filePath As String)
            Try
                Dim dataTable = CType(DGV1.DataSource, DataTable)
                If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                    MessageBox.Show("No data to save!")
                    Return
                End If

                Dim csvData As StringBuilder = New StringBuilder()

                ' Write header row
                For Each column As DataColumn In dataTable.Columns
                    csvData.Append(column.ColumnName & ",")
                Next
                csvData.Remove(csvData.Length - 1, 1) ' Remove trailing comma
                csvData.AppendLine()

                ' Write data rows
                For Each row As DataRow In dataTable.Rows
                    For i = 0 To row.ItemArray.Length - 1
                        Dim cellValue As String = row.ItemArray(i).ToString()
                        ' Escape special characters for CSV (optional)
                        ' cellValue = cellValue.Replace(",", "\",");
                        csvData.Append(cellValue & ",")
                    Next
                    csvData.Remove(csvData.Length - 1, 1) ' Remove trailing comma
                    csvData.AppendLine()
                Next

                Call File.WriteAllText(filePath, csvData.ToString())

                MessageBox.Show("Data saved successfully to CSV: " & filePath)
            Catch ex As Exception
                MessageBox.Show("Error saving to CSV: " & ex.Message)
            End Try
        End Sub
        Private Sub SaveToJson(filePath As String)
            Try
                Dim dataTable = CType(DGV1.DataSource, DataTable)
                If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                    MessageBox.Show("No data to save!")
                    Return
                End If

                Dim jsonData As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
                For Each row As DataRow In dataTable.Rows
                    Dim rowData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
                    For i = 0 To row.ItemArray.Length - 1
                        rowData.Add(dataTable.Columns(i).ColumnName, row.ItemArray(i))
                    Next
                    jsonData.Add(rowData)
                Next

                Dim jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented)
                File.WriteAllText(filePath, jsonString)

                MessageBox.Show("Data saved successfully to JSON: " & filePath)
            Catch ex As Exception
            End Try
        End Sub
        Private Sub btnCsv_Click(sender As Object, e As EventArgs)
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "CSV files (.csv)|.csv"
            saveFileDialog.Title = "Save data to CSV"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = saveFileDialog.FileName
                SaveToCsv(filePath)
            End If
        End Sub
        Private Sub btnXml_Click(sender As Object, e As EventArgs)
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "XML files (.xml)|.xml"
            saveFileDialog.Title = "Save data to XML"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = saveFileDialog.FileName
                SaveToXml(filePath)
            End If
        End Sub
        Private Sub btnJson_Click(sender As Object, e As EventArgs)
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "JSON files (.json)|.json"
            saveFileDialog.Title = "Save data to XML"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath = saveFileDialog.FileName
                SaveToJson(filePath)
            End If
        End Sub
        Private Sub btnAdd_Click(sender As Object, e As EventArgs)
            Dim dataTable = CType(DGV1.DataSource, DataTable)

            ' Create a new row with empty values
            Dim newRow As DataRow = dataTable.NewRow()
            For i = 0 To dataTable.Columns.Count - 1
                newRow(i) = DBNull.Value ' Set default values as appropriate
            Next

            ' Add the new row to the DataTable
            dataTable.Rows.Add(newRow)

            ' Update the DataGridView to reflect the changes
            DGV1.Refresh()
        End Sub
    End Class
End Namespace
