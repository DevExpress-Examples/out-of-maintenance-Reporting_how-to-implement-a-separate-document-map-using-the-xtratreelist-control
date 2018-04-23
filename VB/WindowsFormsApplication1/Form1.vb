Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraTreeList.Nodes

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Private prevNode As BookmarkNode

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim report As New XtraReport1()
			printControl1.PrintingSystem = report.PrintingSystem
			report.CreateDocument()
			printControl1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap, New Object() { False })

			treeList1.BeginUpdate()
			treeList1.Columns.Add()
			treeList1.Columns(0).Caption = "Document Map"
			treeList1.Columns(0).VisibleIndex = 0
			treeList1.EndUpdate()

			treeList1.BeginUnboundLoad()
			Dim parentForRootNodes As TreeListNode = Nothing


			For Each node As BookmarkNode In printControl1.PrintingSystem.Document.BookmarkNodes
				AddNode(node, parentForRootNodes)
			Next node
			treeList1.EndUnboundLoad()

			DisplayCurrentBrick(TryCast(treeList1.FocusedNode.Tag, BookmarkNode))
		End Sub

		Private Sub AddNode(ByVal node As BookmarkNode, ByVal parentNode As TreeListNode)
			Dim treeNode As TreeListNode = treeList1.AppendNode(New Object() { node.Text }, parentNode)
			treeNode.Tag = node

			For Each childNode As BookmarkNode In node.Nodes
				AddNode(childNode, treeNode)
			Next childNode
		End Sub

		Private Sub treeList1_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles treeList1.FocusedNodeChanged
			Dim node As BookmarkNode = TryCast(e.Node.Tag, BookmarkNode)
			DisplayCurrentBrick(node)
		End Sub

		Private Sub DisplayCurrentBrick(ByVal node As BookmarkNode)
			If node IsNot Nothing Then
				If prevNode IsNot Nothing Then
					printControl1.PrintingSystem.UnmarkBrick(prevNode.Brick, prevNode.Page)
				End If
				printControl1.ShowBrick(node.Brick, node.Page)
				printControl1.PrintingSystem.MarkBrick(node.Brick, node.Page)

				prevNode = node
			End If
		End Sub
	End Class
End Namespace
