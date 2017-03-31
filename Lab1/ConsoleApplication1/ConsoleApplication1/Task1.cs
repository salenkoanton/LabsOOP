using System;
using System.Windows;
using System.Windows.Forms;
public interface IMessageLanguage
{
    void Message(string text);
}

public class User
{
    private IMessageLanguage lang;
    public string name;


    public User(string name)
    {
        this.name = name;
        this.lang = new UaLang();
    }

    public void SetLanguage(IMessageLanguage lang)
    {
        this.lang = lang;
    }
    
    public void Message(string text)
    {
        lang.Message(text);
    }

    public string Language
    {
        get { return lang.GetType().ToString(); }
    }

}

public class EnLang : IMessageLanguage
{
    public EnLang() { }

    public void Message(string text)
    {
        MessageBox.Show(text, "Message");
    }
}


public class RuLang : IMessageLanguage
{
    public RuLang() { }


    public void Message(string text)
    {
        MessageBox.Show(text, "Сообщение");
    }
}

public class UaLang : IMessageLanguage
{
    public UaLang() { }


    public void Message(string text)
    {
        MessageBox.Show(text, "Повідомлення");
    }
}

