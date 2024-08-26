using System.ComponentModel.DataAnnotations;
using api_rest_emprestimo.Validate.Interface;

namespace api_rest_emprestimo.Validate;

public class ValidateCpf : ValidationAttribute, IValidateCpf
{

  public ValidateCpf()
  {
      
  }

  public override bool IsValid(Object value)
  {
    if(value == null || string.IsNullOrEmpty(value.ToString())) return true;
    var valid = ValidCpf(value.ToString());
    return valid;
  }


  public string RemoveIsNotNumeric(string txt)
  {
    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(txt);
    string ret = regex.Replace(txt,string.Empty);
    return ret;
  }

  public bool ValidCpf(string cpf)
  {
        cpf = RemoveIsNotNumeric(cpf);
        cpf = cpf.Trim();
        cpf = cpf.Replace("."," ").Replace("-", "");
        if (cpf.Length < 11)
        {
            return false;
        }

        while (cpf.Length != 11)
            cpf = '0' + cpf;

        bool igual = true;
        for (int i = 1; i < 11 && igual; i++)
            if (cpf[i] != cpf[0])
                igual = false;

        if (igual || cpf == "12345678909")
            return false;

        int[] num = new int[11];

        for (int i = 0; i < 11; i++)
            num[i] = int.Parse(cpf[i].ToString());

        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (10 - 1) * num[i];

        int result = soma % 11;

        if (result == 1 || result == 0)
        {
            if (num[9] != 11 - 0)
                return false;
        }
        else if (num[9] != 11 - result)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (11 - i) * num[i];
        result = soma % 11;

        if (result == 1 || result == 0)
        {
            if (num[10] != 0)
                return false;
        }
        else if (num[10] != 11 - result)
            return false;

        return true;
  } 

}
