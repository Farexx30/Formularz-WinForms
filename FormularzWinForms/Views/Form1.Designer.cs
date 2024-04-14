using System.Windows.Forms;

namespace FormularzWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DanePracownikaGroupBox = new GroupBox();
            DodajButton = new Button();
            RodzajUmowyLabel = new Label();
            Umowa3RadioButton = new RadioButton();
            Umowa2RadioButton = new RadioButton();
            Umowa1RadioButton = new RadioButton();
            StanowiskoLabel = new Label();
            StanowiskoComboBox = new ComboBox();
            PensjaLabel = new Label();
            PensjaNumericUpDown = new NumericUpDown();
            DataUrodzeniaDateTimePicker = new DateTimePicker();
            DataUrodzeniaLabel = new Label();
            NazwiskoLabel = new Label();
            ImieLabel = new Label();
            NazwiskoTextBox = new TextBox();
            ImieTextBox = new TextBox();
            ZapiszButton = new Button();
            WczytajButton = new Button();
            FormErrorProvider = new ErrorProvider(components);
            DataListBox = new ListBox();
            DanePracownikaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PensjaNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FormErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // DanePracownikaGroupBox
            // 
            DanePracownikaGroupBox.Controls.Add(DodajButton);
            DanePracownikaGroupBox.Controls.Add(RodzajUmowyLabel);
            DanePracownikaGroupBox.Controls.Add(Umowa3RadioButton);
            DanePracownikaGroupBox.Controls.Add(Umowa2RadioButton);
            DanePracownikaGroupBox.Controls.Add(Umowa1RadioButton);
            DanePracownikaGroupBox.Controls.Add(StanowiskoLabel);
            DanePracownikaGroupBox.Controls.Add(StanowiskoComboBox);
            DanePracownikaGroupBox.Controls.Add(PensjaLabel);
            DanePracownikaGroupBox.Controls.Add(PensjaNumericUpDown);
            DanePracownikaGroupBox.Controls.Add(DataUrodzeniaDateTimePicker);
            DanePracownikaGroupBox.Controls.Add(DataUrodzeniaLabel);
            DanePracownikaGroupBox.Controls.Add(NazwiskoLabel);
            DanePracownikaGroupBox.Controls.Add(ImieLabel);
            DanePracownikaGroupBox.Controls.Add(NazwiskoTextBox);
            DanePracownikaGroupBox.Controls.Add(ImieTextBox);
            DanePracownikaGroupBox.Location = new Point(18, 18);
            DanePracownikaGroupBox.Name = "DanePracownikaGroupBox";
            DanePracownikaGroupBox.Size = new Size(271, 340);
            DanePracownikaGroupBox.TabIndex = 0;
            DanePracownikaGroupBox.TabStop = false;
            DanePracownikaGroupBox.Text = "Dane Pracownika";
            // 
            // DodajButton
            // 
            DodajButton.Location = new Point(66, 302);
            DodajButton.Name = "DodajButton";
            DodajButton.Size = new Size(133, 23);
            DodajButton.TabIndex = 14;
            DodajButton.Text = "Dodaj";
            DodajButton.UseVisualStyleBackColor = true;
            DodajButton.Click += DodajButton_Click;
            // 
            // RodzajUmowyLabel
            // 
            RodzajUmowyLabel.AutoSize = true;
            RodzajUmowyLabel.Location = new Point(6, 213);
            RodzajUmowyLabel.Name = "RodzajUmowyLabel";
            RodzajUmowyLabel.Size = new Size(88, 15);
            RodzajUmowyLabel.TabIndex = 13;
            RodzajUmowyLabel.Text = "Rodzaj umowy:";
            // 
            // Umowa3RadioButton
            // 
            Umowa3RadioButton.AutoSize = true;
            Umowa3RadioButton.Font = new Font("Segoe UI", 7F);
            Umowa3RadioButton.Location = new Point(104, 263);
            Umowa3RadioButton.Name = "Umowa3RadioButton";
            Umowa3RadioButton.Size = new Size(95, 16);
            Umowa3RadioButton.TabIndex = 12;
            Umowa3RadioButton.TabStop = true;
            Umowa3RadioButton.Text = "Umowa zlecenie";
            Umowa3RadioButton.UseVisualStyleBackColor = true;
            // 
            // Umowa2RadioButton
            // 
            Umowa2RadioButton.AutoSize = true;
            Umowa2RadioButton.Font = new Font("Segoe UI", 7F);
            Umowa2RadioButton.Location = new Point(104, 238);
            Umowa2RadioButton.Name = "Umowa2RadioButton";
            Umowa2RadioButton.Size = new Size(138, 16);
            Umowa2RadioButton.TabIndex = 11;
            Umowa2RadioButton.TabStop = true;
            Umowa2RadioButton.Text = "Umowa na czas określony";
            Umowa2RadioButton.UseVisualStyleBackColor = true;
            // 
            // Umowa1RadioButton
            // 
            Umowa1RadioButton.AutoSize = true;
            Umowa1RadioButton.Checked = true;
            Umowa1RadioButton.Font = new Font("Segoe UI", 7F);
            Umowa1RadioButton.Location = new Point(104, 213);
            Umowa1RadioButton.Name = "Umowa1RadioButton";
            Umowa1RadioButton.Size = new Size(151, 16);
            Umowa1RadioButton.TabIndex = 10;
            Umowa1RadioButton.TabStop = true;
            Umowa1RadioButton.Text = "Umowa na czas nieokreślony";
            Umowa1RadioButton.UseVisualStyleBackColor = true;
            // 
            // StanowiskoLabel
            // 
            StanowiskoLabel.AutoSize = true;
            StanowiskoLabel.Location = new Point(6, 176);
            StanowiskoLabel.Name = "StanowiskoLabel";
            StanowiskoLabel.Size = new Size(70, 15);
            StanowiskoLabel.TabIndex = 9;
            StanowiskoLabel.Text = "Stanowisko:";
            // 
            // StanowiskoComboBox
            // 
            StanowiskoComboBox.FormattingEnabled = true;
            StanowiskoComboBox.Items.AddRange(new object[] { "Tester", "Projektant", "Inżynier", "Młodszy programista", "Starszy programista" });
            StanowiskoComboBox.Location = new Point(104, 173);
            StanowiskoComboBox.Name = "StanowiskoComboBox";
            StanowiskoComboBox.Size = new Size(151, 23);
            StanowiskoComboBox.TabIndex = 8;
            StanowiskoComboBox.SelectedIndex = 0;
            // 
            // PensjaLabel
            // 
            PensjaLabel.AutoSize = true;
            PensjaLabel.Location = new Point(6, 146);
            PensjaLabel.Name = "PensjaLabel";
            PensjaLabel.Size = new Size(44, 15);
            PensjaLabel.TabIndex = 7;
            PensjaLabel.Text = "Pensja:";
            // 
            // PensjaNumericUpDown
            // 
            PensjaNumericUpDown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            PensjaNumericUpDown.Location = new Point(104, 144);
            PensjaNumericUpDown.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            PensjaNumericUpDown.Minimum = new decimal(new int[] { 4000, 0, 0, 0 });
            PensjaNumericUpDown.Name = "PensjaNumericUpDown";
            PensjaNumericUpDown.Size = new Size(151, 23);
            PensjaNumericUpDown.TabIndex = 6;
            PensjaNumericUpDown.Tag = "";
            PensjaNumericUpDown.Value = new decimal(new int[] { 4000, 0, 0, 0 });
            // 
            // DataUrodzeniaDateTimePicker
            // 
            DataUrodzeniaDateTimePicker.CustomFormat = "dd.MM.yyyy";
            DataUrodzeniaDateTimePicker.Font = new Font("Segoe UI", 9F);
            DataUrodzeniaDateTimePicker.Format = DateTimePickerFormat.Custom;
            DataUrodzeniaDateTimePicker.Location = new Point(104, 99);
            DataUrodzeniaDateTimePicker.Name = "DataUrodzeniaDateTimePicker";
            DataUrodzeniaDateTimePicker.Size = new Size(151, 23);
            DataUrodzeniaDateTimePicker.TabIndex = 5;
            // 
            // DataUrodzeniaLabel
            // 
            DataUrodzeniaLabel.AutoSize = true;
            DataUrodzeniaLabel.Location = new Point(6, 105);
            DataUrodzeniaLabel.Name = "DataUrodzeniaLabel";
            DataUrodzeniaLabel.Size = new Size(89, 15);
            DataUrodzeniaLabel.TabIndex = 4;
            DataUrodzeniaLabel.Text = "Data urodzenia:";
            // 
            // NazwiskoLabel
            // 
            NazwiskoLabel.AutoSize = true;
            NazwiskoLabel.Location = new Point(6, 69);
            NazwiskoLabel.Name = "NazwiskoLabel";
            NazwiskoLabel.Size = new Size(60, 15);
            NazwiskoLabel.TabIndex = 3;
            NazwiskoLabel.Text = "Nazwisko:";
            // 
            // ImieLabel
            // 
            ImieLabel.AutoSize = true;
            ImieLabel.Location = new Point(6, 37);
            ImieLabel.Name = "ImieLabel";
            ImieLabel.Size = new Size(33, 15);
            ImieLabel.TabIndex = 2;
            ImieLabel.Text = "Imię:";
            // 
            // NazwiskoTextBox
            // 
            NazwiskoTextBox.Location = new Point(104, 66);
            NazwiskoTextBox.Name = "NazwiskoTextBox";
            NazwiskoTextBox.Size = new Size(151, 23);
            NazwiskoTextBox.TabIndex = 1;
            // 
            // ImieTextBox
            // 
            ImieTextBox.Location = new Point(104, 34);
            ImieTextBox.Name = "ImieTextBox";
            ImieTextBox.Size = new Size(151, 23);
            ImieTextBox.TabIndex = 0;
            // 
            // ZapiszButton
            // 
            ZapiszButton.Location = new Point(24, 371);
            ZapiszButton.Name = "ZapiszButton";
            ZapiszButton.Size = new Size(95, 23);
            ZapiszButton.TabIndex = 1;
            ZapiszButton.Text = "Zapisz";
            ZapiszButton.UseVisualStyleBackColor = true;
            ZapiszButton.Click += ZapiszButton_Click;
            // 
            // WczytajButton
            // 
            WczytajButton.Location = new Point(181, 371);
            WczytajButton.Name = "WczytajButton";
            WczytajButton.Size = new Size(95, 23);
            WczytajButton.TabIndex = 2;
            WczytajButton.Text = "Wczytaj";
            WczytajButton.UseVisualStyleBackColor = true;
            WczytajButton.Click += WczytajButton_Click;
            // 
            // FormErrorProvider
            // 
            FormErrorProvider.ContainerControl = this;
            // 
            // DataListBox
            // 
            DataListBox.Font = new Font("Segoe UI", 16F);
            DataListBox.FormattingEnabled = true;
            DataListBox.HorizontalScrollbar = true;
            DataListBox.ItemHeight = 30;
            DataListBox.Location = new Point(304, 25);
            DataListBox.Name = "DataListBox";
            DataListBox.Size = new Size(482, 334);
            DataListBox.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataListBox);
            Controls.Add(WczytajButton);
            Controls.Add(ZapiszButton);
            Controls.Add(DanePracownikaGroupBox);
            Name = "Form1";
            Text = "Form1";
            DanePracownikaGroupBox.ResumeLayout(false);
            DanePracownikaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PensjaNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)FormErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox DanePracownikaGroupBox;
        private Label ImieLabel;
        private TextBox NazwiskoTextBox;
        private TextBox ImieTextBox;
        private Label DataUrodzeniaLabel;
        private Label NazwiskoLabel;
        private DateTimePicker DataUrodzeniaDateTimePicker;
        private Label PensjaLabel;
        private NumericUpDown PensjaNumericUpDown;
        private Label StanowiskoLabel;
        private ComboBox StanowiskoComboBox;
        private RadioButton Umowa3RadioButton;
        private RadioButton Umowa2RadioButton;
        private RadioButton Umowa1RadioButton;
        private Label RodzajUmowyLabel;
        private Button DodajButton;
        private Button ZapiszButton;
        private Button WczytajButton;
        private ErrorProvider FormErrorProvider;
        private ListBox DataListBox;
    }
}
