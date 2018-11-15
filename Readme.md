<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
<!-- default file list end -->
# How to implement a separate Document Map using the XtraTreeList control


<p>Please note that it is necessary to populate the nodes in the XtraTreeList control using values from the XtraReport.PrintingSystem.Document.BookmarkNodes collection. Once a certain node is clicked, call the PrintControl.ShowBrick method to navigate to the corresponding Brick.</p>

<br/>


