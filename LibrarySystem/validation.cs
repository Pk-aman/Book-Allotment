using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllValidation
{
    class validation
    {

        public char getNumberOnly(char ch)
        {
            if (!(char.IsNumber(ch)) && !(char.IsControl(ch)))
            {
                //MessageBox.Show(e.KeyChar.ToString());
                return '\0';
            }
            return ch;
        }
        public char getAlphabetOnly(char ch)
        {
            if (!(char.IsLetter(ch)) && !(char.IsControl(ch)) && !(char.IsWhiteSpace(ch)))
            {
                //MessageBox.Show(e.KeyChar.ToString());
                return '\0';
            }
            return ch;
        }

        public char getAlphabetWithoutSpace(char ch)
        {
            if (!(char.IsLetter(ch)) && !(char.IsControl(ch)))
            {
                //MessageBox.Show(e.KeyChar.ToString());
                return '\0';
            }
            return ch;
        }

        public char getNumberOnly10digit(char ch, TextBox textbox)
        {
            if (textbox.Text.Length < 10)
            {
                if (!(char.IsNumber(ch)) && !(char.IsControl(ch)))
                {
                    //MessageBox.Show(e.KeyChar.ToString());
                    return '\0';
                }
                else
                {
                    return ch;
                }
            }
            else
            {
                if (char.IsControl(ch))
                {
                    return ch;
                }
                return '\0';
            }
        }

        public char getNumberOnly10digit(char ch, Guna2TextBox textbox)
        {
            if (textbox.Text.Length < 10)
            {
                if (!(char.IsNumber(ch)) && !(char.IsControl(ch)))
                {
                    //MessageBox.Show(e.KeyChar.ToString());
                    return '\0';
                }
                else
                {
                    return ch;
                }
            }
            else
            {
                if (char.IsControl(ch))
                {
                    return ch;
                }
                return '\0';
            }
        }

        public char getNumberOnly_Ndigit(char ch, Guna2TextBox textbox, int n)
        {
            if (textbox.Text.Length < n)
            {
                if (!(char.IsNumber(ch)) && !(char.IsControl(ch)))
                {
                    //MessageBox.Show(e.KeyChar.ToString());
                    return '\0';
                }
                else
                {
                    return ch;
                }
            }
            else
            {
                if (char.IsControl(ch))
                {
                    return ch;
                }
                return '\0';
            }
        }

        public char getnumberandletters(char ch)
        {
            if (!(char.IsNumber(ch)) && !(char.IsLetter(ch)) && !(char.IsControl(ch)) && !(char.IsWhiteSpace(ch)))
            {
                //MessageBox.Show(e.KeyChar.ToString());
                return '\0';
            }
            return ch;
        }

        public char OnlyUpperCaseLetter(char ch)
        {
            validation vali = new validation();
            ch = vali.getAlphabetOnly(ch);
            if (char.IsLower(ch))
            {
                return Convert.ToChar(ch.ToString().ToUpper());
            }
            return ch;
        }

        public char UpperCaseWithNumber(char ch)
        {
            validation vali = new validation();
            ch = vali.getnumberandletters(ch);
            if (char.IsLower(ch))
            {
                return Convert.ToChar(ch.ToString().ToUpper());
            }
            return ch;
        }

        public char UpperCaseWithNumberWithoutSpace(char ch)
        {
            validation vali = new validation();
            ch = vali.getnumberandletters(ch);
            if (char.IsWhiteSpace(ch))
            {
                return '\0';
            }
            else if (char.IsLower(ch))
            {
                return Convert.ToChar(ch.ToString().ToUpper());
            }
            return ch;
        }
    }  
}
