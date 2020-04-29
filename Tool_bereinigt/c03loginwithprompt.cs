class c03loginwithprompt
{
    public c03loginwithprompt()
    {
        this.runloginsuccess = false;
        this.runloginbenutzernamesuccess = false;
        this.runloginpasswortsuccess = false;
    }

    public string benutzername;
    public string passwort;
    public bool runloginsuccess;
    public bool runloginwithpromptsuccess;
    public bool runloginbenutzernamesuccess;
    public bool runloginpasswortsuccess;

    public string runloginwithprompt(string text, string caption, bool durchfuehren, int msgboxjaneinvalue)
    {
        this.runloginwithpromptsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {

            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            };
            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Left = 50, Top = 20, Text = text };
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.Focus();
            if (text == "Benutzername")
            {
                textBox.Text = "";
            }
            else if (text == "Passwort")
            {
                textBox.PasswordChar = '*';
            }

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = System.Windows.Forms.DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            this.runloginwithpromptsuccess = true;
            return prompt.ShowDialog() == System.Windows.Forms.DialogResult.OK ? textBox.Text : "";
        }
        else
        {
            return "";
        }
    }

    public void runlogin(string text, string caption, bool durchfuehren, int msgboxjaneinvalue)
    {
        this.runloginsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) {
            if (text == "Benutzername") { 
                this.benutzername = runloginwithprompt(text, caption, durchfuehren, msgboxjaneinvalue);
                this.runloginbenutzernamesuccess = true;
            }
            if (text == "Passwort") { 
                this.passwort = runloginwithprompt(text, caption, durchfuehren, msgboxjaneinvalue);
                this.runloginpasswortsuccess = true;
            }
            this.runloginsuccess = true;
        }
    }
}