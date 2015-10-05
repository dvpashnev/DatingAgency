namespace DatingAgency
{
  partial class Form2
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.comboBox_EyesColor = new System.Windows.Forms.ComboBox();
      this.comboBox_HairColor = new System.Windows.Forms.ComboBox();
      this.textBox_Weight = new System.Windows.Forms.TextBox();
      this.textBox_Height = new System.Windows.Forms.TextBox();
      this.label_EyesColor = new System.Windows.Forms.Label();
      this.label_HairColor = new System.Windows.Forms.Label();
      this.label_Weight = new System.Windows.Forms.Label();
      this.label_Height = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.textBox_LastName = new System.Windows.Forms.TextBox();
      this.dateTimePicker_BirthDay = new System.Windows.Forms.DateTimePicker();
      this.radioButton2_Sex = new System.Windows.Forms.RadioButton();
      this.radioButton1_Sex = new System.Windows.Forms.RadioButton();
      this.textBox_MiddleName = new System.Windows.Forms.TextBox();
      this.textBox_FirstName = new System.Windows.Forms.TextBox();
      this.label_Sex = new System.Windows.Forms.Label();
      this.label_BirthDay = new System.Windows.Forms.Label();
      this.label_MiddleName = new System.Windows.Forms.Label();
      this.label_FirstName = new System.Windows.Forms.Label();
      this.label_LastName = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textBox_City = new System.Windows.Forms.TextBox();
      this.label_City = new System.Windows.Forms.Label();
      this.label_Country = new System.Windows.Forms.Label();
      this.textBox_Country = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.comboBox_EyesColor);
      this.groupBox3.Controls.Add(this.comboBox_HairColor);
      this.groupBox3.Controls.Add(this.textBox_Weight);
      this.groupBox3.Controls.Add(this.textBox_Height);
      this.groupBox3.Controls.Add(this.label_EyesColor);
      this.groupBox3.Controls.Add(this.label_HairColor);
      this.groupBox3.Controls.Add(this.label_Weight);
      this.groupBox3.Controls.Add(this.label_Height);
      this.groupBox3.Location = new System.Drawing.Point(359, 12);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(232, 143);
      this.groupBox3.TabIndex = 36;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Внешность";
      // 
      // comboBox_EyesColor
      // 
      this.comboBox_EyesColor.FormattingEnabled = true;
      this.comboBox_EyesColor.Items.AddRange(new object[] {
            "Синий",
            "Голубой",
            "Серый",
            "Зелёный",
            "Янтарный",
            "Болотный",
            "Карий",
            "Чёрный",
            "Жёлтый"});
      this.comboBox_EyesColor.Location = new System.Drawing.Point(83, 111);
      this.comboBox_EyesColor.Name = "comboBox_EyesColor";
      this.comboBox_EyesColor.Size = new System.Drawing.Size(124, 21);
      this.comboBox_EyesColor.TabIndex = 11;
      this.comboBox_EyesColor.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
      // 
      // comboBox_HairColor
      // 
      this.comboBox_HairColor.FormattingEnabled = true;
      this.comboBox_HairColor.Items.AddRange(new object[] {
            "блондин - белые, светлые",
            "русый - светло-коричневые",
            "шатен - коричневые",
            "брюнет - черные"});
      this.comboBox_HairColor.Location = new System.Drawing.Point(83, 84);
      this.comboBox_HairColor.Name = "comboBox_HairColor";
      this.comboBox_HairColor.Size = new System.Drawing.Size(124, 21);
      this.comboBox_HairColor.TabIndex = 10;
      this.comboBox_HairColor.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
      // 
      // textBox_Weight
      // 
      this.textBox_Weight.Location = new System.Drawing.Point(83, 54);
      this.textBox_Weight.Name = "textBox_Weight";
      this.textBox_Weight.Size = new System.Drawing.Size(124, 20);
      this.textBox_Weight.TabIndex = 9;
      this.textBox_Weight.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Weight_Validating);
      // 
      // textBox_Height
      // 
      this.textBox_Height.Location = new System.Drawing.Point(83, 24);
      this.textBox_Height.Name = "textBox_Height";
      this.textBox_Height.Size = new System.Drawing.Size(124, 20);
      this.textBox_Height.TabIndex = 8;
      this.textBox_Height.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Height_Validating);
      // 
      // label_EyesColor
      // 
      this.label_EyesColor.AutoSize = true;
      this.label_EyesColor.Location = new System.Drawing.Point(14, 116);
      this.label_EyesColor.Name = "label_EyesColor";
      this.label_EyesColor.Size = new System.Drawing.Size(58, 13);
      this.label_EyesColor.TabIndex = 13;
      this.label_EyesColor.Text = "Цвет глаз";
      // 
      // label_HairColor
      // 
      this.label_HairColor.AutoSize = true;
      this.label_HairColor.Location = new System.Drawing.Point(14, 87);
      this.label_HairColor.Name = "label_HairColor";
      this.label_HairColor.Size = new System.Drawing.Size(65, 13);
      this.label_HairColor.TabIndex = 12;
      this.label_HairColor.Text = "Цвет волос";
      // 
      // label_Weight
      // 
      this.label_Weight.AutoSize = true;
      this.label_Weight.Location = new System.Drawing.Point(14, 57);
      this.label_Weight.Name = "label_Weight";
      this.label_Weight.Size = new System.Drawing.Size(26, 13);
      this.label_Weight.TabIndex = 11;
      this.label_Weight.Text = "Вес";
      // 
      // label_Height
      // 
      this.label_Height.AutoSize = true;
      this.label_Height.Location = new System.Drawing.Point(14, 27);
      this.label_Height.Name = "label_Height";
      this.label_Height.Size = new System.Drawing.Size(31, 13);
      this.label_Height.TabIndex = 10;
      this.label_Height.Text = "Рост";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.textBox_LastName);
      this.groupBox2.Controls.Add(this.dateTimePicker_BirthDay);
      this.groupBox2.Controls.Add(this.radioButton2_Sex);
      this.groupBox2.Controls.Add(this.radioButton1_Sex);
      this.groupBox2.Controls.Add(this.textBox_MiddleName);
      this.groupBox2.Controls.Add(this.textBox_FirstName);
      this.groupBox2.Controls.Add(this.label_Sex);
      this.groupBox2.Controls.Add(this.label_BirthDay);
      this.groupBox2.Controls.Add(this.label_MiddleName);
      this.groupBox2.Controls.Add(this.label_FirstName);
      this.groupBox2.Controls.Add(this.label_LastName);
      this.groupBox2.Location = new System.Drawing.Point(9, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(332, 191);
      this.groupBox2.TabIndex = 35;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Личные данные";
      // 
      // textBox_LastName
      // 
      this.textBox_LastName.Location = new System.Drawing.Point(66, 28);
      this.textBox_LastName.Name = "textBox_LastName";
      this.textBox_LastName.Size = new System.Drawing.Size(245, 20);
      this.textBox_LastName.TabIndex = 1;
      this.textBox_LastName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_LastName_Validating);
      // 
      // dateTimePicker_BirthDay
      // 
      this.dateTimePicker_BirthDay.Location = new System.Drawing.Point(67, 151);
      this.dateTimePicker_BirthDay.Name = "dateTimePicker_BirthDay";
      this.dateTimePicker_BirthDay.Size = new System.Drawing.Size(200, 20);
      this.dateTimePicker_BirthDay.TabIndex = 5;
      this.dateTimePicker_BirthDay.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
      // 
      // radioButton2_Sex
      // 
      this.radioButton2_Sex.AutoSize = true;
      this.radioButton2_Sex.Location = new System.Drawing.Point(157, 124);
      this.radioButton2_Sex.Name = "radioButton2_Sex";
      this.radioButton2_Sex.Size = new System.Drawing.Size(72, 17);
      this.radioButton2_Sex.TabIndex = 14;
      this.radioButton2_Sex.TabStop = true;
      this.radioButton2_Sex.Text = "Женский";
      this.radioButton2_Sex.UseVisualStyleBackColor = true;
      // 
      // radioButton1_Sex
      // 
      this.radioButton1_Sex.AutoSize = true;
      this.radioButton1_Sex.Location = new System.Drawing.Point(67, 124);
      this.radioButton1_Sex.Name = "radioButton1_Sex";
      this.radioButton1_Sex.Size = new System.Drawing.Size(71, 17);
      this.radioButton1_Sex.TabIndex = 4;
      this.radioButton1_Sex.TabStop = true;
      this.radioButton1_Sex.Text = "Мужской";
      this.radioButton1_Sex.UseVisualStyleBackColor = true;
      this.radioButton1_Sex.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
      // 
      // textBox_MiddleName
      // 
      this.textBox_MiddleName.Location = new System.Drawing.Point(66, 94);
      this.textBox_MiddleName.Name = "textBox_MiddleName";
      this.textBox_MiddleName.Size = new System.Drawing.Size(245, 20);
      this.textBox_MiddleName.TabIndex = 3;
      this.textBox_MiddleName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_LastName_Validating);
      // 
      // textBox_FirstName
      // 
      this.textBox_FirstName.Location = new System.Drawing.Point(66, 61);
      this.textBox_FirstName.Name = "textBox_FirstName";
      this.textBox_FirstName.Size = new System.Drawing.Size(245, 20);
      this.textBox_FirstName.TabIndex = 2;
      this.textBox_FirstName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_LastName_Validating);
      // 
      // label_Sex
      // 
      this.label_Sex.AutoSize = true;
      this.label_Sex.Location = new System.Drawing.Point(4, 126);
      this.label_Sex.Name = "label_Sex";
      this.label_Sex.Size = new System.Drawing.Size(27, 13);
      this.label_Sex.TabIndex = 9;
      this.label_Sex.Text = "Пол";
      // 
      // label_BirthDay
      // 
      this.label_BirthDay.AutoSize = true;
      this.label_BirthDay.Location = new System.Drawing.Point(4, 151);
      this.label_BirthDay.Name = "label_BirthDay";
      this.label_BirthDay.Size = new System.Drawing.Size(57, 26);
      this.label_BirthDay.TabIndex = 8;
      this.label_BirthDay.Text = "Дата\r\nрождения";
      // 
      // label_MiddleName
      // 
      this.label_MiddleName.AutoSize = true;
      this.label_MiddleName.Location = new System.Drawing.Point(4, 94);
      this.label_MiddleName.Name = "label_MiddleName";
      this.label_MiddleName.Size = new System.Drawing.Size(54, 13);
      this.label_MiddleName.TabIndex = 5;
      this.label_MiddleName.Text = "Отчество";
      // 
      // label_FirstName
      // 
      this.label_FirstName.AutoSize = true;
      this.label_FirstName.Location = new System.Drawing.Point(4, 64);
      this.label_FirstName.Name = "label_FirstName";
      this.label_FirstName.Size = new System.Drawing.Size(29, 13);
      this.label_FirstName.TabIndex = 4;
      this.label_FirstName.Text = "Имя";
      // 
      // label_LastName
      // 
      this.label_LastName.AutoSize = true;
      this.label_LastName.Location = new System.Drawing.Point(4, 31);
      this.label_LastName.Name = "label_LastName";
      this.label_LastName.Size = new System.Drawing.Size(56, 13);
      this.label_LastName.TabIndex = 2;
      this.label_LastName.Text = "Фамилия";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textBox_City);
      this.groupBox1.Controls.Add(this.label_City);
      this.groupBox1.Controls.Add(this.label_Country);
      this.groupBox1.Controls.Add(this.textBox_Country);
      this.groupBox1.Location = new System.Drawing.Point(9, 209);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(332, 81);
      this.groupBox1.TabIndex = 34;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Местонахождение";
      // 
      // textBox_City
      // 
      this.textBox_City.Location = new System.Drawing.Point(66, 48);
      this.textBox_City.Name = "textBox_City";
      this.textBox_City.Size = new System.Drawing.Size(245, 20);
      this.textBox_City.TabIndex = 7;
      this.textBox_City.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_LastName_Validating);
      // 
      // label_City
      // 
      this.label_City.AutoSize = true;
      this.label_City.Location = new System.Drawing.Point(9, 51);
      this.label_City.Name = "label_City";
      this.label_City.Size = new System.Drawing.Size(37, 13);
      this.label_City.TabIndex = 7;
      this.label_City.Text = "Город";
      // 
      // label_Country
      // 
      this.label_Country.AutoSize = true;
      this.label_Country.Location = new System.Drawing.Point(10, 18);
      this.label_Country.Name = "label_Country";
      this.label_Country.Size = new System.Drawing.Size(43, 13);
      this.label_Country.TabIndex = 6;
      this.label_Country.Text = "Страна";
      // 
      // textBox_Country
      // 
      this.textBox_Country.Location = new System.Drawing.Point(66, 18);
      this.textBox_Country.Name = "textBox_Country";
      this.textBox_Country.Size = new System.Drawing.Size(245, 20);
      this.textBox_Country.TabIndex = 6;
      this.textBox_Country.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_LastName_Validating);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(400, 267);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 12;
      this.button1.Text = "Сохранить";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(502, 267);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 38;
      this.button2.Text = "Отменить";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(612, 302);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form2";
      this.Text = "Новый клиент/Редактирование";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label_EyesColor;
    private System.Windows.Forms.Label label_HairColor;
    private System.Windows.Forms.Label label_Weight;
    private System.Windows.Forms.Label label_Height;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label_Sex;
    private System.Windows.Forms.Label label_BirthDay;
    private System.Windows.Forms.Label label_MiddleName;
    private System.Windows.Forms.Label label_FirstName;
    private System.Windows.Forms.Label label_LastName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label_City;
    private System.Windows.Forms.Label label_Country;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox_Weight;
    private System.Windows.Forms.TextBox textBox_Height;
    private System.Windows.Forms.RadioButton radioButton2_Sex;
    private System.Windows.Forms.RadioButton radioButton1_Sex;
    private System.Windows.Forms.TextBox textBox_MiddleName;
    private System.Windows.Forms.TextBox textBox_FirstName;
    private System.Windows.Forms.TextBox textBox_LastName;
    private System.Windows.Forms.TextBox textBox_City;
    private System.Windows.Forms.TextBox textBox_Country;
    private System.Windows.Forms.ComboBox comboBox_EyesColor;
    private System.Windows.Forms.ComboBox comboBox_HairColor;
    private System.Windows.Forms.DateTimePicker dateTimePicker_BirthDay;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}