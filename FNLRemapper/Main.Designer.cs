namespace FNLRemapper
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Preview = new System.Windows.Forms.PictureBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.btnOpenFont = new System.Windows.Forms.Button();
            this.FontOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.tmRefreshPreview = new System.Windows.Forms.Timer(this.components);
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.lblFace = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.pnFontMenu = new System.Windows.Forms.Panel();
            this.cbFontType = new System.Windows.Forms.ComboBox();
            this.ckAutoPadding = new System.Windows.Forms.CheckBox();
            this.tbPaddingRigth = new System.Windows.Forms.TextBox();
            this.lblPadding = new System.Windows.Forms.Label();
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.btnRedrawTables = new System.Windows.Forms.Button();
            this.btnSaveFont = new System.Windows.Forms.Button();
            this.FontSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblVirtChars = new System.Windows.Forms.Label();
            this.tbVirtChars = new System.Windows.Forms.TextBox();
            this.lblPhysChars = new System.Windows.Forms.Label();
            this.tbPhysChars = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.pnFontMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Preview
            // 
            this.Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Preview.BackColor = System.Drawing.Color.Black;
            this.Preview.Location = new System.Drawing.Point(16, 15);
            this.Preview.Margin = new System.Windows.Forms.Padding(4);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(1207, 178);
            this.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Preview.TabIndex = 0;
            this.Preview.TabStop = false;
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(20, 396);
            this.Progress.Margin = new System.Windows.Forms.Padding(4);
            this.Progress.MarqueeAnimationSpeed = 10;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(1207, 28);
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progress.TabIndex = 1;
            this.Progress.Value = 50;
            this.Progress.Visible = false;
            // 
            // btnOpenFont
            // 
            this.btnOpenFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFont.Location = new System.Drawing.Point(1103, 42);
            this.btnOpenFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFont.Name = "btnOpenFont";
            this.btnOpenFont.Size = new System.Drawing.Size(100, 28);
            this.btnOpenFont.TabIndex = 3;
            this.btnOpenFont.Text = "Open Font";
            this.btnOpenFont.UseVisualStyleBackColor = true;
            this.btnOpenFont.Click += new System.EventHandler(this.btnOpenFont_Click);
            // 
            // FontOpenDialog
            // 
            this.FontOpenDialog.DefaultExt = "fnl";
            this.FontOpenDialog.Filter = "All SystemX Fonts|*.fnl";
            this.FontOpenDialog.Title = "Select a Font to Open";
            this.FontOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FontOpenDialog_FileOk);
            // 
            // tbPreview
            // 
            this.tbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPreview.Location = new System.Drawing.Point(16, 217);
            this.tbPreview.Margin = new System.Windows.Forms.Padding(4);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(1205, 22);
            this.tbPreview.TabIndex = 0;
            this.tbPreview.Text = "The lazy dog jumps over the quick brown fox";
            this.tbPreview.TextChanged += new System.EventHandler(this.RefreshPreview);
            // 
            // lblPreview
            // 
            this.lblPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(16, 197);
            this.lblPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(61, 17);
            this.lblPreview.TabIndex = 4;
            this.lblPreview.Text = "Preview:";
            // 
            // tmRefreshPreview
            // 
            this.tmRefreshPreview.Interval = 500;
            this.tmRefreshPreview.Tick += new System.EventHandler(this.RefreshPreviewNow);
            // 
            // cbFace
            // 
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.Enabled = false;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Location = new System.Drawing.Point(57, 11);
            this.cbFace.Margin = new System.Windows.Forms.Padding(4);
            this.cbFace.Name = "cbFace";
            this.cbFace.Size = new System.Drawing.Size(79, 24);
            this.cbFace.TabIndex = 6;
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.FontFaceChanged);
            // 
            // lblFace
            // 
            this.lblFace.AutoSize = true;
            this.lblFace.Location = new System.Drawing.Point(4, 15);
            this.lblFace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(43, 17);
            this.lblFace.TabIndex = 6;
            this.lblFace.Text = "Face:";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(145, 15);
            this.lblTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(48, 17);
            this.lblTable.TabIndex = 7;
            this.lblTable.Text = "Table:";
            // 
            // cbTable
            // 
            this.cbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTable.Enabled = false;
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(197, 11);
            this.cbTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(79, 24);
            this.cbTable.TabIndex = 5;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.FontStyleChanged);
            // 
            // pnFontMenu
            // 
            this.pnFontMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFontMenu.Controls.Add(this.cbFontType);
            this.pnFontMenu.Controls.Add(this.ckAutoPadding);
            this.pnFontMenu.Controls.Add(this.tbPaddingRigth);
            this.pnFontMenu.Controls.Add(this.lblPadding);
            this.pnFontMenu.Controls.Add(this.cbFont);
            this.pnFontMenu.Controls.Add(this.lblSize);
            this.pnFontMenu.Controls.Add(this.tbSize);
            this.pnFontMenu.Controls.Add(this.lblFont);
            this.pnFontMenu.Controls.Add(this.btnRedraw);
            this.pnFontMenu.Controls.Add(this.btnRedrawTables);
            this.pnFontMenu.Controls.Add(this.btnSaveFont);
            this.pnFontMenu.Controls.Add(this.btnOpenFont);
            this.pnFontMenu.Controls.Add(this.cbTable);
            this.pnFontMenu.Controls.Add(this.lblFace);
            this.pnFontMenu.Controls.Add(this.lblTable);
            this.pnFontMenu.Controls.Add(this.cbFace);
            this.pnFontMenu.Location = new System.Drawing.Point(16, 345);
            this.pnFontMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnFontMenu.Name = "pnFontMenu";
            this.pnFontMenu.Size = new System.Drawing.Size(1207, 80);
            this.pnFontMenu.TabIndex = 9;
            // 
            // cbFontType
            // 
            this.cbFontType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontType.FormattingEnabled = true;
            this.cbFontType.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Regular",
            "Underline"});
            this.cbFontType.Location = new System.Drawing.Point(284, 43);
            this.cbFontType.Margin = new System.Windows.Forms.Padding(4);
            this.cbFontType.Name = "cbFontType";
            this.cbFontType.Size = new System.Drawing.Size(118, 24);
            this.cbFontType.Sorted = true;
            this.cbFontType.TabIndex = 19;
            // 
            // ckAutoPadding
            // 
            this.ckAutoPadding.AutoSize = true;
            this.ckAutoPadding.Location = new System.Drawing.Point(677, 45);
            this.ckAutoPadding.Name = "ckAutoPadding";
            this.ckAutoPadding.Size = new System.Drawing.Size(115, 21);
            this.ckAutoPadding.TabIndex = 18;
            this.ckAutoPadding.Text = "Auto Padding";
            this.ckAutoPadding.UseVisualStyleBackColor = true;
            // 
            // tbPaddingRigth
            // 
            this.tbPaddingRigth.Location = new System.Drawing.Point(613, 43);
            this.tbPaddingRigth.Margin = new System.Windows.Forms.Padding(4);
            this.tbPaddingRigth.Name = "tbPaddingRigth";
            this.tbPaddingRigth.Size = new System.Drawing.Size(57, 22);
            this.tbPaddingRigth.TabIndex = 17;
            this.tbPaddingRigth.Text = "0";
            // 
            // lblPadding
            // 
            this.lblPadding.AutoSize = true;
            this.lblPadding.Location = new System.Drawing.Point(525, 47);
            this.lblPadding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPadding.Name = "lblPadding";
            this.lblPadding.Size = new System.Drawing.Size(78, 17);
            this.lblPadding.TabIndex = 16;
            this.lblPadding.Text = "Padding R:";
            // 
            // cbFont
            // 
            this.cbFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(57, 44);
            this.cbFont.Margin = new System.Windows.Forms.Padding(4);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(219, 24);
            this.cbFont.Sorted = true;
            this.cbFont.TabIndex = 15;
            this.cbFont.Text = "Consolas";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(410, 47);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(39, 17);
            this.lblSize.TabIndex = 14;
            this.lblSize.Text = "Size:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(458, 43);
            this.tbSize.Margin = new System.Windows.Forms.Padding(4);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(57, 22);
            this.tbSize.TabIndex = 13;
            this.tbSize.Text = "38,0";
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(8, 48);
            this.lblFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(40, 17);
            this.lblFont.TabIndex = 12;
            this.lblFont.Text = "Font:";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Enabled = false;
            this.btnRedraw.Location = new System.Drawing.Point(423, 9);
            this.btnRedraw.Margin = new System.Windows.Forms.Padding(4);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(124, 28);
            this.btnRedraw.TabIndex = 10;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // btnRedrawTables
            // 
            this.btnRedrawTables.Enabled = false;
            this.btnRedrawTables.Location = new System.Drawing.Point(289, 9);
            this.btnRedrawTables.Margin = new System.Windows.Forms.Padding(4);
            this.btnRedrawTables.Name = "btnRedrawTables";
            this.btnRedrawTables.Size = new System.Drawing.Size(125, 28);
            this.btnRedrawTables.TabIndex = 8;
            this.btnRedrawTables.Text = "Redraw Tables";
            this.btnRedrawTables.UseVisualStyleBackColor = true;
            this.btnRedrawTables.Click += new System.EventHandler(this.btnRedrawFaces_Click);
            // 
            // btnSaveFont
            // 
            this.btnSaveFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFont.Enabled = false;
            this.btnSaveFont.Location = new System.Drawing.Point(1103, 9);
            this.btnSaveFont.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveFont.Name = "btnSaveFont";
            this.btnSaveFont.Size = new System.Drawing.Size(100, 28);
            this.btnSaveFont.TabIndex = 4;
            this.btnSaveFont.Text = "Save Font";
            this.btnSaveFont.UseVisualStyleBackColor = true;
            this.btnSaveFont.Click += new System.EventHandler(this.btnSaveFont_Click);
            // 
            // FontSaveDialog
            // 
            this.FontSaveDialog.DefaultExt = "fnl";
            this.FontSaveDialog.Filter = "All SystemX Fonts|*.fnl";
            this.FontSaveDialog.Title = "Select a place to save";
            this.FontSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FontSaveDialog_FileOk);
            // 
            // lblVirtChars
            // 
            this.lblVirtChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVirtChars.AutoSize = true;
            this.lblVirtChars.Location = new System.Drawing.Point(16, 245);
            this.lblVirtChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVirtChars.Name = "lblVirtChars";
            this.lblVirtChars.Size = new System.Drawing.Size(125, 17);
            this.lblVirtChars.TabIndex = 11;
            this.lblVirtChars.Text = "Virtual Characters:";
            // 
            // tbVirtChars
            // 
            this.tbVirtChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVirtChars.Location = new System.Drawing.Point(16, 265);
            this.tbVirtChars.Margin = new System.Windows.Forms.Padding(4);
            this.tbVirtChars.Name = "tbVirtChars";
            this.tbVirtChars.Size = new System.Drawing.Size(1205, 22);
            this.tbVirtChars.TabIndex = 1;
            this.tbVirtChars.Text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvxwyz\'\"+-;:.,‘’“”[]()!?" +
    "%¿ÑñôòÕÛÔÎÊÌÍÁÉÈÂÇÒÓìèÙÚùâàêçõãíáéóúÀËëÎîÏûüÜœæ";
            this.tbVirtChars.Enter += new System.EventHandler(this.OnVirtualFocused);
            // 
            // lblPhysChars
            // 
            this.lblPhysChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPhysChars.AutoSize = true;
            this.lblPhysChars.Location = new System.Drawing.Point(16, 293);
            this.lblPhysChars.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhysChars.Name = "lblPhysChars";
            this.lblPhysChars.Size = new System.Drawing.Size(137, 17);
            this.lblPhysChars.TabIndex = 13;
            this.lblPhysChars.Text = "Physical Characters:";
            // 
            // tbPhysChars
            // 
            this.tbPhysChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhysChars.Location = new System.Drawing.Point(16, 313);
            this.tbPhysChars.Margin = new System.Windows.Forms.Padding(4);
            this.tbPhysChars.Name = "tbPhysChars";
            this.tbPhysChars.Size = new System.Drawing.Size(1205, 22);
            this.tbPhysChars.TabIndex = 2;
            this.tbPhysChars.Text = "---------------------------------------------------------------------------------" +
    "-ﾐｰｯﾔﾒｵｻｴｮｪｬｭ｡ｩｨｫｧｲｳﾌﾈｹｺﾙﾂﾀﾊﾇﾕﾃﾍﾁﾉﾓﾚｦｱｶｷｸｼｾｿﾄﾆﾋ";
            this.tbPhysChars.Enter += new System.EventHandler(this.OnPhysicalFocused);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 439);
            this.Controls.Add(this.lblPhysChars);
            this.Controls.Add(this.tbPhysChars);
            this.Controls.Add(this.lblVirtChars);
            this.Controls.Add(this.tbVirtChars);
            this.Controls.Add(this.pnFontMenu);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Preview);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "FNLRemapper - By Marcussacana";
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.pnFontMenu.ResumeLayout(false);
            this.pnFontMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Button btnOpenFont;
        private System.Windows.Forms.OpenFileDialog FontOpenDialog;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Timer tmRefreshPreview;
        private System.Windows.Forms.ComboBox cbFace;
        private System.Windows.Forms.Label lblFace;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Panel pnFontMenu;
        private System.Windows.Forms.Button btnSaveFont;
        private System.Windows.Forms.SaveFileDialog FontSaveDialog;
        private System.Windows.Forms.Label lblVirtChars;
        private System.Windows.Forms.TextBox tbVirtChars;
        private System.Windows.Forms.Label lblPhysChars;
        private System.Windows.Forms.TextBox tbPhysChars;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.Button btnRedrawTables;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.TextBox tbPaddingRigth;
        private System.Windows.Forms.Label lblPadding;
        private System.Windows.Forms.CheckBox ckAutoPadding;
        private System.Windows.Forms.ComboBox cbFontType;
    }
}

