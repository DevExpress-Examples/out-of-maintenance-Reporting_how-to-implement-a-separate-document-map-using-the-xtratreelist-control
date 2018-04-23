Imports Microsoft.VisualBasic
Imports System
Namespace WindowsFormsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.printControl1 = New DevExpress.XtraPrinting.Control.PrintControl()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' printControl1
			' 
			Me.printControl1.BackColor = System.Drawing.Color.Empty
			Me.printControl1.ForeColor = System.Drawing.Color.Empty
			Me.printControl1.IsMetric = False
			Me.printControl1.Location = New System.Drawing.Point(274, 13)
			Me.printControl1.Name = "printControl1"
			Me.printControl1.Size = New System.Drawing.Size(690, 484)
			Me.printControl1.TabIndex = 1
			Me.printControl1.TooltipFont = New System.Drawing.Font("Tahoma", 8.25F)
			' 
			' treeList1
			' 
			Me.treeList1.Location = New System.Drawing.Point(13, 13)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.OptionsBehavior.Editable = False
			Me.treeList1.Size = New System.Drawing.Size(255, 484)
			Me.treeList1.TabIndex = 2
'			Me.treeList1.FocusedNodeChanged += New DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(Me.treeList1_FocusedNodeChanged);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(976, 509)
			Me.Controls.Add(Me.treeList1)
			Me.Controls.Add(Me.printControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private printControl1 As DevExpress.XtraPrinting.Control.PrintControl
		Private WithEvents treeList1 As DevExpress.XtraTreeList.TreeList
	End Class
End Namespace

