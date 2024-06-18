Imports System

Namespace SQLPROYECT

    Partial Class Form1
        ''' <summary>
        ''' Variable del diseñador necesaria.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Limpiar los recursos que se estén usando.
        ''' </summary>
        ''' <paramname="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Código generado por el Diseñador de Windows Forms"

        ''' <summary>
        ''' Método necesario para admitir el Diseñador. No se puede modificar
        ''' el contenido de este método con el editor de código.
        ''' </summary>
        Private Sub InitializeComponent()
            btnCsv = New Windows.Forms.Button()
            btnXml = New Windows.Forms.Button()
            btnJson = New Windows.Forms.Button()
            btnOpen = New Windows.Forms.Button()
            btnSave = New Windows.Forms.Button()
            btnMost = New Windows.Forms.Button()
            btnAdd = New Windows.Forms.Button()
            DGV1 = New Windows.Forms.DataGridView()
            CType(DGV1, ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()
            ' 
            ' btnCsv
            ' 
            btnCsv.Font = New Drawing.Font("Microsoft Sans Serif", 10.2F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnCsv.Location = New Drawing.Point(1317, 113)
            btnCsv.Name = "btnCsv"
            btnCsv.Size = New Drawing.Size(143, 41)
            btnCsv.TabIndex = 0
            btnCsv.Text = "SAVE CSV"
            btnCsv.UseVisualStyleBackColor = True
            AddHandler btnCsv.Click, New EventHandler(AddressOf btnCsv_Click)
            ' 
            ' btnXml
            ' 
            btnXml.Font = New Drawing.Font("Microsoft Sans Serif", 10.2F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnXml.Location = New Drawing.Point(1317, 173)
            btnXml.Name = "btnXml"
            btnXml.Size = New Drawing.Size(143, 41)
            btnXml.TabIndex = 1
            btnXml.Text = "SAVE XML"
            btnXml.UseVisualStyleBackColor = True
            AddHandler btnXml.Click, New EventHandler(AddressOf btnXml_Click)
            ' 
            ' btnJson
            ' 
            btnJson.Font = New Drawing.Font("Microsoft Sans Serif", 10.2F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnJson.Location = New Drawing.Point(1317, 235)
            btnJson.Name = "btnJson"
            btnJson.Size = New Drawing.Size(143, 41)
            btnJson.TabIndex = 2
            btnJson.Text = "SAVE JSON"
            btnJson.UseVisualStyleBackColor = True
            AddHandler btnJson.Click, New EventHandler(AddressOf btnJson_Click)
            ' 
            ' btnOpen
            ' 
            btnOpen.Font = New Drawing.Font("Microsoft Sans Serif", 12.0F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnOpen.ForeColor = Drawing.SystemColors.ActiveCaptionText
            btnOpen.Location = New Drawing.Point(1317, 26)
            btnOpen.Name = "btnOpen"
            btnOpen.Size = New Drawing.Size(168, 34)
            btnOpen.TabIndex = 3
            btnOpen.Text = "OPEN FILE"
            btnOpen.UseVisualStyleBackColor = True
            AddHandler btnOpen.Click, New EventHandler(AddressOf btnOpen_Click)
            ' 
            ' btnSave
            ' 
            btnSave.Font = New Drawing.Font("Microsoft Sans Serif", 13.8F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnSave.Location = New Drawing.Point(62, 512)
            btnSave.Name = "btnSave"
            btnSave.Size = New Drawing.Size(500, 51)
            btnSave.TabIndex = 4
            btnSave.Text = "UPDATE IN THE DATABASE"
            btnSave.UseVisualStyleBackColor = True
            AddHandler btnSave.Click, New EventHandler(AddressOf btnSave_Click)
            ' 
            ' btnMost
            ' 
            btnMost.Font = New Drawing.Font("Microsoft Sans Serif", 13.8F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnMost.Location = New Drawing.Point(699, 512)
            btnMost.Name = "btnMost"
            btnMost.Size = New Drawing.Size(500, 51)
            btnMost.TabIndex = 5
            btnMost.Text = "UPLOAD FROM THE DATABASE"
            btnMost.UseVisualStyleBackColor = True
            AddHandler btnMost.Click, New EventHandler(AddressOf btnMost_Click)
            ' 
            ' btnAdd
            ' 
            btnAdd.Font = New Drawing.Font("Microsoft Sans Serif", 10.8F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0)
            btnAdd.Location = New Drawing.Point(1317, 336)
            btnAdd.Name = "btnAdd"
            btnAdd.Size = New Drawing.Size(168, 34)
            btnAdd.TabIndex = 6
            btnAdd.Text = "ADD ROWS"
            btnAdd.UseVisualStyleBackColor = True
            AddHandler btnAdd.Click, New EventHandler(AddressOf btnAdd_Click)
            ' 
            ' DGV1
            ' 
            DGV1.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DGV1.Location = New Drawing.Point(12, 26)
            DGV1.Name = "DGV1"
            DGV1.RowHeadersWidth = 51
            DGV1.RowTemplate.Height = 24
            DGV1.Size = New Drawing.Size(1279, 446)
            DGV1.TabIndex = 7
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(8.0F, 16.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            BackColor = Drawing.SystemColors.MenuHighlight
            ClientSize = New Drawing.Size(1655, 624)
            Controls.Add(DGV1)
            Controls.Add(btnAdd)
            Controls.Add(btnMost)
            Controls.Add(btnSave)
            Controls.Add(btnOpen)
            Controls.Add(btnJson)
            Controls.Add(btnXml)
            Controls.Add(btnCsv)
            Name = "Form1"
            Text = "Form1"
            CType(DGV1, ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)

        End Sub

#End Region

        Private btnCsv As Windows.Forms.Button
        Private btnXml As Windows.Forms.Button
        Private btnJson As Windows.Forms.Button
        Private btnOpen As Windows.Forms.Button
        Private btnSave As Windows.Forms.Button
        Private btnMost As Windows.Forms.Button
        Private btnAdd As Windows.Forms.Button
        Private DGV1 As Windows.Forms.DataGridView
    End Class
End Namespace
