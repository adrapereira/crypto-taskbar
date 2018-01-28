using System;
using System.ComponentModel;
using System.Windows.Forms;

using BandObjectLib;
using System.Runtime.InteropServices;

namespace CryptoTaskbar {
    [Guid("AE07101B-46D4-4a98-AF68-0333EA26E113")]
    [BandObject("CryptoTaskbar", BandObjectStyle.Horizontal | BandObjectStyle.ExplorerToolbar | BandObjectStyle.TaskbarToolBar, HelpText = "Shows the price of your favourite crypto coins.")]
    public class CryptoTaskbar : BandObject {
        private TableLayoutPanel tableLayout;
        private Label priceLabel;
        private IContainer components;
        private CryptoService cryptoService;

        public CryptoTaskbar() {
            this.cryptoService = new CryptoService();
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent() {
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.priceLabel = new System.Windows.Forms.Label();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.AutoSize = true;
            this.tableLayout.BackColor = System.Drawing.SystemColors.Desktop;
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.Controls.Add(this.priceLabel, 0, 0);
            this.tableLayout.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(424, 30);
            this.tableLayout.TabIndex = 1;
            // 
            // priceLabel
            // 
            this.priceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceLabel.AutoSize = true;
            this.priceLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.priceLabel.Location = new System.Drawing.Point(3, 0);
            this.priceLabel.MaximumSize = new System.Drawing.Size(120, 30);
            this.priceLabel.MinimumSize = new System.Drawing.Size(120, 30);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(120, 30);
            this.priceLabel.TabIndex = 0;
            this.priceLabel.Text = "Crypto";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.priceLabel.Click += new System.EventHandler(this.label1_Click);
            this.priceLabel.DataBindings.Add(CreateLabelDataBinding());
            // 
            // CryptoTaskbar
            // 
            this.Controls.Add(this.tableLayout);
            this.MinSize = new System.Drawing.Size(120, 30);
            this.Name = "CryptoTaskbar";
            this.Size = new System.Drawing.Size(120, 30);
            this.Title = "";
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void label1_Click(object sender, EventArgs e) {
            this.cryptoService.SelectNextCrypto();
            this.priceLabel.DataBindings.Clear();
            this.priceLabel.DataBindings.Add(CreateLabelDataBinding());
        }

        private Binding CreateLabelDataBinding() {
            return new Binding("Text", this.cryptoService.CurrentCrypto, "Value", true);
        }
    }
}
