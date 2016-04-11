namespace SafeStorage
{
    partial class SafeStorage
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SafeStorage));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.newStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.openStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.createStorageFile = new System.Windows.Forms.SaveFileDialog();
            this.addFileInStorage = new System.Windows.Forms.OpenFileDialog();
            this.openStorageFile = new System.Windows.Forms.OpenFileDialog();
            this.labelStorage = new System.Windows.Forms.Label();
            this.labelStoragePath = new System.Windows.Forms.Label();
            this.contentStorage = new System.Windows.Forms.ListBox();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.progressAdd = new System.Windows.Forms.ProgressBar();
            this.ExtractFile = new System.Windows.Forms.Button();
            this.extractFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonCrypt = new System.Windows.Forms.Button();
            this.decryptDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(594, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStorage,
            this.openStorage});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 20);
            this.Menu.Text = "Меню";
            // 
            // newStorage
            // 
            this.newStorage.Name = "newStorage";
            this.newStorage.Size = new System.Drawing.Size(189, 22);
            this.newStorage.Text = "Создать хранилище";
            this.newStorage.Click += new System.EventHandler(this.создатьХранилищеToolStripMenuItem_Click);
            // 
            // openStorage
            // 
            this.openStorage.Name = "openStorage";
            this.openStorage.Size = new System.Drawing.Size(189, 22);
            this.openStorage.Text = "Открыть хранилище";
            this.openStorage.Click += new System.EventHandler(this.openStorage_Click);
            // 
            // createStorageFile
            // 
            this.createStorageFile.DefaultExt = "msh";
            this.createStorageFile.Filter = "Storage files|*.stor";
            // 
            // addFileInStorage
            // 
            this.addFileInStorage.Filter = "Все файлы|*.*";
            // 
            // openStorageFile
            // 
            this.openStorageFile.Filter = "Storage files|*.stor";
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStorage.Location = new System.Drawing.Point(12, 35);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(165, 17);
            this.labelStorage.TabIndex = 1;
            this.labelStorage.Text = "Текущее хранилище:";
            // 
            // labelStoragePath
            // 
            this.labelStoragePath.AutoSize = true;
            this.labelStoragePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStoragePath.Location = new System.Drawing.Point(173, 39);
            this.labelStoragePath.Name = "labelStoragePath";
            this.labelStoragePath.Size = new System.Drawing.Size(24, 13);
            this.labelStoragePath.TabIndex = 2;
            this.labelStoragePath.Text = "N/A";
            // 
            // contentStorage
            // 
            this.contentStorage.FormattingEnabled = true;
            this.contentStorage.Location = new System.Drawing.Point(15, 55);
            this.contentStorage.Name = "contentStorage";
            this.contentStorage.Size = new System.Drawing.Size(447, 290);
            this.contentStorage.TabIndex = 3;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(468, 55);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(114, 23);
            this.buttonAddFile.TabIndex = 4;
            this.buttonAddFile.Text = "Добавить файл";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // progressAdd
            // 
            this.progressAdd.Location = new System.Drawing.Point(15, 351);
            this.progressAdd.Name = "progressAdd";
            this.progressAdd.Size = new System.Drawing.Size(447, 23);
            this.progressAdd.Step = 1;
            this.progressAdd.TabIndex = 5;
            // 
            // ExtractFile
            // 
            this.ExtractFile.Location = new System.Drawing.Point(468, 84);
            this.ExtractFile.Name = "ExtractFile";
            this.ExtractFile.Size = new System.Drawing.Size(114, 23);
            this.ExtractFile.TabIndex = 6;
            this.ExtractFile.Text = "Извлечь файл";
            this.ExtractFile.UseVisualStyleBackColor = true;
            this.ExtractFile.Click += new System.EventHandler(this.testButton_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(468, 267);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(114, 20);
            this.passwordBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(468, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Пароль:";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(468, 322);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(114, 23);
            this.buttonDecrypt.TabIndex = 9;
            this.buttonDecrypt.Text = "Расшифровать";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonCrypt
            // 
            this.buttonCrypt.Location = new System.Drawing.Point(468, 293);
            this.buttonCrypt.Name = "buttonCrypt";
            this.buttonCrypt.Size = new System.Drawing.Size(114, 23);
            this.buttonCrypt.TabIndex = 10;
            this.buttonCrypt.Text = "Зашифровать";
            this.buttonCrypt.UseVisualStyleBackColor = true;
            this.buttonCrypt.Click += new System.EventHandler(this.buttonCrypt_Click);
            // 
            // decryptDialog
            // 
            this.decryptDialog.Filter = "Crypt storages|*.stcr";
            // 
            // SafeStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 375);
            this.Controls.Add(this.buttonCrypt);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.ExtractFile);
            this.Controls.Add(this.progressAdd);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.contentStorage);
            this.Controls.Add(this.labelStoragePath);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "SafeStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SafeStorage";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem newStorage;
        private System.Windows.Forms.SaveFileDialog createStorageFile;
        private System.Windows.Forms.OpenFileDialog addFileInStorage;
        private System.Windows.Forms.ToolStripMenuItem openStorage;
        private System.Windows.Forms.OpenFileDialog openStorageFile;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.Label labelStoragePath;
        private System.Windows.Forms.ListBox contentStorage;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.ProgressBar progressAdd;
        private System.Windows.Forms.Button ExtractFile;
        private System.Windows.Forms.SaveFileDialog extractFileDialog;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonCrypt;
        private System.Windows.Forms.OpenFileDialog decryptDialog;
    }
}

