using BarcodeVerificationSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeVerificationSystem.View.UtilityForms
{
    public partial class frmConfirmCompletion : Form
    {
        private JobModel _jobModel;
        public frmConfirmCompletion(JobModel jobModel)
        {
            _jobModel = jobModel;
            InitializeComponent();
            InitControls();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitControls()
        {
            wmsNumber.Text = _jobModel.OrderPayload.payload.wms_number;
            materialID.Text = _jobModel.OrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_number;
            materialName.Text = _jobModel.OrderPayload.payload.item[_jobModel.SelectedMaterialIndex].material_name;
        }


    }
}
