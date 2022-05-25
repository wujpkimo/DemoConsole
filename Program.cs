var form = new Form()
{
    FormBorderStyle = FormBorderStyle.None,
    StartPosition = FormStartPosition.CenterScreen,
    TopMost = true,
    ControlBox = false,
    ShowInTaskbar = false,
    Opacity = 0.8,
    Width = 0,
    Height = 0
};

var lbl = new Label()
{
    Padding = new Padding(8),
    AutoSize = true,
    Font = new Font("微軟正黑體", 15, FontStyle.Bold),
    BackColor = Color.Coral
};

form.Controls.Add(lbl);
form.Show();
var startX = form.Left;

void ShowInfo(string msg)
{
    lbl.Text = msg;
    form.Width = lbl.Width;
    form.Height = lbl.Height;
    form.Left = startX - form.Width / 2;
    form.Refresh();
}

try
{
    ShowInfo("上傳中...");
    var uploadedCount = SimulateUpload();
    ShowInfo($"成功上傳{uploadedCount}筆");
    //ShowMessage($"成功上傳{uploadedCount}筆");
    //Console.WriteLine($"上傳{uploadedCount}筆");
    Thread.Sleep(2000);
    form.Close();
}
catch (Exception ex)
{
    //Console.ForegroundColor = ConsoleColor.Red;
    //Console.WriteLine(ex.Message);
    //Console.ReadLine();
    ShowMessage(ex.Message);
}

void ShowMessage(string msg)
{
    MessageBox.Show(msg, "上傳作業");
}
int SimulateUpload()
{
    var rnd = new Random();
    if (rnd.Next() % 3 == 1)
    {
        throw new ApplicationException("模擬上傳失敗");
    }
    Thread.Sleep(1000 + rnd.Next(3000));
    return rnd.Next(5) + 1;
}