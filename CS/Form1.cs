using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace CustomZooming {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            chartControl1.MouseWheel += new MouseEventHandler(chartControl1_MouseWheel);
        }

        void chartControl1_MouseWheel(object sender, MouseEventArgs e) {            
            XYDiagram diagram = ((ChartControl)sender).Diagram as XYDiagram;
            double minValueX = diagram.AxisX.VisualRange.MinValueInternal;
            double maxValueX = diagram.AxisX.VisualRange.MaxValueInternal;
            double minValueY = diagram.AxisY.VisualRange.MinValueInternal;
            double maxValueY = diagram.AxisY.VisualRange.MaxValueInternal;
            double secondMinValueX = diagram.SecondaryAxesX[0].VisualRange.MinValueInternal;
            double secondMaxValueX = diagram.SecondaryAxesX[0].VisualRange.MaxValueInternal;
            double secondMinValueY = diagram.SecondaryAxesY[0].VisualRange.MinValueInternal;
            double secondMaxValueY = diagram.SecondaryAxesY[0].VisualRange.MaxValueInternal;
            double scrollMinValueX = diagram.AxisX.WholeRange.MinValueInternal;
            double scrollMaxValueX = diagram.AxisX.WholeRange.MaxValueInternal;
            double scrollMinValueY = diagram.AxisY.WholeRange.MinValueInternal;
            double scrollMaxValueY = diagram.AxisY.WholeRange.MaxValueInternal;
            double secondScrollMinValueX = diagram.SecondaryAxesX[0].WholeRange.MinValueInternal;
            double secondScrollMaxValueX = diagram.SecondaryAxesX[0].WholeRange.MaxValueInternal;
            double secondScrollMinValueY = diagram.SecondaryAxesY[0].WholeRange.MinValueInternal;
            double secondScrollMaxValueY = diagram.SecondaryAxesY[0].WholeRange.MaxValueInternal;


            DiagramCoordinates coord = diagram.PointToDiagram(e.Location);
            double x = coord.NumericalArgument;
            double y = coord.NumericalValue;
            double secx = (secondMaxValueX - secondMinValueX) * (x - minValueX) / (maxValueX - minValueX) + secondMinValueX;
            double secy = (secondMaxValueY - secondMinValueY) * (y - minValueY) / (maxValueY - minValueY) + secondMinValueY;
            if (e.Delta > 0 && maxValueY - minValueY > 0.1 && maxValueX - minValueX > 0.1) {
                diagram.AxisX.VisualRange.SetMinMaxValues(0.2 * x + 0.8 * minValueX, 0.2 * x + 0.8 * maxValueX);
                diagram.AxisY.VisualRange.SetMinMaxValues(0.2 * y + 0.8 * minValueY, 0.2 * y + 0.8 * maxValueY);

                diagram.SecondaryAxesX[0].VisualRange.SetMinMaxValues(0.2 * secx + 0.8 * secondMinValueX, 0.2 * secx + 0.8 * secondMaxValueX);
                diagram.SecondaryAxesY[0].VisualRange.SetMinMaxValues(0.2 * secy + 0.8 * secondMinValueY, 0.2 * secy + 0.8 * secondMaxValueY);

            }
            if (e.Delta < 0 && (minValueX > scrollMinValueX || maxValueX < scrollMinValueX || minValueY > scrollMinValueY || maxValueY < scrollMaxValueY)) {
                double minValueInternalX = (1.2 * minValueX - 0.2 * x >= scrollMinValueX) ? 1.2 * minValueX - 0.2 * x : scrollMinValueX;
                double maxValueInternalX = (1.2 * maxValueX - 0.2 * x <= scrollMaxValueX) ? 1.2 * maxValueX - 0.2 * x : scrollMaxValueX;
                double minValueInternalY = (1.2 * minValueY - 0.2 * y >= scrollMinValueY) ? 1.2 * minValueY - 0.2 * y : scrollMinValueY;
                double maxValueInternalY = (1.2 * maxValueY - 0.2 * y <= scrollMaxValueY) ? 1.2 * maxValueY - 0.2 * y : scrollMaxValueY;
                diagram.AxisX.VisualRange.SetMinMaxValues(minValueInternalX, maxValueInternalX);
                diagram.AxisY.VisualRange.SetMinMaxValues(minValueInternalY, maxValueInternalY);
                double secondMinValueInternalX = (1.2 * secondMinValueX - 0.2 * secx >= secondScrollMinValueX) ? 1.2 * secondMinValueX - 0.2 * secx : secondScrollMinValueX;
                double secondMaxValueInternalX = (1.2 * secondMaxValueX - 0.2 * secx <= secondScrollMaxValueX) ? 1.2 * secondMaxValueX - 0.2 * secx : secondScrollMaxValueX;
                double secondMinValueInternalY = (1.2 * secondMinValueY - 0.2 * secy >= secondScrollMinValueY) ? 1.2 * secondMinValueY - 0.2 * secy : secondScrollMinValueY;
                double secondMaxValueInternalY = (1.2 * secondMaxValueY - 0.2 * secy <= secondScrollMaxValueY) ? 1.2 * secondMaxValueY - 0.2 * secy : secondScrollMaxValueY;
                diagram.SecondaryAxesX[0].VisualRange.SetMinMaxValues(secondMinValueInternalX, secondMaxValueInternalX);
                diagram.SecondaryAxesY[0].VisualRange.SetMinMaxValues(secondMinValueInternalY, secondMaxValueInternalY);
            }            
        }
    }
}