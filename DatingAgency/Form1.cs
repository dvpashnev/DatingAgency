using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DatingAgency
{
  [Serializable]
  public partial class Form1 : Form
  {
    [XmlArray("Collection"), XmlArrayItem("Item")]
    private BindingList<Client> _clients;
    private BindingSource _bs;

    private string fileName = "Clients.xml";

    private Label lbFirstCriteria;
    private ComboBox tbFirstCriteria;
    private Button clearFC;
    private Label lbSecondCriteria;
    private ComboBox tbSecondCriteria;
    private Button clearSC;
    private Button endFinding;
    private TextBox tbFirstCriteriaHeight;
    private Label lbBetweenHeight;
    private TextBox tbSecondCriteriaHeight;
    private Button clearFCS;
    private TextBox tbFirstCriteriaWeight;
    private Label lbBetweenWeight;
    private TextBox tbSecondCriteriaWeight;
    private Button clearSCS;

    public Form1()
    {
      InitializeComponent();
      Icon = Resource1.Icon1;
      _clients = new BindingList<Client>();
      /*
      _clients.Add(new Client(1, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 2, 13), Gender.Man, "Ukraine", "Kharkiv", 1.8f, 80f, HairColors.Brunet, EyesColors.Blue));
      _clients.Add(new Client(2, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 3, 13), Gender.Man, "USA", "New-York", 1.5f, 66f, HairColors.Brunet, EyesColors.Blue));
      _clients.Add(new Client(3, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 4, 13), Gender.Man, "Ukraine", "Kharkiv", 1.6f, 55f, HairColors.Brunet, EyesColors.Blue));
      _clients.Add(new Client(4, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 5, 13), Gender.Man, "Ukraine", "Kharkiv", 1.8f, 89f, HairColors.Brunet, EyesColors.Blue));
      _clients.Add(new Client(5, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 6, 13), Gender.Man, "Ukraine", "Kharkiv", 1.6f, 80f, HairColors.Brunet, EyesColors.Blue));
      _clients.Add(new Client(6, "Pupkin", "Ivan", "Andreevich", new DateTime(1989, 7, 13), Gender.Man, "USA", "New-York", 1.8f, 80f, HairColors.Brunet, EyesColors.Blue));
      */

    }

    void _bs_PositionChanged(object sender, EventArgs e)
    {
      button2.Enabled = _bs.Position >= 0 ? true : false;
      button3.Enabled = _bs.Position >= 0 ? true : false;
      comboBox4.Enabled = _bs.Position >= 0 ? true : false;
    }

    private void Bindings()
    {
      if (label13.DataBindings.Count != 0)
      {
        label13.DataBindings.Clear();
        label14.DataBindings.Clear();
        label15.DataBindings.Clear();
        label16.DataBindings.Clear();
        label17.DataBindings.Clear();
        label18.DataBindings.Clear();
        label19.DataBindings.Clear();
        label20.DataBindings.Clear();
        label21.DataBindings.Clear();
        label22.DataBindings.Clear();
        label23.DataBindings.Clear();
        label12.DataBindings.Clear();
      }

      label13.DataBindings.Add("Text", _bs, "LastName");
      label14.DataBindings.Add("Text", _bs, "FirstName");
      label15.DataBindings.Add("Text", _bs, "MiddleName");
      label16.DataBindings.Add("Text", _bs, "Sex");
      label17.DataBindings.Add("Text", _bs, "BirthDay", true, DataSourceUpdateMode.OnPropertyChanged);
      label18.DataBindings.Add("Text", _bs, "Country");
      label19.DataBindings.Add("Text", _bs, "City");
      label20.DataBindings.Add("Text", _bs, "Height", true);
      label21.DataBindings.Add("Text", _bs, "Weight");
      label22.DataBindings.Add("Text", _bs, "HairColor");
      label23.DataBindings.Add("Text", _bs, "EyesColor");
      label12.DataBindings.Add("Text", _bs, "ZodiacSing");
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void label12_TextChanged(object sender, EventArgs e)
    {
      pictureBox1.Image = imageList1.Images[(sender as Label).Text + ".jpg"];
    }

    void readDataFromAnotherFile()
    {
      StreamReader sr = new StreamReader(openFileDialog1.OpenFile());
      fileName = openFileDialog1.FileName;
      XmlSerializer xs = new XmlSerializer(typeof(BindingList<Client>));
      _clients = (BindingList<Client>)xs.Deserialize(sr);
      sr.Close();
    }

    void readData()
    {
      try
      {
        FileStream fs = new FileStream(fileName, FileMode.Open);
        XmlSerializer xs = new XmlSerializer(typeof(BindingList<Client>));
        _clients = (BindingList<Client>)xs.Deserialize(fs);
        fs.Close();
        if (_clients.Count == 0)
        {
          throw new Exception();
        }
      }
      catch
      {
        if (MessageBox.Show("Файл с базой отсутствует или пуст. Если Вы желаете открыть другой файл, нажмите Да. Если хотите запустить программу с пустой базой - Нет.",
          "База клиентов отсутствует", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          if (openFileDialog1.ShowDialog() == DialogResult.OK)
          {
            readDataFromAnotherFile();
          }
          else
          {
            fileName = "";
          }
        }
        else
        {
          fileName = "";
        }
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      timer1.Enabled = true;
      DialogResult res =
        MessageBox.Show(
          "Выберите:\nОткрыть базу по умолчанию - Да.\nОткрыть другую базу - Нет.\nОткрыть пустую базу - Отменить.",
          "Открытие базы",
          MessageBoxButtons.YesNoCancel);
      if (res == DialogResult.Yes)
      {
        readData();
      }
      else if (res == DialogResult.No)
      {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          readDataFromAnotherFile();
        }
        else
        {
          fileName = "";
        }
      }
      else if (res == DialogResult.Cancel)
      {
        fileName = "";
      }
      newBase();
      button2.Enabled = _clients.Count > 0 ? true : false;
      button3.Enabled = _clients.Count > 0 ? true : false;
      comboBox4.Enabled = _clients.Count > 0 ? true : false;

    }

    void newBase()
    {
      _bs = new BindingSource { DataSource = _clients };
      dataGridView1.DataSource = _bs;
      bindingNavigator1.BindingSource = _bs;
      _bs.PositionChanged += _bs_PositionChanged;
      Bindings();
    }

    void saveData()
    {
      if (fileName != "")
      {
        FileStream fs = new FileStream(fileName, FileMode.Create);
        XmlSerializer xs = new XmlSerializer(typeof(BindingList<Client>));
        xs.Serialize(fs, _clients);
        fs.Close();
      } else while (fileName == "")
      {
        saveAsToolStripMenuItem_Click(saveAsToolStripMenuItem, new EventArgs());
        if (fileName == "")
        {
          DialogResult res = MessageBox.Show("Выйти, не сохраняя новую базу?",
            "Подтверждение", MessageBoxButtons.YesNo);
          if (res == DialogResult.Yes)
          {
            break;
          }
        }
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (fileName != "")
        saveData(); 
      while (fileName == "")
      {
        saveAsToolStripMenuItem_Click(saveAsToolStripMenuItem, new EventArgs());
        if (fileName == "")
        {
          DialogResult res = MessageBox.Show("Вы уверены, что хотите выйти без сохранения?",
            "Подтверждение", MessageBoxButtons.YesNoCancel);
          if (res == DialogResult.Yes)
          {
            break;
          } else if (res == DialogResult.Cancel)
          {
            e.Cancel = true;
            break;
          }
        }
      }

    }

    private void button1_Click(object sender, EventArgs e)
    {
      CurrentClient.Value = new Client();
      Form2 f2 = new Form2();
      f2.ShowDialog();
      if (CurrentClient.Value != null)
      {
        if (_clients.Count == 0)
        {
          CurrentClient.Value.ID = 1;
        }
        else
        {
          CurrentClient.Value.ID = _clients[_clients.Count - 1].ID + 1;
        }
        _clients.Add(CurrentClient.Value);
      }
      dataGridView1.Refresh();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (!(_bs.Position >= 0))
      {
        return;
      }
      CurrentClient.Value = new Client(_clients[_bs.Position]);
      Form2 f2 = new Form2();
      f2.ShowDialog();
      if (CurrentClient.Value == null)
      {
        return;
      }
      else
      {
        _clients[_bs.Position] = CurrentClient.Value;
      }
      dataGridView1.Refresh();
      Invalidate();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Вы уверены?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
        return;
      if (_bs.Position >= 0)
        _clients.Remove(_clients[_bs.Position]);
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      hidingFields();
      switch ((sender as ComboBox).SelectedIndex)
      {
        case 0:
          {
            Point loc = new Point(comboBox1.Location.X, comboBox1.Location.Y - 10);
            lbFirstCriteria = new Label
            {
              Name = "lbFirstCriteria",
              Text = "Страна",
              Size = new Size(50, 13),
              Location = loc
            };
            tbFirstCriteria = new ComboBox
            {
              Name = "tbFirstCriteria",
              Text = "Выберите страну",
              Location = new Point(loc.X + lbFirstCriteria.Size.Width, loc.Y),
              Size = new Size(100, 13),
              DropDownStyle = ComboBoxStyle.DropDownList
            };
            clearFC = new Button
            {
              Name = "clearFC",
              Text = "X",
              Location = new Point(tbFirstCriteria.Location.X + tbFirstCriteria.Size.Width, tbFirstCriteria.Location.Y),
              Size = new Size(20, 20)
            };
            var res = (from c in _clients select c.Country).Distinct().ToArray();
            tbFirstCriteria.Items.AddRange(res);
            tbFirstCriteria.Text = "Выберите страну";

            lbSecondCriteria = new Label
            {
              Name = "lbSecondCriteria",
              Text = "Город",
              Size = new Size(50, 13),
              Location = new Point(loc.X, loc.Y + 30)
            };
            tbSecondCriteria = new ComboBox
            {
              Name = "tbSecondCriteria",
              Text = "Выберите город",
              Location = new Point(loc.X + lbSecondCriteria.Size.Width, loc.Y + 30),
              Size = new Size(100, 13),
              DropDownStyle = ComboBoxStyle.DropDownList
            };
            clearSC = new Button
            {
              Name = "clearSC",
              Text = "X",
              Location = new Point(tbSecondCriteria.Location.X + tbSecondCriteria.Size.Width, tbSecondCriteria.Location.Y),
              Size = new Size(20, 20)
            };
            res = (from c in _clients select c.City).Distinct().ToArray();
            tbSecondCriteria.Items.AddRange(res);
            tbSecondCriteria.Text = "Выберите город";

            lbFirstCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbFirstCriteria);
            tbFirstCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(tbFirstCriteria);
            clearFC.Parent = groupBox4;
            groupBox4.Controls.Add(clearFC);
            lbSecondCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbSecondCriteria);
            tbSecondCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(tbSecondCriteria);
            clearSC.Parent = groupBox4;
            groupBox4.Controls.Add(clearSC);
            tbFirstCriteria.SelectedIndexChanged += tbFirstCriteria_SelectedIndexChanged;
            tbSecondCriteria.SelectedIndexChanged += tbSecondCriteria_SelectedIndexChanged;
            clearFC.Click += clearFC_Click;
            clearSC.Click += clearSC_Click;
            comboBox1.Hide();
          }
          break;
        case 1:// Height Weight
          {
            Point loc = new Point(comboBox1.Location.X, comboBox1.Location.Y - 10);
            lbFirstCriteria = new Label
            {
              Name = "lbFirstCriteria",
              Text = "Рост от",
              Size = new Size(45, 13),
              Location = loc
            };
            tbFirstCriteriaHeight = new TextBox
            {
              Name = "tbFirstCriteriaHeight",
              Location = new Point(loc.X + lbFirstCriteria.Size.Width, loc.Y),
              Size = new Size(30, 13)
            };
            clearFC = new Button
            {
              Name = "clearFC",
              Text = "X",
              Location = new Point(tbFirstCriteriaHeight.Location.X + tbFirstCriteriaHeight.Size.Width, tbFirstCriteriaHeight.Location.Y),
              Size = new Size(20, 20)
            };
            lbBetweenHeight = new Label
            {
              Name = "lbBetweenHeight",
              Text = "до",
              Size = new Size(20, 13),
              Location = new Point(clearFC.Location.X + clearFC.Size.Width, clearFC.Location.Y),
            };
            tbSecondCriteriaHeight = new TextBox
            {
              Name = "tbSecondCriteriaHeight",
              Location = new Point(lbBetweenHeight.Location.X + lbBetweenHeight.Size.Width, lbBetweenHeight.Location.Y),
              Size = new Size(30, 13)
            };
            clearFCS = new Button
            {
              Name = "clearFCS",
              Text = "X",
              Location = new Point(tbSecondCriteriaHeight.Location.X + tbSecondCriteriaHeight.Size.Width, tbSecondCriteriaHeight.Location.Y),
              Size = new Size(20, 20)
            };

            lbSecondCriteria = new Label
            {
              Name = "lbSecondCriteria",
              Text = "Вес от",
              Size = new Size(45, 13),
              Location = new Point(loc.X, loc.Y + 30)
            };
            tbFirstCriteriaWeight = new TextBox
            {
              Name = "tbSecondCriteria",
              Location = new Point(loc.X + lbSecondCriteria.Size.Width, loc.Y + 30),
              Size = new Size(30, 13)
            };
            clearSC = new Button
            {
              Name = "clearSC",
              Text = "X",
              Location = new Point(tbFirstCriteriaWeight.Location.X + tbFirstCriteriaWeight.Size.Width, tbFirstCriteriaWeight.Location.Y),
              Size = new Size(20, 20)
            };
            lbBetweenWeight = new Label
            {
              Name = "lbBetweenWeight",
              Text = "до",
              Size = new Size(20, 13),
              Location = new Point(clearSC.Location.X + clearSC.Size.Width, clearSC.Location.Y),
            };
            tbSecondCriteriaWeight = new TextBox
            {
              Name = "tbSecondCriteriaWeight",
              Location = new Point(lbBetweenWeight.Location.X + lbBetweenWeight.Size.Width, lbBetweenWeight.Location.Y),
              Size = new Size(30, 13)
            };
            clearSCS = new Button
            {
              Name = "clearSCS",
              Text = "X",
              Location = new Point(tbSecondCriteriaWeight.Location.X + tbSecondCriteriaWeight.Size.Width, tbSecondCriteriaWeight.Location.Y),
              Size = new Size(20, 20)
            };

            lbFirstCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbFirstCriteria);
            tbFirstCriteriaHeight.Parent = groupBox4;
            groupBox4.Controls.Add(tbFirstCriteriaHeight);
            clearFC.Parent = groupBox4;
            groupBox4.Controls.Add(clearFC);
            lbBetweenHeight.Parent = groupBox4;
            groupBox4.Controls.Add(lbBetweenHeight);
            tbSecondCriteriaHeight.Parent = groupBox4;
            groupBox4.Controls.Add(tbSecondCriteriaHeight);
            clearFCS.Parent = groupBox4;
            groupBox4.Controls.Add(clearFCS);

            lbSecondCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbSecondCriteria);
            tbFirstCriteriaWeight.Parent = groupBox4;
            groupBox4.Controls.Add(tbFirstCriteriaWeight);
            clearSC.Parent = groupBox4;
            groupBox4.Controls.Add(clearSC);
            lbBetweenWeight.Parent = groupBox4;
            groupBox4.Controls.Add(lbBetweenWeight);
            tbSecondCriteriaWeight.Parent = groupBox4;
            groupBox4.Controls.Add(tbSecondCriteriaWeight);
            clearSCS.Parent = groupBox4;
            groupBox4.Controls.Add(clearSCS);

            tbFirstCriteriaHeight.TextChanged += tbFirstCriteriaHeight_TextChanged;
            tbFirstCriteriaWeight.TextChanged += tbFirstCriteriaWeight_TextChanged;
            tbSecondCriteriaHeight.TextChanged += tbSecondCriteriaHeight_TextChanged;
            tbSecondCriteriaWeight.TextChanged += tbSecondCriteriaWeight_TextChanged;
            clearFC.Click += clearFC_Click;
            clearSC.Click += clearSC_Click;
            clearFCS.Click += clearFCS_Click;
            clearSCS.Click += clearSCS_Click;
            comboBox1.Hide();

          }
          break;
        case 2:
          {
            Point loc = new Point(comboBox1.Location.X, comboBox1.Location.Y - 10);
            lbFirstCriteria = new Label
            {
              Name = "lbFirstCriteria",
              Text = "Волосы",
              Size = new Size(50, 13),
              Location = loc
            };
            tbFirstCriteria = new ComboBox
            {
              Name = "tbFirstCriteria",
              Text = "Выберите цвет",
              Location = new Point(loc.X + lbFirstCriteria.Size.Width, loc.Y),
              Size = new Size(100, 13),
              DropDownStyle = ComboBoxStyle.DropDownList
            };
            clearFC = new Button
            {
              Name = "clearFC",
              Text = "X",
              Location = new Point(tbFirstCriteria.Location.X + tbFirstCriteria.Size.Width, tbFirstCriteria.Location.Y),
              Size = new Size(20, 20)
            };
            tbFirstCriteria.Items.AddRange(new object[]{
                "блондин - белые, светлые",
                "русый - светло-коричневые",
                "шатен - коричневые",
                "брюнет - черные"});
            tbFirstCriteria.Text = "Выберите цвет";

            lbSecondCriteria = new Label
            {
              Name = "lbSecondCriteria",
              Text = "Глаза",
              Size = new Size(50, 13),
              Location = new Point(loc.X, loc.Y + 30)
            };
            tbSecondCriteria = new ComboBox
            {
              Name = "tbSecondCriteria",
              Text = "Выберите цвет",
              Location = new Point(loc.X + lbSecondCriteria.Size.Width, loc.Y + 30),
              Size = new Size(100, 13),
              DropDownStyle = ComboBoxStyle.DropDownList
            };
            clearSC = new Button
            {
              Name = "clearSC",
              Text = "X",
              Location = new Point(tbSecondCriteria.Location.X + tbSecondCriteria.Size.Width, tbSecondCriteria.Location.Y),
              Size = new Size(20, 20)
            };
            tbSecondCriteria.Items.AddRange(new object[]{
                "Синий",
                "Голубой",
                "Серый",
                "Зелёный",
                "Янтарный",
                "Болотный",
                "Карий",
                "Чёрный",
                "Жёлтый"});
            tbSecondCriteria.Text = "Выберите цвет";

            lbFirstCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbFirstCriteria);
            tbFirstCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(tbFirstCriteria);
            clearFC.Parent = groupBox4;
            groupBox4.Controls.Add(clearFC);
            lbSecondCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(lbSecondCriteria);
            tbSecondCriteria.Parent = groupBox4;
            groupBox4.Controls.Add(tbSecondCriteria);
            clearSC.Parent = groupBox4;
            groupBox4.Controls.Add(clearSC);
            tbFirstCriteria.SelectedIndexChanged += tbFirstCriteria_SelectedIndexChanged;
            tbSecondCriteria.SelectedIndexChanged += tbFirstCriteria_SelectedIndexChanged;
            clearFC.Click += clearFC_Click;
            clearSC.Click += clearSC_Click;
            comboBox1.Hide();
          }
          break;
        case 3:
          {
            comboBox1.Show();
            comboBox1.Enabled = true;
            if (comboBox1.Items.Count == 0)
            {
              comboBox1.Items.AddRange(new object[]
            {
              "овен",
              "телец",
              "близнецы",
              "рак",
              "лев",
              "дева",
              "весы",
              "скорпион",
              "стрелец",
              "козерог",
              "водолей",
              "рыбы",
            });
            }
          }
          break;
      }
    }

    void tbSecondCriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    void clearSCS_Click(object sender, EventArgs e)
    {
      if (tbSecondCriteriaWeight != null)
        tbSecondCriteriaWeight.Text = "";
    }

    void clearFCS_Click(object sender, EventArgs e)
    {
      if (tbSecondCriteriaHeight != null)
        tbSecondCriteriaHeight.Text = "";
    }

    void tbSecondCriteriaWeight_TextChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    void tbSecondCriteriaHeight_TextChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    void tbFirstCriteriaWeight_TextChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    void tbFirstCriteriaHeight_TextChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    void clearSC_Click(object sender, EventArgs e)
    {
      if (tbSecondCriteria != null)
      {
        tbSecondCriteria.SelectedIndex = -1;
        tbFirstCriteria.Text = "Выберите";
      }
      if (tbFirstCriteriaWeight != null)
        tbFirstCriteriaWeight.Text = "";
    }

    void clearFC_Click(object sender, EventArgs e)
    {
      if (tbFirstCriteria != null)
      {
        tbFirstCriteria.SelectedIndex = -1;
        tbFirstCriteria.Text = "Выберите";
      }
      if (tbFirstCriteriaHeight != null)
        tbFirstCriteriaHeight.Text = "";
    }

    void tbFirstCriteria_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tbFirstCriteria.SelectedIndex == -1)
      {
        tbSecondCriteria.Items.Clear();
        var res1 = (from c in _clients select c.City).Distinct().ToArray();
        tbSecondCriteria.Items.AddRange(res1);
      }
      else
      {
        button4.Enabled = true;
        tbSecondCriteria.Items.Clear();
        var res2 = (from c in _clients where c.Country == (string)tbFirstCriteria.SelectedItem select c.City).Distinct().ToArray();
        tbSecondCriteria.Items.AddRange(res2);
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      comboBox4.Enabled = false;
      if (comboBox4.SelectedIndex == -1
          && comboBox1.SelectedIndex == -1)
      {
        return;
      }
      (sender as Button).Text = "Следующий";
      if ((sender as Button).Size.Width > 100)
        (sender as Button).Size = new Size((sender as Button).Size.Width - 100, (sender as Button).Height);
      endFinding = new Button
      {
        Name = "endFinding",
        Text = "Закончить",
        Location = new Point((sender as Button).Location.X + (sender as Button).Size.Width, (sender as Button).Location.Y),
        Size = new Size(100, (sender as Button).Size.Height)
      };
      endFinding.Parent = groupBox4;
      groupBox4.Controls.Add(endFinding);
      endFinding.Click += endFinding_Click;

      switch (comboBox4.SelectedIndex)
      {
        case 0:
          {
            if (tbFirstCriteria.SelectedIndex != -1
              && tbSecondCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.Country == (string)tbFirstCriteria.SelectedItem
                      && c.City == (string)tbSecondCriteria.SelectedItem)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  try
                  {
                    var pro =
                      _clients.Where(
                        c => c.ID >= 0
                             && c.Country == (string)tbFirstCriteria.SelectedItem
                             && c.City == (string)tbSecondCriteria.SelectedItem)
                        .Select(c => c)
                        .First();
                    _bs.Position = _clients.IndexOf(pro);
                  }
                  catch
                  {
                    MessageBox.Show("Поиск не дал результатов");
                  }
                }
              }
            }
            else if (tbSecondCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.City == (string)tbSecondCriteria.SelectedItem)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  var pro =
                     _clients.Where(
                       c => c.ID >= 0
                         && c.City == (string)tbSecondCriteria.SelectedItem)
                       .Select(c => c)
                       .First();
                  _bs.Position = _clients.IndexOf(pro);
                }
              }
            }
            else if (tbFirstCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.Country == (string)tbFirstCriteria.SelectedItem)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  var pro =
                     _clients.Where(
                       c => c.ID >= 0
                         && c.Country == (string)tbFirstCriteria.SelectedItem)
                       .Select(c => c)
                       .First();
                  _bs.Position = _clients.IndexOf(pro);
                }
              }
            }
          }
          break;
        case 1: //Height Weight
          {
            float FCH = (float)(tbFirstCriteriaHeight.Text != "" ? Convert.ToDouble(tbFirstCriteriaHeight.Text) : 0.0f);
            float SCH = (float)(tbSecondCriteriaHeight.Text != "" ? Convert.ToDouble(tbSecondCriteriaHeight.Text) : 3.0f);
            float FCW = (float)(tbFirstCriteriaWeight.Text != "" ? Convert.ToDouble(tbFirstCriteriaWeight.Text) : 0.0f);
            float SCW = (float)(tbSecondCriteriaWeight.Text != "" ? Convert.ToDouble(tbSecondCriteriaWeight.Text) : 400.0f);

            try
            {
              if (_bs.Position == _clients.Count - 1)
              {
                throw new Exception();
              }
              var pro =
                  _clients.Where(
                  c => c.ID > (_bs.Current as Client).ID
                    && (c.Height >= FCH
                    && c.Height <= SCH)
                    && (c.Weight >= FCW
                    && c.Weight <= SCW)
                    )
                  .Select(c => c)
                  .First();
              _bs.Position = _clients.IndexOf(pro);
            }
            catch
            {
              if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                "Начать сначала?",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
              {
                try
                {
                  var pro =
                    _clients.Where(
                  c => c.ID > 0
                    && (c.Height >= FCH
                    && c.Height <= SCH)
                    && (c.Weight >= FCW
                    && c.Weight <= SCW)
                    ).Select(c => c)
                      .First();
                  _bs.Position = _clients.IndexOf(pro);
                }
                catch
                {
                  MessageBox.Show("Поиск не дал результатов");
                }
              }
            }
          }
          break;
        case 2:
          {
            if (tbFirstCriteria.SelectedIndex != -1
              && tbSecondCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.HairColor == (HairColors)tbFirstCriteria.SelectedIndex
                      && c.EyesColor == (EyesColors)tbSecondCriteria.SelectedIndex)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  try
                  {
                    var pro =
                      _clients.Where(
                        c => c.ID >= 0
                             && c.HairColor == (HairColors)tbFirstCriteria.SelectedIndex
                            && c.EyesColor == (EyesColors)tbSecondCriteria.SelectedIndex)
                        .Select(c => c)
                        .First();
                    _bs.Position = _clients.IndexOf(pro);
                  }
                  catch
                  {
                    MessageBox.Show("Поиск не дал результатов");
                  }
                }
              }
            }
            else if (tbSecondCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.EyesColor == (EyesColors)tbSecondCriteria.SelectedIndex)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  try
                  {
                    var pro =
                       _clients.Where(
                         c => c.ID >= 0
                           && c.EyesColor == (EyesColors)tbSecondCriteria.SelectedIndex)
                         .Select(c => c)
                         .First();
                    _bs.Position = _clients.IndexOf(pro);
                  }
                  catch
                  {
                    MessageBox.Show("Поиск не дал результатов");
                  }

                }
              }
            }
            else if (tbFirstCriteria.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.HairColor == (HairColors)tbFirstCriteria.SelectedIndex)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  try
                  {
                    var pro =
                       _clients.Where(
                         c => c.ID >= 0
                           && c.HairColor == (HairColors)tbFirstCriteria.SelectedIndex)
                         .Select(c => c)
                         .First();
                    _bs.Position = _clients.IndexOf(pro);
                  }
                  catch
                  {
                    MessageBox.Show("Поиск не дал результатов");
                  }
                }
              }
            }
          }
          break;
        case 3:
          {
            if (comboBox1.SelectedIndex != -1)
            {
              try
              {
                if (_bs.Position == _clients.Count - 1)
                {
                  throw new Exception();
                }
                var pro =
                    _clients.Where(
                    c => c.ID > (_bs.Current as Client).ID
                      && c.ZodiacSing == (string)comboBox1.SelectedItem)
                    .Select(c => c)
                    .First();
                _bs.Position = _clients.IndexOf(pro);
              }
              catch
              {
                if (MessageBox.Show("Достигнут конец списка. Начать сначала?",
                  "Начать сначала?",
                  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  try
                  {
                    var pro =
                      _clients.Where(
                        c => c.ID >= 0
                             && c.ZodiacSing == (string)comboBox1.SelectedItem)
                        .Select(c => c)
                        .First();
                    _bs.Position = _clients.IndexOf(pro);
                  }
                  catch
                  {
                    MessageBox.Show("Поиск не дал результатов");
                  }
                }
              }
            }
          }
          break;
      }
    }

    void endFinding_Click(object sender, EventArgs e)
    {
      if ((sender as Button) != null)
        (sender as Button).Hide();
      hidingFields();
      comboBox1.Show();
      comboBox1.SelectedIndex = -1;
      comboBox1.Text = "Выберите значение";
      comboBox1.Enabled = false;
      comboBox4.SelectedIndex = -1;
      comboBox4.Text = "Выберите критерий";
      button4.Text = "Искать";
      button4.Enabled = false;
      button4.Size = new Size(181, 23);
      comboBox4.Enabled = true;
    }

    void hidingFields()
    {
      if (lbFirstCriteria != null)
        lbFirstCriteria.Hide();
      if (tbFirstCriteria != null)
        tbFirstCriteria.Hide();
      if (lbSecondCriteria != null)
        lbSecondCriteria.Hide();
      if (tbSecondCriteria != null)
        tbSecondCriteria.Hide();
      if (tbFirstCriteriaHeight != null)
        tbFirstCriteriaHeight.Hide();
      if (tbFirstCriteriaWeight != null)
        tbFirstCriteriaWeight.Hide();
      if (clearFC != null)
        clearFC.Hide();
      if (clearSC != null)
        clearSC.Hide();
      if (lbBetweenHeight != null)
        lbBetweenHeight.Hide();
      if (lbBetweenWeight != null)
        lbBetweenWeight.Hide();
      if (tbSecondCriteriaHeight != null)
        tbSecondCriteriaHeight.Hide();
      if (tbSecondCriteriaWeight != null)
        tbSecondCriteriaWeight.Hide();
      if (clearFCS != null)
        clearFCS.Hide();
      if (clearSCS != null)
        clearSCS.Hide();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      button4.Enabled = true;
    }

    private void label16_TextChanged(object sender, EventArgs e)
    {
      switch ((sender as Label).Text)
      {
        case "Man":
          (sender as Label).Text = "Мужской";
          break;
        case "Woman":
          (sender as Label).Text = "Женский";
          break;
      }
    }

    private void label22_TextChanged(object sender, EventArgs e)
    {
      switch ((sender as Label).Text)
      {
        case "Blonde":
          (sender as Label).Text = "Блондин";
          break;
        case "DarkBlond":
          (sender as Label).Text = "Русый";
          break;
        case "BrownHair":
          (sender as Label).Text = "Шатен";
          break;
        case "Brunet":
          (sender as Label).Text = "Брюнет";
          break;
      }
    }

    private void label23_TextChanged(object sender, EventArgs e)
    {
      switch ((sender as Label).Text)
      {
        case "DarkBlue":
          (sender as Label).Text = "Синий";
          break;
        case "Blue":
          (sender as Label).Text = "Голубой";
          break;
        case "Gray":
          (sender as Label).Text = "Серый";
          break;
        case "Green":
          (sender as Label).Text = "Зелёный";
          break;
        case "Amber":
          (sender as Label).Text = "Янтарный";
          break;
        case "MossGreen":
          (sender as Label).Text = "Болотный";
          break;
        case "DarkBrown":
          (sender as Label).Text = "Карий";
          break;
        case "Black":
          (sender as Label).Text = "Чёрный";
          break;
        case "Yellow":
          (sender as Label).Text = "Жёлтый";
          break;
      }

    }

    private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      try
      {
        saveData();
        MessageBox.Show("Данные успешно сохранены!");
      }
      catch (Exception exeption)
      {
        MessageBox.Show(exeption.Message);
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      toolStripStatusLabel1.Text = DateTime.Now.ToShortTimeString();
      toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
    }

    private void openBaseToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      DialogResult res = MessageBox.Show("Сохранить изменения в открытой базе?", "Подтверждение",
        MessageBoxButtons.YesNoCancel);
      if (res == DialogResult.Yes)
      {
        saveData();
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          readDataFromAnotherFile();
        }
        newBase();
      }
      else if (res == DialogResult.No)
      {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          readDataFromAnotherFile();
        }
        newBase();
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
        fileName = saveFileDialog1.FileName;
        XmlSerializer xs = new XmlSerializer(typeof (BindingList<Client>));
        xs.Serialize(sw, _clients);
        sw.Close();
      }
    }

    private void newBaseToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      DialogResult res = MessageBox.Show("Сохранить изменения в открытой базе?", 
        "Подтверждение",
        MessageBoxButtons.YesNoCancel);
      if (res == DialogResult.Yes)
      {
        saveData();
      }
      else if (res == DialogResult.Cancel)
      {
        return;
      }

      fileName = "";
      _clients.Clear();
      newBase();
    }
  }

  public enum Gender
  {
    Man,
    Woman
  };

  public enum HairColors
  {
    Blonde,     //блондин - белые, светлые
    DarkBlond,  //русый - светло-коричневые
    BrownHair,  //шатен - коричневые
    Brunet      //брюнет - черные
  };

  public enum EyesColors
  {
    DarkBlue, //Синий
    Blue, //Голубой
    Gray, //Серый
    Green, //Зелёный
    Amber, //Янтарный
    MossGreen, //Болотный
    DarkBrown, //Карий
    Black, //Чёрный
    Yellow //Жёлтый
  };

  [Serializable]
  public class Client //ФИО, дата рождения, пол, страна, город, рост, вес, цвет волос, цвет глаз
  {
    private Client client;

    public int ID { set; get; }
    public string LastName { set; get; }
    public string FirstName { set; get; }
    public string MiddleName { set; get; }
    public DateTime BirthDay { set; get; }
    public Gender Sex { set; get; }
    public string Country { set; get; }
    public string City { set; get; }
    public float Height { set; get; }
    public float Weight { set; get; }
    public HairColors HairColor { set; get; }
    public EyesColors EyesColor { set; get; }
    public string ZodiacSing { set; get; }

    public Client()
    {
      ID = 0;
      LastName = "";
      FirstName = "";
      MiddleName = "";
      BirthDay = DateTime.Today;
      Sex = Gender.Man;
      Country = "";
      City = "";
      Height = 0.0F;
      Weight = 0.0F;
      HairColor = HairColors.DarkBlond;
      EyesColor = EyesColors.Black;
      ZodiacSing = "овен";
    }

    public Client(
      int id,
      string lastName,
      string firstName,
      string middleName,
      DateTime birthDay,
      Gender sex,
      string country,
      string city,
      float height,
      float weight,
      HairColors hairColor,
      EyesColors eyesColor
      )
    {
      ID = id;
      LastName = lastName;
      FirstName = firstName;
      MiddleName = middleName;
      BirthDay = birthDay;
      Sex = sex;
      Country = country;
      City = city;
      Height = height;
      Weight = weight;
      HairColor = hairColor;
      EyesColor = eyesColor;
      ZodiacSing = DatingAgency.ZodiacSing.GetZodiacSing(BirthDay);
    }

    public Client(Client client) :
      this(
       client.ID,
       client.LastName,
       client.FirstName,
       client.MiddleName,
       client.BirthDay,
       client.Sex,
       client.Country,
       client.City,
       client.Height,
       client.Weight,
       client.HairColor,
       client.EyesColor)
    {
    }
  }
}