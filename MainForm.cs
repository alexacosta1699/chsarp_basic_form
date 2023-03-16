public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void OpenChildForm1Button_Click(object sender, EventArgs e)
    {
        ChildForm1 childForm1 = new ChildForm1();
        childForm1.ShowDialog();
    }

    private void OpenChildForm2Button_Click(object sender, EventArgs e)
    {
        ChildForm2 childForm2 = new ChildForm2();
        childForm2.ShowDialog();
    }
}
