using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList.Nodes;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        BookmarkNode prevNode;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();
            printControl1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
            printControl1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.DocumentMap, new object[] { false } );            

            treeList1.BeginUpdate();
            treeList1.Columns.Add();
            treeList1.Columns[0].Caption = "Document Map";
            treeList1.Columns[0].VisibleIndex = 0;
            treeList1.EndUpdate();

            treeList1.BeginUnboundLoad();
            TreeListNode parentForRootNodes = null;


            foreach (BookmarkNode node in printControl1.PrintingSystem.Document.BookmarkNodes)
            {
                AddNode(node, parentForRootNodes);
            }
            treeList1.EndUnboundLoad();
            
            DisplayCurrentBrick(treeList1.FocusedNode.Tag as BookmarkNode);            
        }

        private void AddNode(BookmarkNode node, TreeListNode parentNode)
        {
            TreeListNode treeNode = treeList1.AppendNode(new object[] { node.Text }, parentNode);            
            treeNode.Tag = node;

            foreach (BookmarkNode childNode in node.Nodes)
                AddNode(childNode, treeNode);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            BookmarkNode node = e.Node.Tag as BookmarkNode;
            DisplayCurrentBrick(node);
        }

        private void DisplayCurrentBrick(BookmarkNode node)
        {
            if (node != null)
            {
                if (prevNode != null)
                    printControl1.PrintingSystem.UnmarkBrick(prevNode.Brick, prevNode.Page);
                printControl1.ShowBrick(node.Brick, node.Page);
                printControl1.PrintingSystem.MarkBrick(node.Brick, node.Page);

                prevNode = node;
            }
        }
    }
}
