using BMPTrains_2020.DomainCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPTrains_2020
{
    public partial class frmExfiltrationCalculator : Form
    {
        public int currentCatchmentID = 1;

        public frmExfiltrationCalculator(int id)
        {
            InitializeComponent();
            currentCatchmentID = id;
            currentBMP().SetValuesFromCatchment(currentCatchment());
        }

        private void frmExfiltrationCalculator_Load(object sender, EventArgs e)
        {
            setValues();
        }

        private Catchment currentCatchment()
        {
            return Globals.Project.getCatchment(currentCatchmentID);
        }

        private Exfiltration currentBMP()
        {
            return currentCatchment().getExfiltration();
        }

        public void getValues()
        {
            currentBMP().PipeSpan = Common.getDouble(tbPipeSpan);
            currentBMP().PipeRise = Common.getDouble(tbPipeRise);
            currentBMP().PipeLength = Common.getDouble(tbPipeLength);
            currentBMP().TrenchWidth = Common.getDouble(tbTrenchWidth);
            currentBMP().TrenchDepth = Common.getDouble(tbTrenchDepth);
            currentBMP().TrenchLength = Common.getDouble(tbTrenchLength);
            currentBMP().VoidRatio = Common.getDouble(tbVoidRatio);
        }

        public void setValues()
        {
            Common.setValue(tbPipeSpan, currentBMP().PipeSpan);
            Common.setValue(tbPipeRise, currentBMP().PipeRise);
            Common.setValue(tbPipeLength, currentBMP().PipeLength);
            Common.setValue(tbTrenchWidth, currentBMP().TrenchWidth);
            Common.setValue(tbTrenchDepth, currentBMP().TrenchDepth);
            Common.setValue(tbTrenchLength, currentBMP().TrenchLength);
            Common.setValue(tbVoidRatio, currentBMP().VoidRatio);

            currentBMP().Calculate();
            setOutputText();
        }

        private void setOutputText()
        {
            wbOutput.DocumentText = currentBMP().PrintStorageReport();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getValues();
            currentBMP().Calculate();
            setOutputText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
