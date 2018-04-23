# How to implement custom zooming for a chart control in a Windows Forms application when Secondary Axis are used


<p>This example demonstrates how to implement custom zooming for a chart control. To accomplish this task, handle the MouseWheel event. 
Within this event handler, call the XYDiagram.PointToDiagram method to obtain information relative to the coordinates of the mouse pointer 
affiliation with a series or series point in a diagram. Corresponding values for the secondary axes should be calculated manually.  After 
that you can manually assign both minimum and maximum internal values of an axis range as your needs dictate.</p><p>See also: <a href="https://www.devexpress.com/Support/Center/p/E1871">How to implement custom zooming for the chart control in a Windows Forms application</a>.</p>

<br/>

