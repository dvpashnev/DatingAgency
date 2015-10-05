using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DatingAgency
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      Icon = Resource1.Icon1;
      textBox_LastName.Focus();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        Regex templateRegex = new Regex("[А-Я][А-Яа-я-]+");
        if (textBox_LastName.Text == "")
        {
          throw new MyException(textBox_LastName, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (!templateRegex.IsMatch(textBox_LastName.Text))
        {
          throw new MyException(textBox_LastName, "Вы неправильно заполнили поле: {0}. Фамилия должна состоять из русских букв и начинаться с большой");
        }

        if (textBox_FirstName.Text == "")
        {
          throw new MyException(textBox_FirstName, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (!templateRegex.IsMatch(textBox_FirstName.Text))
        {
          throw new MyException(textBox_FirstName, "Вы неправильно заполнили поле: {0}. Имя должно состоять из русских букв и начинаться с большой");
        }

        if (textBox_MiddleName.Text == "")
        {
          throw new MyException(textBox_MiddleName, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (!templateRegex.IsMatch(textBox_MiddleName.Text))
        {
          throw new MyException(textBox_MiddleName, "Вы неправильно заполнили поле: {0}. Имя должно состоять из русских букв и начинаться с большой");
        }

        if (!radioButton1_Sex.Checked && !radioButton2_Sex.Checked)
        {
          throw new MyException(radioButton1_Sex, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (dateTimePicker_BirthDay.Value
          >= new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day))
        {
          throw new MyException(dateTimePicker_BirthDay, "Извините, Ваш возраст не позволяет быть нашим клиентом. Вам должно быть больше 18. Если Вы ошиблись, исправьте поле {0}");
        }

        if (textBox_Country.Text == "")
        {
          throw new MyException(textBox_Country, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (!templateRegex.IsMatch(textBox_Country.Text))
        {
          throw new MyException(textBox_Country, "Вы неправильно заполнили поле: {0}. Название страны должно состоять из русских букв и начинаться с большой");
        }

        if (textBox_City.Text == "")
        {
          throw new MyException(textBox_City, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (!templateRegex.IsMatch(textBox_City.Text))
        {
          throw new MyException(textBox_City, "Вы неправильно заполнили поле: {0}. Название города должно состоять из русских букв и начинаться с большой");
        }

        if (textBox_Height.Text == "")
        {
          throw new MyException(textBox_Height, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (textBox_Height.Text.Length > 1)
        {
          Regex templateHeight = new Regex("[0-3],[0-99]");

          if (!templateHeight.IsMatch(textBox_Height.Text))
          {
            throw new MyException(textBox_Height, "Вы неправильно заполнили поле: {0}. Рост нужно указывать цифрами, через запятую до 3 м");
          }
        }

        if (Convert.ToDouble(textBox_Height.Text) > 3)
        {
          throw new MyException(textBox_Height, "Вы неправильно заполнили поле: {0}. Наврядли Ваш рост больше 3 метров");
        }

        if (textBox_Weight.Text == "")
        {
          throw new MyException(textBox_Weight, "Вы не заполнили обязательное поле: {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (Convert.ToDouble(textBox_Weight.Text) < 30 || Convert.ToDouble(textBox_Weight.Text) > 300)
        {
          throw new MyException(textBox_Weight, "Вы неправильно заполнили поле: {0}. Вес нужно писать числом от 30 до 300");
        }

        if (comboBox_HairColor.SelectedIndex == -1)
        {
          throw new MyException(comboBox_HairColor, "Вы не выбрали {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }

        if (comboBox_EyesColor.SelectedIndex == -1)
        {
          throw new MyException(comboBox_EyesColor, "Вы не выбрали {0}. Если Вы не хотите добавлять клиента, нажмите \"Отменить\"");
        }
        Close();
      }
      catch (MyException myException)
      {
        Type ctrltype = myException.Data["controlType"] as Type;
        string typename = ctrltype.Name;
        string txtbxname = myException.Data["controlName"] as string;
        string parent = myException.Data["controlParent"] as string;

        if (Controls[parent] != this)
        {
          string lbltxt = (typename == "GroupBox" ? "groupBox" : "label") + txtbxname.Substring(txtbxname.LastIndexOf('_'));
          MessageBox.Show(String.Format(myException.Message, Controls[parent].Controls[lbltxt].Text));
          Controls[parent].Controls[txtbxname].Focus();
        }
        else
        {
          string lbltxt = (typename == "GroupBox" ? "groupBox" : "label") + txtbxname.Substring(txtbxname.LastIndexOf('_'));
          MessageBox.Show(String.Format(myException.Message, Controls[lbltxt].Text));
          Controls[txtbxname].Focus();
        }
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      CurrentClient.Value = null;
      Close();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      if (CurrentClient.Value != null)
      {
        textBox_LastName.DataBindings.Add("Text", CurrentClient.Value, "LastName");
        textBox_FirstName.DataBindings.Add("Text", CurrentClient.Value, "FirstName");
        textBox_MiddleName.DataBindings.Add("Text", CurrentClient.Value, "MiddleName");
        if (CurrentClient.Value.Sex == Gender.Man)
          radioButton1_Sex.Checked = true;
        else
          radioButton2_Sex.Checked = true;
        dateTimePicker_BirthDay.Value = CurrentClient.Value.BirthDay;
        textBox_Country.DataBindings.Add("Text", CurrentClient.Value, "Country");
        textBox_City.DataBindings.Add("Text", CurrentClient.Value, "City");
        textBox_Height.DataBindings.Add("Text", CurrentClient.Value, "Height");
        textBox_Weight.DataBindings.Add("Text", CurrentClient.Value, "Weight");
        comboBox_HairColor.SelectedIndex = (int)CurrentClient.Value.HairColor;
        comboBox_EyesColor.SelectedIndex = (int)CurrentClient.Value.EyesColor;
      }
      if (CurrentClient.Value.LastName == "")
      {
        radioButton1_Sex.Checked = false;
        textBox_Height.Text = "";
        textBox_Weight.Text = "";
        comboBox_HairColor.SelectedIndex = -1;
        comboBox_HairColor.Text = "Выберите цвет";
        comboBox_EyesColor.SelectedIndex = -1;
        comboBox_EyesColor.Text = "Выберите цвет";
      }
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.Sex = (sender as RadioButton).Checked ? Gender.Man : Gender.Woman;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.BirthDay = new DateTime(
        CurrentClient.Value.BirthDay.Year,
        CurrentClient.Value.BirthDay.Month,
        (int)((sender as ComboBox).SelectedItem)
        );
      CurrentClient.Value.ZodiacSing = ZodiacSing.GetZodiacSing(CurrentClient.Value.BirthDay);
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.BirthDay = new DateTime(
        CurrentClient.Value.BirthDay.Year,
        (sender as ComboBox).SelectedIndex + 1,
        CurrentClient.Value.BirthDay.Day
        );

      CurrentClient.Value.ZodiacSing = ZodiacSing.GetZodiacSing(CurrentClient.Value.BirthDay);
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.BirthDay = new DateTime(
        (int)(sender as ComboBox).SelectedItem,
        CurrentClient.Value.BirthDay.Month,
        CurrentClient.Value.BirthDay.Day
        );
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.HairColor = (HairColors)(sender as ComboBox).SelectedIndex;
    }

    private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.EyesColor = (EyesColors)(sender as ComboBox).SelectedIndex;
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
      CurrentClient.Value.BirthDay = (sender as DateTimePicker).Value;
      CurrentClient.Value.ZodiacSing = ZodiacSing.GetZodiacSing(CurrentClient.Value.BirthDay);
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void textBox_LastName_Validating(object sender, CancelEventArgs e)
    {
      Regex templateRegex = new Regex("[А-Я][А-Яа-я-]+");

      if (!templateRegex.IsMatch((sender as TextBox).Text))
      {
        errorProvider1.SetError((sender as TextBox), "Это поле должно заполняться русскими буквами и начинаться с большой");
      }
      else
        errorProvider1.SetError((sender as TextBox), String.Empty);

    }

    private void textBox_Height_Validating(object sender, CancelEventArgs e)
    {

      if ((sender as TextBox).Text.Length > 1)
      {
        Regex templateHeight = new Regex("[0-3],[0-99]");

        if (!templateHeight.IsMatch((sender as TextBox).Text))
        {
          errorProvider1.SetError((sender as TextBox), "Рост нужно указывать цифрами, через запятую до 3 м");
        }
        else
          errorProvider1.SetError((sender as TextBox), String.Empty);

        return;
      }

      float h;
      if (float.TryParse((sender as TextBox).Text, out h) && h > 3)
      {
        errorProvider1.SetError((sender as TextBox), "Наврядли Ваш рост больше 3 метров");
      }
      else
        errorProvider1.SetError((sender as TextBox), String.Empty);
    }

    private void textBox_Weight_Validating(object sender, CancelEventArgs e)
    {
      if (Convert.ToDouble((sender as TextBox).Text) < 30 || Convert.ToDouble((sender as TextBox).Text) > 300)
      {
        errorProvider1.SetError((sender as TextBox), "Вес нужно писать числом от 30 до 300");
      }
      else
        errorProvider1.SetError((sender as TextBox), String.Empty);
    }
  }
}
