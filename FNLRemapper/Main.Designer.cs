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
            this.cbFont = new System.Windows.Forms.ComboBox();
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
            this.Preview.Location = new System.Drawing.Point(12, 12);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(887, 158);
            this.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Preview.TabIndex = 0;
            this.Preview.TabStop = false;
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(15, 322);
            this.Progress.MarqueeAnimationSpeed = 10;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(887, 23);
            this.Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progress.TabIndex = 1;
            this.Progress.Value = 50;
            this.Progress.Visible = false;
            // 
            // btnOpenFont
            // 
            this.btnOpenFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFont.Location = new System.Drawing.Point(809, 7);
            this.btnOpenFont.Name = "btnOpenFont";
            this.btnOpenFont.Size = new System.Drawing.Size(75, 23);
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
            this.tbPreview.Location = new System.Drawing.Point(12, 202);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(887, 20);
            this.tbPreview.TabIndex = 0;
            this.tbPreview.Text = "The lazy dog jumps over the quick brown fox";
            this.tbPreview.TextChanged += new System.EventHandler(this.RefreshPreview);
            // 
            // lblPreview
            // 
            this.lblPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(12, 186);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(48, 13);
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
            this.cbFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.Enabled = false;
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Location = new System.Drawing.Point(43, 9);
            this.cbFace.Name = "cbFace";
            this.cbFace.Size = new System.Drawing.Size(60, 21);
            this.cbFace.TabIndex = 6;
            this.cbFace.SelectedIndexChanged += new System.EventHandler(this.FontFaceChanged);
            // 
            // lblFace
            // 
            this.lblFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFace.AutoSize = true;
            this.lblFace.Location = new System.Drawing.Point(3, 12);
            this.lblFace.Name = "lblFace";
            this.lblFace.Size = new System.Drawing.Size(34, 13);
            this.lblFace.TabIndex = 6;
            this.lblFace.Text = "Face:";
            // 
            // lblTable
            // 
            this.lblTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(109, 12);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(37, 13);
            this.lblTable.TabIndex = 7;
            this.lblTable.Text = "Table:";
            // 
            // cbTable
            // 
            this.cbTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTable.Enabled = false;
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(148, 9);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(60, 21);
            this.cbTable.TabIndex = 5;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.FontStyleChanged);
            // 
            // pnFontMenu
            // 
            this.pnFontMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnFontMenu.Location = new System.Drawing.Point(12, 312);
            this.pnFontMenu.Name = "pnFontMenu";
            this.pnFontMenu.Size = new System.Drawing.Size(887, 33);
            this.pnFontMenu.TabIndex = 9;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(538, 12);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 14;
            this.lblSize.Text = "Size:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(574, 9);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(44, 20);
            this.tbSize.TabIndex = 13;
            this.tbSize.Text = "38,0";
            // 
            // lblFont
            // 
            this.lblFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(384, 12);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(31, 13);
            this.lblFont.TabIndex = 12;
            this.lblFont.Text = "Font:";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Enabled = false;
            this.btnRedraw.Location = new System.Drawing.Point(314, 7);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(64, 23);
            this.btnRedraw.TabIndex = 10;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // btnRedrawTables
            // 
            this.btnRedrawTables.Enabled = false;
            this.btnRedrawTables.Location = new System.Drawing.Point(214, 7);
            this.btnRedrawTables.Name = "btnRedrawTables";
            this.btnRedrawTables.Size = new System.Drawing.Size(94, 23);
            this.btnRedrawTables.TabIndex = 8;
            this.btnRedrawTables.Text = "Redraw Tables";
            this.btnRedrawTables.UseVisualStyleBackColor = true;
            this.btnRedrawTables.Click += new System.EventHandler(this.btnRedrawFaces_Click);
            // 
            // btnSaveFont
            // 
            this.btnSaveFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFont.Enabled = false;
            this.btnSaveFont.Location = new System.Drawing.Point(728, 7);
            this.btnSaveFont.Name = "btnSaveFont";
            this.btnSaveFont.Size = new System.Drawing.Size(75, 23);
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
            this.lblVirtChars.Location = new System.Drawing.Point(12, 225);
            this.lblVirtChars.Name = "lblVirtChars";
            this.lblVirtChars.Size = new System.Drawing.Size(93, 13);
            this.lblVirtChars.TabIndex = 11;
            this.lblVirtChars.Text = "Virtual Characters:";
            // 
            // tbVirtChars
            // 
            this.tbVirtChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVirtChars.Location = new System.Drawing.Point(12, 241);
            this.tbVirtChars.Name = "tbVirtChars";
            this.tbVirtChars.Size = new System.Drawing.Size(887, 20);
            this.tbVirtChars.TabIndex = 1;
            this.tbVirtChars.Text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvxwyz\'\"+-;:.,[]()!?%¿Ññ" +
    "ôòÕÛÔÎÊÌÍÁÉÈÂÇÒÓìèÙÚùâàêçõãíáéóúÀËëÎîÏûüÜœæ";
            this.tbVirtChars.Enter += new System.EventHandler(this.OnVirtualFocused);
            // 
            // lblPhysChars
            // 
            this.lblPhysChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPhysChars.AutoSize = true;
            this.lblPhysChars.Location = new System.Drawing.Point(12, 264);
            this.lblPhysChars.Name = "lblPhysChars";
            this.lblPhysChars.Size = new System.Drawing.Size(103, 13);
            this.lblPhysChars.TabIndex = 13;
            this.lblPhysChars.Text = "Physical Characters:";
            // 
            // tbPhysChars
            // 
            this.tbPhysChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhysChars.Location = new System.Drawing.Point(12, 280);
            this.tbPhysChars.Name = "tbPhysChars";
            this.tbPhysChars.Size = new System.Drawing.Size(887, 20);
            this.tbPhysChars.TabIndex = 2;
            this.tbPhysChars.Text = "------------------------------------------------------------------------------ﾐｰｯ" +
    "ﾔﾒｵｻｴｮｪｬｭ｡ｩｨｫｧｲｳﾌﾈｹｺﾙﾂﾀﾊﾇﾕﾃﾍﾁﾉﾓﾚｦｱｶｷｸｼｾｿﾄﾆﾋ";
            this.tbPhysChars.Enter += new System.EventHandler(this.OnPhysicalFocused);
            // 
            // cbFont
            // 
            this.cbFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(421, 9);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(111, 21);
            this.cbFont.Sorted = true;
            this.cbFont.TabIndex = 15;
            this.cbFont.Text = "Consolas";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 357);
            this.Controls.Add(this.lblPhysChars);
            this.Controls.Add(this.tbPhysChars);
            this.Controls.Add(this.lblVirtChars);
            this.Controls.Add(this.tbVirtChars);
            this.Controls.Add(this.pnFontMenu);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Preview);
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
    }
}

